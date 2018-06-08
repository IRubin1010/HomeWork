/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package lights;

import primitives.*;

/**
 * class represents spot light
 */
public class SpotLight extends PointLight {
	
	Vector _direction;
	
	/***************** Constructor **********************/

	/**
	 * Constructor
	 * @param direction direction of the spot
	 * @param position position of the light in scene
	 * @param Kl linear factor
	 * @param Kq quadratic factor
	 * @param color of the light
	 */
	public SpotLight(Vector direction, Point3D position, double Ki, double Kq, Color color) {
		super(position, Ki, Kq, color);
		_direction = new Vector(direction);
	}

	/***************** Operations ************************/

	/* (non-Javadoc)
	 * @see lights.PointLight#getIntensity(primitives.Point3D)
	 */
	@Override
	public Color getIntensity(Point3D point) {
		double angelBetweenDirectionAndL = getD(point).dotProduct(getL(point));
		return super.getIntensity(point).scale(angelBetweenDirectionAndL);
	}
	
	/* (non-Javadoc)
	 * @see lights.PointLight#getL(primitives.Point3D)
	 */
	@Override
	public Vector getL(Point3D point) {
		return point.vectorSubtract(_position).normalize();
	}

	/* (non-Javadoc)
	 * @see lights.PointLight#getD(primitives.Point3D)
	 */
	@Override
	public Vector getD(Point3D point) {
		return new Vector(_direction).normalize();
	}

	
}
