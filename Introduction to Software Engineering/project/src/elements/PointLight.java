/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
 
package elements;

import primitives.*;

/**
 *class represents point light
 */
public class PointLight extends Light implements LightSource{
	Point3D _position;
	double _Kc, _Ki, _kq; 
	
	public PointLight(Point3D position, double Ki, double Kq, Color color) {
		super(color);
		_position = new Point3D(position);
		_Kc = 1;
		_Ki = Ki;
		_kq = Kq;
	}
	
	/**
	 * get intensity
	 * @return the ambient light
	 */
	public Color getIntensity(Point3D point) {
		double distanceFromPoint = _position.distanceFrom(point);
		double k = _Kc + _Ki*distanceFromPoint + _kq*distanceFromPoint*distanceFromPoint;
		return getIntensity().reduce(k);
	}
	
	/**
	 * get L
	 * @param point
	 * @return Vector from light position to the point on the geometry 
	 */
	public Vector getL(Point3D point) {
		return new Vector(point.vectorSubtract(_position)).normalize();
	}
	
	/**
	 * get direction
	 * @param point
	 * @return vector of the light direction
	 */
	public Vector getD(Point3D point) {
		return getL(point);
	}


}
