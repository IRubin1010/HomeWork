package primitives;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Ray {

	private Point3D _point;
	private Vector _direction;

	/***************** Constructors **********************/

	public Ray(Point3D point, Vector vector) {
		_point = new Point3D(point);
		_direction = new Vector(vector);
	}

	public Ray(Ray other) {
		_point = new Point3D(other._point);
		_direction = new Vector(other._direction);
	}

	/***************** Getters **********************/

	public Point3D getPoint() {
		return _point;
	}

	public Vector grtDirection() {
		return _direction;
	}

	/***************** Administration *******************/

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

	@Override
	public String toString() {
		return _point.toString() + " -> " + _direction.toString();
	}

}
