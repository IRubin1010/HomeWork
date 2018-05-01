/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package scene;

import java.awt.Color;
import java.util.ArrayList;
import java.util.List;
import java.lang.*;

import elements.Camera;
import geometries.Geometry;
import primitives.Point3D;
import primitives.Vector;

/**
 * class that represents a scene
 */
public class Scene {
	
	private String _name;
	private Color _color;
	private List<Geometry> _geometriesList;
	private Camera _camera;
	private double _distance;
	
	/***************** Constructors **********************/

	/**
	 * default constructor with name
	 * @param name - name of the scene
	 * put default values Other variables
	 */
	public Scene(String name) {
		this._name=name;
		this._color=new Color(0,0,0);
		this._geometriesList=new ArrayList<Geometry>();
		this._camera=new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0,0,0));
		this._distance=1;
	}

	/***************** Getters ****************************/

	/**
	 * @return the _color
	 */
	public Color get_color() {
		return _color;
	}


	/**
	 * @return the _camera
	 */
	public Camera get_camera() {
		return _camera;
	}


	/**
	 * @return the _distance
	 */
	public double get_distance() {
		return _distance;
	}

	/***************** Setters ****************************/

	/**
	 * @param _color the _color to set
	 */
	public void set_color(Color _color) {
		this._color = _color;
	}


	/**
	 * @param _camera the _camera to set
	 */
	public void set_camera(Camera _camera) {
		this._camera = _camera;
	}


	/**
	 * @param _distance the _distance to set
	 */
	public void set_distance(double _distance) {
		this._distance = _distance;
	}

	/***************** Operations ************************/
	
	/**
	 * Add geometry to the scene
	 * @param geometry - Geometry to add
	 */
	public void addGeometry(Geometry geometry) {
		this._geometriesList.add(geometry);
	}
}
