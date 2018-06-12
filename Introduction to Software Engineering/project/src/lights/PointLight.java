/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
 
package lights;

import primitives.*;

/**
 *class represents point light
 */
public class PointLight extends Light implements LightSource{
	
	Point3D _position;
	double _Kc, _Ki, _kq; 
	
	/***************** Constructor **********************/

	/**
	 * Constructor
	 * @param position position of the light in scene
	 * @param Kl linear factor
	 * @param Kq quadratic factor
	 * @param color of the light
	 */
	public PointLight(Point3D position, double Ki, double Kq, Color color) {
		super(color);
		_position = new Point3D(position);
		_Kc = 1;
		_Ki = Ki;
		_kq = Kq;
	}
	
	/***************** Operations ************************/

	/* (non-Javadoc)
	 * @see lights.LightSource#getIntensity(primitives.Point3D)
	 */
	@Override
	public Color getIntensity(Point3D point) {
		double distanceFromPoint = _position.distanceFrom(point);
		double k = _Kc + _Ki*distanceFromPoint + _kq*distanceFromPoint*distanceFromPoint;
		return getIntensity().reduce(k);
	}
	
	/* (non-Javadoc)
	 * @see lights.LightSource#getL(primitives.Point3D)
	 */
	@Override
	public Vector getL(Point3D point) {
		return point.vectorSubtract(_position).normalize();
	}

	
	/* (non-Javadoc)
	 * @see lights.LightSource#getD(primitives.Point3D)
	 */
	@Override
	public Vector getD(Point3D point) {
		return getL(point);
	}

	/* (non-Javadoc)
	 * @see lights.LightSource#getDistance(primitives.Point3D)
	 */
	@Override
	public double getDistance(Point3D point) {
		return point.distanceFrom(_position);
	}
	
}
