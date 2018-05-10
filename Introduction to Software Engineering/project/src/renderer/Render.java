/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package renderer;

import java.awt.Color;
import java.util.ArrayList;

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

	public void renderImage() {
		for (int i = 0; i < _imageWriter.getNy(); i++) {
			for (int j = 0; j < _imageWriter.getNx(); j++) {
				Ray ray = _scene.get_camera().constructorRay(_imageWriter.getNx(), _imageWriter.getNy(), i, j,
						_scene.get_distance(), _imageWriter.getWidth(), _imageWriter.getHeight());
				ArrayList<Point3D> intersectionList = new ArrayList<Point3D>();
				for (Geometry geometry : _scene.get_geometries()) {
					intersectionList.addAll(geometry.findIntersections(ray));
				}
				if (intersectionList.size() == 0) {
					_imageWriter.writePixel(i, j, _scene.get_backGround());
				} else {
					Point3D closestPoint = getClosestPoint(intersectionList);
					_imageWriter.writePixel(i, j, calcColor(closestPoint));
				}
			}
		}
	}

	private Point3D getClosestPoint(ArrayList<Point3D> intersectionList) {
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

	private Color calcColor(Point3D point) {
		return _scene.get_light().getIntensity().getColor();
	}

	public void writeToImage() {
		_imageWriter.writeToimage();
	}

	public void printGrid(int interval) {
		for (int i = 0; i < _imageWriter.getNy() - 1; i++) {
			for (int j = 0; j < _imageWriter.getNx() - 1; j++) {
				if ((i + 1) % interval == 0 || (j + 1) % interval == 0) {
					_imageWriter.writePixel(j, i, _scene.get_light().getIntensity().getColor());
				}
			}
		}
	}
}
