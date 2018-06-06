/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package elements;

import primitives.*;

/**
 * class represents spot light
 */
public class SpotLight extends PointLight {
	
	Vector _direction;
	
	/***************** Constructor **********************/

	public SpotLight(Vector direction, Point3D position, double Ki, double Kq, Color color) {
		super(position, Ki, Kq, color);
		_direction = new Vector(direction);
	}

	/***************** Operations ************************/

	/**
	 * get intensity
	 * @return the ambient light
	 */
	public Color getIntensity(Point3D point) {
		double angelBetweenDirectionAndL = getD(point).dotProduct(getL(point));
		return super.getIntensity(point).scale(angelBetweenDirectionAndL);
	}
	
	/**
	 * get L
	 * @param point
	 * @return Vector from light position to the point on the geometry 
	 */
	public Vector getL(Point3D point) {
		return point.vectorSubtract(_position).normalize();
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
