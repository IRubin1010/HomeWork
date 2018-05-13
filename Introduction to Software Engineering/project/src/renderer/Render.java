/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package renderer;

import java.awt.Color;
import java.util.ArrayList;
import java.util.List;

import elements.AmbientLight;
import geometries.Geometries;
import geometries.Geometry;
import primitives.Coordinate;
import primitives.Point3D;
import primitives.Ray;
import scene.Scene;

/**
 * class represents Render
 *
 */
public class Render {

	Scene _scene;
	ImageWriter _imageWriter;

	/***************** Constructor **********************/ 

	/**
	 * constructor
	 * 
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
		double distance=_scene.get_distance();
		double width= _imageWriter.getWidth();
		double height= _imageWriter.getHeight();

		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx; j++) {
				Ray ray = _scene.get_camera().constructRayThroghPixel(Nx, Ny, i, j, distance, width, height);
				List<Point3D> intersectionList = _scene.get_geometries().findIntersections(ray);
				if (intersectionList.isEmpty()) {
					_imageWriter.writePixel(i, j, _scene.get_background().getColor());
				} else {
					Point3D closestPoint = getClosestPoint(intersectionList);
					_imageWriter.writePixel(i, j, calcColor(closestPoint));
				}
			}
		}
	}

	/**
	 * find the closest object to the camera
	 * @param intersectionList
	 * @return
	 */
	private Point3D getClosestPoint(List<Point3D> intersectionList) {
		Point3D cameraPoint = _scene.get_camera().get_p0();
		double distance = Double.MAX_VALUE;
		Point3D closestPoint = null;
		for (Point3D point : intersectionList) {
			double dis = point.distanceFrom(cameraPoint);
			if (dis < distance) {
				distance = dis;
				closestPoint = point;
			}
		}
		return closestPoint;
	}

	/**
	 * calculate the pixel color 
	 * @param point
	 * @return
	 */
	private Color calcColor(Point3D point) {
		return _scene.get_light().getIntensity().getColor();
	}

	/**
	 * write the picture
	 */
	public void writeToImage() {
		_imageWriter.writeToimage();
	}

	/**
	 * print Grid
	 * @param interval
	 */
	public void printGrid(int interval) {
		int Nx = _imageWriter.getNx();
		int Ny = _imageWriter.getNy();
		Color color = _scene.get_light().getIntensity().getColor();
		for (int i = 1; i < Ny; i++) {
			for (int j = 1; j < Nx ; j++) {
				if (i % interval == 0 || j % interval == 0) {
					_imageWriter.writePixel(j, i, color);
				}
			}
		}
	}
}
