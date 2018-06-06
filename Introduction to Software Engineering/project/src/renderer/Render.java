/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package renderer;

import java.awt.Color;
import java.security.KeyStore.Entry;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.PrimitiveIterator;

import elements.AmbientLight;
import elements.LightSource;
import geometries.Geometries;
import geometries.Geometry;
import primitives.Coordinate;
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
	 * @param scene
	 * @param imageWriter
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
		double distance = _scene.get_distance();
		double width = _imageWriter.getWidth();
		double height = _imageWriter.getHeight();

		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx; j++) {
				Ray ray = _scene.get_camera().constructRayThroghPixel(Nx, Ny, i, j, distance, width, height);
				Map<Geometry, List<Point3D>> intersectionList = _scene.get_geometries().findIntersections(ray);
				if (intersectionList.isEmpty()) {
					_imageWriter.writePixel(i, j, _scene.get_background().getColor());
				} else {
					GeometryPoint closestPoint = getClosestPoint(intersectionList);
					_imageWriter.writePixel(i, j, calcColor(closestPoint, ray).getColor());
				}
			}
		}
	}

	/**
	 * find the closest object to the camera
	 * @param intersectionList
	 * @return
	 */
	private GeometryPoint getClosestPoint(Map<Geometry, List<Point3D>> intersectionList) {
		Point3D cameraPoint = _scene.get_camera().getP0();
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
	 * calc color function
	 * @param point
	 * @param inRay
	 * @return
	 */
	private primitives.Color calcColor(GeometryPoint point, Ray inRay) {
		return calcColor(point, inRay, MAX_CALC_COLOR_LEVEL, 1.0);
	}

	/**
	 * calculate the pixel color
	 * @param point
	 * @return
	 */
	private primitives.Color calcColor(GeometryPoint point, Ray inRay, int level, double k) {
		if (level == 0 || Coordinate.ZERO.equals(k))
			return new primitives.Color(0, 0, 0);
		primitives.Color color = new primitives.Color(_scene.get_ambientlight().getIntensity());
		color.add(point.geometry.getEmmission());
		Vector v = inRay.getDirection();

		Vector n = point.geometry.getNormal(point.point).normalize();
		int nShinines = point.geometry.getMaterial().getNShininess();
		double Kd = point.geometry.getMaterial().getKd();
		double Ks = point.geometry.getMaterial().getKs();

		if (!(_scene.get_lights() == null)) {
			for (LightSource lightSource : _scene.get_lights()) {
				Vector l = lightSource.getL(point.point);
				if (n.dotProduct(l) * n.dotProduct(v) > 0) {
					double o = occluded(l, point);
					if (!Coordinate.ZERO.equals(o*k)) {
						primitives.Color lightIntensity = new primitives.Color(lightSource.getIntensity(point.point)).scale(o);
						color.add(calcDiffusive(Kd, l, n, lightIntensity));
						color.add(calcSpecular(Ks, l, n, v, nShinines, lightIntensity));
					}
				}
			}
		}

		Point3D epsPoint = addEpsToPoints(n,point.point,v);
		Ray reflectedRay = constructReflectedRay(n, v, epsPoint);
		GeometryPoint reflectedPoint = findClosestIntersection(reflectedRay);
		if (reflectedPoint.geometry != null) {
			double kr = reflectedPoint.geometry.getMaterial().getKr();
			primitives.Color reflectedLight = calcColor(reflectedPoint, reflectedRay, level - 1, k * kr).scale(kr);
			color.add(reflectedLight);
		}
		Ray refractedRay = new Ray(epsPoint, v);
		GeometryPoint refractedPoint = findClosestIntersection(refractedRay);
		if (refractedPoint.geometry != null) {
			double kt = refractedPoint.geometry.getMaterial().getKt();
			primitives.Color refractedLight = calcColor(refractedPoint, refractedRay, level - 1, k * kt).scale(kt);
			color.add(refractedLight);
		}
		return color;

	}

	/**
	 * return the diffusive color
	 * @param Kd
	 * @param l
	 * @param n
	 * @param lightIntensity
	 * @return
	 */
	private primitives.Color calcDiffusive(double Kd, Vector l, Vector n, primitives.Color lightIntensity) {
		double angleCos = Math.abs(l.dotProduct(n));
		primitives.Color light = new primitives.Color(lightIntensity);
		return light.scale(Kd * angleCos);
	}

	private primitives.Color calcSpecular(double Ks, Vector l, Vector n, Vector v, int nShinines,
			primitives.Color lightIntensity) {
		Vector r = l.sub(n.scaleVector(l.dotProduct(n) * 2));
		double vr = r.dotProduct(v);
		if (vr < 0) {
			double angleCos = Math.pow(-vr, nShinines);
			primitives.Color light = new primitives.Color(lightIntensity);
			return light.scale(Ks * angleCos);
		} else {
			return new primitives.Color(0, 0, 0);
		}
	}

	/**
	 * write the picture
	 */
	public void writeToImage() {
		_imageWriter.writeToimage();
	}

	/**
	 * print Grid
	 * 
	 * @param interval
	 */
	public void printGrid(int interval) {
		int Nx = _imageWriter.getNx();
		int Ny = _imageWriter.getNy();
		Color color = _scene.get_ambientlight().getIntensity().getColor();
		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx; j++) {
				if (i % interval == 0 || j % interval == 0) {
					_imageWriter.writePixel(j, i, color);
				}
			}
		}
	}

	/**
	 * occluded
	 * 
	 * @param l
	 * @param point
	 * @return
	 */
	private double occluded(Vector l, GeometryPoint point) {
		Point3D gPoint = point.point;
		Geometry geometry = point.geometry;
		Vector lightDirection = l.scaleVector(-1);

		Vector normal = geometry.getNormal(gPoint);
		Vector epsVector = normal.scaleVector(normal.dotProduct(lightDirection) > 0 ? 2 : -2);
		Point3D geomtryPoint = gPoint.addVectorToPoint(epsVector);

		Ray lightRay = new Ray(geomtryPoint, lightDirection);

		Map<Geometry, List<Point3D>> intersectionPoint = _scene.get_geometries().findIntersections(lightRay);

		double shadowK = 1;
		for(Map.Entry<Geometry, List<Point3D>> entry : intersectionPoint.entrySet()) {
			shadowK *= entry.getKey().getMaterial().getKt();
		}
		return shadowK;
	}

	private Ray constructReflectedRay(Vector n, Vector v, Point3D point) {
		return new Ray(point, v.sub(n.scaleVector(v.dotProduct(n) * 2)));
	}

	private GeometryPoint findClosestIntersection(Ray ray) {
		Map<Geometry, List<Point3D>> intersectionList = _scene.get_geometries().findIntersections(ray);
		return getClosestPoint(intersectionList);
	}
	
	private Point3D addEpsToPoints(Vector normal, Point3D point, Vector v) {
        Vector epsVector = normal.scaleVector(normal.dotProduct(v) > 0 ? 0.5 : -0.5);
        return point.addVectorToPoint(epsVector);
    }
}
