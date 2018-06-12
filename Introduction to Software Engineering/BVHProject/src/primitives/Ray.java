/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package primitives;

/**
 * class represents Ray
 *
 */
public class Ray {

	private Point3D _point;
	private Vector _direction;

	/***************** Constructors **********************/

	/**
	 * constructor with point and vector parameters
	 * @param point the begin point of the ray
	 * @param vector the direction of the ray
	 */
	public Ray(Point3D point, Vector vector) {
		_point = new Point3D(point);
		_direction = new Vector(vector).normalize();
	}

	/**
	 * copy constructor
	 * @param other ray
	 */
	public Ray(Ray other) {
		_point = new Point3D(other._point);
		_direction = new Vector(other._direction).normalize();
	}

	/***************** Getters **********************/

	/**
	 * get point
	 * @return the ray begin point
	 */
	public Point3D getPoint() {
		return _point;
	}

	/**
	 * get direction
	 * @return the ray direction
	 */
	public Vector getDirection() {
		return _direction;
	}

	/***************** Administration *******************/

	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (obj == null)
			return false;
		if (obj == this)
			return true;
		if (!(obj instanceof Ray))
			return false;
		Ray other = (Ray) obj;
		return _point.equals(other._point) && _direction.equals(other._direction);
	}

	/**
	 * override to string
	 */
	@Override
	public String toString() {
		return _point.toString() + " -> " + _direction.toString();
	}

}
