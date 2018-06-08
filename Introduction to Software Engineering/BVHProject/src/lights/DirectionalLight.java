/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package lights;

import primitives.*;

/**
 * class represents Directional light
 */
public class DirectionalLight extends Light implements LightSource{
	
	Vector _direction;

	/***************** Constructors **********************/

	/**
	 * constructor
	 * @param direction direction of the light
	 * @param color the color of the light
	 */
	public DirectionalLight(Vector direction, Color color) {
		super(color);
		_direction = new Vector(direction);
	}

	/***************** Operations ************************/

	/* (non-Javadoc)
	 * @see lights.LightSource#getIntensity(primitives.Point3D)
	 */
	@Override
	public Color getIntensity(Point3D point) {
		return getIntensity();
	}

	/* (non-Javadoc)
	 * @see lights.LightSource#getL(primitives.Point3D)
	 */
	@Override
	public Vector getL(Point3D point) {
		return new Vector(_direction).normalize();
	}

	/* (non-Javadoc)
	 * @see lights.LightSource#getD(primitives.Point3D)
	 */
	@Override
	public Vector getD(Point3D point) {
		return new Vector(_direction).normalize();
	}

	/* (non-Javadoc)
	 * @see lights.LightSource#getDistance(primitives.Point3D)
	 */
	@Override
	public double getDistance(Point3D point) {
		return Double.MAX_VALUE;
	}



}


