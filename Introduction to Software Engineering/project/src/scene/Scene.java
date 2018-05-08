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
import geometries.Geometries;
import geometries.Geometry;
import primitives.Point3D;
import primitives.Vector;

/**
 * class that represents a scene
 */
public class Scene {
	
	private String _name;
	private Color _backGround;
	private Geometries _geometries;
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
		this._backGround=new Color(0,0,0);
		this._geometries=new Geometries();
		this._camera=new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0,0,0));
		this._distance=1;
	}
	
	/**
	 * copy constructor
	 * @param scene
	 */
	public Scene(Scene scene) {
		_name = scene._name;
		_backGround = new Color(scene._backGround.getRGB());
		_geometries = scene._geometries;
		_camera = new Camera(scene._camera);
		_distance = scene._distance;
	}

	/***************** Getters ****************************/

	/**
	 * @return the _color
	 */
	public Color get_backGround() {
		return _backGround;
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

	/**
	 * @return the _geometriesList
	 */
	public ArrayList<Geometry> get_geometries() {
		return _geometries.getGeometries();
	}
	
	/***************** Setters ****************************/

	/**
	 * @param _geometriesList the _geometriesList to set
	 */
	public void set_geometries(Geometries geometries) {
		this._geometries = geometries;
	}

	/**
	 * @param _color the _color to set
	 */
	public void set_backGround(Color _backGround) {
		this._backGround = _backGround;
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
		this._geometries.getGeometries().add(geometry);
	}

}
