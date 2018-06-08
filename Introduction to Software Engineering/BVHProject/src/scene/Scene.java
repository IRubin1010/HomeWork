/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package scene;

//import java.awt.Color;
import java.util.ArrayList;
import java.util.List;

import lights.*;
import elements.*;
import geometries.*;
import primitives.*;

/**
 * class that represents a scene
 */
public class Scene {

	private String _name;
	private Color _backgroundColor;
	private Geometries _geometries;
	private Camera _camera;
	private double _distance;
	private AmbientLight _ambientLight;
	private List<LightSource> _lights;

	/***************** Constructors **********************/

	/**
	 * default constructor with name
	 * 
	 * @param name name of the scene
	 */
	public Scene(String name) {
		this._name = name;
	}

	/**
	 * copy constructor
	 * @param scene other
	 */
	public Scene(Scene scene) {
		_name = scene._name;
		_backgroundColor = scene._backgroundColor;
		_geometries = scene._geometries;
		_camera = new Camera(scene._camera);
		_distance = scene._distance;
		_ambientLight = scene.getAmbientlight();
		_lights = scene.getLights();
	}

	/***************** Getters ****************************/

	/**
	 * @return the background color
	 */
	public Color getBackground() {
		return _backgroundColor;
	}

	/**
	 * @return the camera
	 */
	public Camera getCamera() {
		return _camera;
	}

	/**
	 * @return the distance between camera and view plane
	 */
	public double getDistance() {
		return _distance;
	}

	/**
	 * @return the geometries list
	 */
	public Geometries getGeometries() {
		return _geometries;
	}

	/**
	 * @return the ambient light
	 */
	public AmbientLight getAmbientlight() {
		return _ambientLight;
	}

	/**
	 * @return the list of the light sources
	 */
	public List<LightSource> getLights() {
		return _lights;
	}

	/***************** Setters ****************************/

	/**
	 * @param geometries geometries object
	 */
	public void setGeometries(Geometries geometries) {
		this._geometries = geometries;
	}

	/**
	 * @param background color of the background
	 */
	public void setBackground(Color background) {
		this._backgroundColor = background;
	}

	/**
	 * @param camera the camera of the scene
	 */
	public void setCamera(Camera camera) {
		this._camera = camera;
	}

	/**
	 * @param distance distance between camera and vie plan
	 */
	public void setDistance(double distance) {
		this._distance = distance;
	}

	/**
	 * @param light the ambient light of the scene
	 */
	public void setAmbientLight(AmbientLight light) {
		this._ambientLight = light;
	}

	/**
	 * @param lights list of the light sources
	 */
	public void setLights(List<LightSource> lights) {
		this._lights = lights;
	}

}
