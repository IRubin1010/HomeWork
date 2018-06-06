/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package elements;

import primitives.*;

/**
 * class represents Directional light
 */
public class DirectionalLight extends Light implements LightSource{
	
	Vector _direction;

	/***************** Constructors **********************/

	/**
	 * constructor
	 * @param direction
	 * @param color
	 */
	public DirectionalLight(Vector direction, Color color) {
		super(color);
		_direction = new Vector(direction);
	}

	/***************** Operations ************************/

	/**
	 * get intensity
	 * @return the direction light
	 */
	public Color getIntensity(Point3D point) {
		return new Color(_color);
	}
	
	/**
	 * get L
	 * @param point
	 * @return Vector from light position to the point on the geometry 
	 */
	public Vector getL(Point3D point) {
		return new Vector(_direction).normalize();
	}
	
	/**
	 * get direction
	 * @param point
	 * @return vector of the light direction
	 */
	public Vector getD(Point3D point) {
		return new Vector(_direction).normalize();
	}

}
