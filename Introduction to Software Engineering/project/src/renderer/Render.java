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
		for (int i = 1; i < _imageWriter.getNy(); i++) {
			for (int j = 1; j < _imageWriter.getNx(); j++) {
				Ray ray = _scene.get_camera().constructorRay(_imageWriter.getNx(), _imageWriter.getNy(), i, j,
						_scene.get_distance(), _imageWriter.getWidth(), _imageWriter.getHeight());
				List<Point3D> intersectionList = _scene.get_geometries().findIntersections(ray);
				if (intersectionList.size() == 0) {
					_imageWriter.writePixel(i, j, _scene.get_backGround());
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
		if (intersectionList.size()==0) return null;
		Point3D cameraPoint = _scene.get_camera().get_p0();
		Coordinate distance = intersectionList.get(0).distanceFrom(cameraPoint);
		Point3D closestPoint = intersectionList.get(0);
		for (int i = 1; i < intersectionList.size(); i++) {
			Coordinate dis = intersectionList.get(i).distanceFrom(cameraPoint);
			if (dis.getValue() < distance.getValue()) {
				distance = dis;
				closestPoint = intersectionList.get(i);
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
		for (int i = 1; i < _imageWriter.getNy(); i++) {
			for (int j = 1; j < _imageWriter.getNx() ; j++) {
				if (i % interval == 0 || j % interval == 0) {
					_imageWriter.writePixel(j, i, _scene.get_light().getIntensity().getColor());
				}
			}
		}
	}
}
