/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package scene;

//import java.awt.Color;
import java.util.ArrayList;
import java.util.List;
import java.lang.*;

import elements.AmbientLight;
import elements.Camera;
import geometries.Geometries;
import geometries.Geometry;
import primitives.Color;
import primitives.Point3D;
import primitives.Vector;

/**
 * class that represents a scene
 */
public class Scene {

	private String _name;
	private Color _background;
	private Geometries _geometries = new Geometries();
	private Camera _camera;
	private double _distance;
	private AmbientLight _light; 

	/***************** Constructors **********************/

	/**
	 * default constructor with name
	 * @param name
	 *            - name of the scene put default values Other variables
	 */
	public Scene(String name) {
		this._name = name;
		this._background = new Color(0, 0, 0);
		this._light = new AmbientLight(new Color(255, 255, 255), 1);
	}

	/**
	 * copy constructor
	 * @param scene
	 */
	public Scene(Scene scene) {
		_name = scene._name;
		_background = scene._background;
		_geometries = scene._geometries;
		_camera = new Camera(scene._camera);
		_distance = scene._distance;
		_light=scene.get_light();
	}

	/***************** Getters ****************************/

	/**
	 * @return the _color
	 */
	public Color get_backGround() {
		return _background;
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
	public Geometries get_geometries() {
		return _geometries;
	}

	/**
	 * @return the _light
	 */
	public AmbientLight get_light() {
		return _light;
		}
	/***************** Setters ****************************/

	/**
	 * @param _geometriesList
	 *            the _geometriesList to set
	 */
	public void set_geometries(Geometries geometries) {
		this._geometries = geometries;
	}

	/**
	 * @param _color
	 *            the _color to set
	 */
	public void set_backGround(Color _backGround) {
		this._background = _backGround;
	}

	/**
	 * @param _camera
	 *            the _camera to set
	 */
	public void set_camera(Camera _camera) {
		this._camera = _camera;
	}

	/**
	 * @param _distance
	 *            the _distance to set
	 */
	public void set_distance(double _distance) {
		this._distance = _distance;
	}

	/**
	 * @param _light the _light to set
	 */
	public void set_light(AmbientLight _light) {
		this._light = _light;
	}
	
}
