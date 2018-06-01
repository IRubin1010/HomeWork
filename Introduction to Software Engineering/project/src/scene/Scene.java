/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package scene;

//import java.awt.Color;
import java.util.ArrayList;
import java.util.List;

import elements.*;
import geometries.*;
import primitives.*;

/**
 * class that represents a scene
 */
public class Scene {

	private String _name;
	private Color _background;
	private Geometries _geometries = new Geometries();
	private Camera _camera;
	private double _distance;
	private AmbientLight _ambientLight;
	List<LightSource> _lights;

	/***************** Constructors **********************/

	/**
	 * default constructor with name
	 * 
	 * @param name
	 *            - name of the scene put default values Other variables
	 */
	public Scene(String name) {
		this._name = name;
	}

	/**
	 * copy constructor
	 * 
	 * @param scene
	 */
	public Scene(Scene scene) {
		_name = scene._name;
		_background = scene._background;
		_geometries = scene._geometries;
		_camera = new Camera(scene._camera);
		_distance = scene._distance;
		_ambientLight = scene.get_ambientlight();
		_lights = scene.get_lights();
	}

	/***************** Getters ****************************/

	/**
	 * @return the _color
	 */
	public Color get_background() {
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
	public AmbientLight get_ambientlight() {
		return _ambientLight;
	}

	/**
	 * @return the _lights
	 */
	public List<LightSource> get_lights() {
		return _lights;
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
	public void set_background(Color backGround) {
		this._background = backGround;
	}

	/**
	 * @param _camera
	 *            the _camera to set
	 */
	public void set_camera(Camera camera) {
		this._camera = camera;
	}

	/**
	 * @param _distance
	 *            the _distance to set
	 */
	public void set_distance(double distance) {
		this._distance = distance;
	}

	/**
	 * @param _light
	 *            the _light to set
	 */
	public void set_ambientlight(AmbientLight light) {
		this._ambientLight = light;
	}

	/**
	 * @param _lights
	 *            the _lights to set
	 */
	public void set_lights(List<LightSource> lights) {
		this._lights = lights;
	}

}
