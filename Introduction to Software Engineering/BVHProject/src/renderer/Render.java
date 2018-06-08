/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package renderer;

import java.util.List;
import java.util.Map;

import lights.AmbientLight;
import lights.LightSource;
import geometries.Geometries;
import geometries.Geometry;
import primitives.Color;
import primitives.Coordinate;
import primitives.Material;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;
import scene.Scene;

/**
 * class represents Render
 *
 */
public class Render {

	Scene _scene;
	ImageWriter _imageWriter;

	private final static int MAX_CALC_COLOR_LEVEL = 2;

	/**
	 * class represents geometry point
	 */
	private static class GeometryPoint {

		public Geometry geometry;
		public Point3D point;
	}

	/***************** Constructor **********************/

	/**
	 * constructor
	 * 
	 * @param scene
	 *            the scene
	 * @param imageWriter
	 *            imageWriter object
	 */
	public Render(Scene scene, ImageWriter imageWriter) {
		_scene = new Scene(scene);
		_imageWriter = new ImageWriter(imageWriter);
	}

	/***************** Operations ************************/

	/**
	 * render the image from all geometry objects
	 */
	public void renderImage() {
		int Nx = _imageWriter.getNx();
		int Ny = _imageWriter.getNy();
		double distance = _scene.getDistance();
		double width = _imageWriter.getWidth();
		double height = _imageWriter.getHeight();

		// calculate the color for each pixel
		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx; j++) {

				// calculate the ray from the camera through the pixel
				Ray ray = _scene.getCamera().constructRayThroughPixel(Nx, Ny, i, j, distance, width, height);

				// find the intersection of the ray with the geometries
				Map<Geometry, List<Point3D>> intersectionList = _scene.getGeometries().findIntersections(ray);

				if (intersectionList.isEmpty()) {
					_imageWriter.writePixel(i, j, _scene.getBackground().getColor());
				} else {
					GeometryPoint closestPoint = getClosestPoint(intersectionList);
					_imageWriter.writePixel(i, j, calcColor(closestPoint, ray).getColor());
				}
			}
		}
	}

	/**
	 * find the closest geometry to the camera
	 * @param intersectionList a list of geometry intersected by the ray
	 * @return the closes geometry to the camera
	 */
	private GeometryPoint getClosestPoint(Map<Geometry, List<Point3D>> intersectionList) {
		Point3D cameraPoint = _scene.getCamera().getP0();
		double minDistance = Double.MAX_VALUE;
		GeometryPoint closestPoint = new GeometryPoint();
		for (Map.Entry<Geometry, List<Point3D>> entry : intersectionList.entrySet()) {
			for (Point3D point : entry.getValue()) {
				double dis = point.distanceFrom(cameraPoint);
				if (dis < minDistance) {
					minDistance = dis;
					closestPoint.point = point;
					closestPoint.geometry = entry.getKey();
				}
			}
		}
		return closestPoint;
	}

	/**
	 * calculate the pixel color
	 * 
	 * @param point
	 *            geometryPoint to calculate the color
	 * @param inRay
	 *            the ray that passes through the geometry
	 * @return the color to this pixel
	 */
	private Color calcColor(GeometryPoint point, Ray inRay) {
		return calcColor(point, inRay, MAX_CALC_COLOR_LEVEL, 1.0);
	}//

	/**
	 * calculate the pixel color
	 * 
	 * @param point
	 *            geometryPoint to calculate the color
	 * @param inRay
	 *            the ray that passes through the geometry
	 * @param level
	 *            how deep to trace
	 * @param k
	 *            k factor
	 * @return the color to this pixel
	 */
	private Color calcColor(GeometryPoint point, Ray inRay, int level, double k) {
		if (level == 0 || Coordinate.ZERO.equals(k))
			return Color.BLACK;

		Material mat = point.geometry.getMaterial();
		double kr = mat.getKr();
		double kt = mat.getKt();
		Color color = new Color(_scene.getAmbientlight().getIntensity().scale(Math.max(0, 1 - kr - kt)));
		color.add(point.geometry.getEmmission());

		// if there is no lights
		List<LightSource> lightsList = _scene.getLights();
		if (lightsList == null || lightsList.isEmpty()) {
			return color;
		}

		Vector v = inRay.getDirection();

		Vector n = point.geometry.getNormal(point.point);
		int nShinines = point.geometry.getMaterial().getNShininess();
		double Kd = point.geometry.getMaterial().getKd();
		double Ks = point.geometry.getMaterial().getKs();

		for (LightSource lightSource :lightsList) {
			Vector l = lightSource.getL(point.point);
			if (n.dotProduct(l) * n.dotProduct(v) > 0) {
				double o = occluded(l, point,lightSource);
				if (!Coordinate.ZERO.equals(o * k)) {
					Color lightIntensity = new Color(lightSource.getIntensity(point.point)).scale(o);
					color.add(calcDiffusive(Kd, l, n, lightIntensity));
					color.add(calcSpecular(Ks, l, n, v, nShinines, lightIntensity));
				}
			}
		}

		Ray reflectedRay = constructReflectedRay(n, v, point.point);
		GeometryPoint reflectedPoint = findClosestIntersection(reflectedRay);
		if (reflectedPoint.geometry != null) {
			Color reflectedLight = calcColor(reflectedPoint, reflectedRay, level - 1, k * kr).scale(kr);
			color.add(reflectedLight);
		}

		Ray refractedRay = constructRefractedRay(n, v, point.point);
		GeometryPoint refractedPoint = findClosestIntersection(refractedRay);
		if (refractedPoint.geometry != null) {
			Color refractedLight = calcColor(refractedPoint, refractedRay, level - 1, k * kt).scale(kt);
			color.add(refractedLight);
		}
		return color;

	}

	/**
	 * calculate the diffusive color
	 * @param Kd diffusive factor
	 * @param l the light direction
	 * @param n normal
	 * @param lightIntensity the light intensity
	 * @return the diffusive color
	 */
	private Color calcDiffusive(double Kd, Vector l, Vector n, Color lightIntensity) {
		double angleCos = Math.abs(l.dotProduct(n));
		Color light = new Color(lightIntensity);
		return light.scale(Kd * angleCos);
	}

	/**
	 * calculate the specular color
	 * @param Ks specular factor
	 * @param l the light direction
	 * @param n normal
	 * @param v vector from the camera to the geometry
	 * @param nShinines nShinines factor
	 * @param lightIntensity the light intensity
	 * @return the specular color
	 */
	private Color calcSpecular(double Ks, Vector l, Vector n, Vector v, int nShinines, Color lightIntensity) {
		Vector r = l.sub(n.scaleVector(l.dotProduct(n) * 2)).normalize();
		double vr = r.dotProduct(v);
		if (vr < 0) {
			double angleCos = Math.pow(-vr, nShinines);
			Color light = new Color(lightIntensity);
			return light.scale(Ks * angleCos);
		} else {
			return Color.BLACK;
		}
	}

	/**
	 * write the picture
	 */
	public void writeToImage() {
		_imageWriter.writeToimage();
	}

	/**
	 * print Grid on the picture background
	 * 
	 * @param interval
	 *            the space between the grid lines
	 */
	public void printGrid(int interval) {
		int Nx = _imageWriter.getNx();
		int Ny = _imageWriter.getNy();
		java.awt.Color color = _scene.getAmbientlight().getIntensity().getColor();
		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx; j++) {
				if (i % interval == 0 || j % interval == 0) {
					_imageWriter.writePixel(j, i, color);
				}
			}
		}
	}

	/**
	 * calculate the shadow
	 * @param l vector from the light to the point
	 * @param point point to calculate the shadow to
	 * @return the shadow factor
	 */
	private double occluded(Vector l, GeometryPoint point, LightSource lightSource) {
		Point3D gPoint = point.point;
		Geometry geometry = point.geometry;
		Vector lightDirection = l.scaleVector(-1);

		Vector normal = geometry.getNormal(gPoint);
		Point3D epsPoint = addEpsToPoints(normal,gPoint,lightDirection);

		Ray lightRay = new Ray(epsPoint, lightDirection);

		Map<Geometry, List<Point3D>> intersectionPoints = _scene.getGeometries().findIntersections(lightRay);

		 double maxDistance = lightSource.getDistance(gPoint);
	        double shadowK = 1;
	        for (Map.Entry<Geometry, List<Point3D>> entry : intersectionPoints.entrySet()) {
	            //for every point check if it is behind the light
	            for(Point3D p : entry.getValue()){
	                double d = gPoint.distanceFrom(p);
	                if(d < maxDistance)
	                    shadowK *= entry.getKey().getMaterial().getKt();
	            }
	        }
		return shadowK;
	}

	/**
	 * construct the reflected ray
	 * @param n normal to the point
	 * @param v ray vector
	 * @param point the point to calculate the reflection
	 * @return the reflected ray 
	 */
	private Ray constructReflectedRay(Vector n, Vector v, Point3D point) {
		Vector RayVector = v.sub(n.scaleVector(v.dotProduct(n) * 2)).normalize();
		Point3D epsPoint = addEpsToPoints(n, point, RayVector);
		return new Ray(epsPoint, RayVector);
	}

	/**
	 * construct the refracted ray
	 * @param n normal to the point
	 * @param v ray vector
	 * @param point the point to calculate the refraction
	 * @return the refracted ray 
	 */
	private Ray constructRefractedRay(Vector n, Vector v, Point3D point) {
		Point3D epsPoint = addEpsToPoints(n, point, v);
		return new Ray(epsPoint, v);
	}

	/**
	 * calculate the closets intersection of a ray
	 * @param ray ray to get the closest intersection
	 * @return the closets intersection of the ray
	 */
	private GeometryPoint findClosestIntersection(Ray ray) {
		Map<Geometry, List<Point3D>> intersectionList = _scene.getGeometries().findIntersections(ray);
		return getClosestPoint(intersectionList);
	}

	
	/**
	 * add epsilon to point
	 * @param normal normal from the point
	 * @param point point to add epsilon
	 * @param v ray direction
	 * @return the point added by epsilon
	 */
	private Point3D addEpsToPoints(Vector normal, Point3D point, Vector v) {
		Vector epsVector = normal.scaleVector(normal.dotProduct(v) > 0 ? 0.1 : -0.1);
		return point.addVectorToPoint(epsVector);
	}
}
