/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
 * class represent plane
 */
public class Plane extends Geometry {

	private Point3D _point;
	private Vector _plumb;

	/***************** Constructors **********************/
	/**
	 * constructor with 3 points
	 * 
	 * @param a
	 * @param b
	 * @param c
	 * @param color
	 *            TODO
	 */
	public Plane(Point3D a, Point3D b, Point3D c, Color color) {
		super(color);
		Vector vector1, vector2;
		try {
			// if 2 points are the same point
			// the vactor substract will be 0
			// and exception will thrown
			vector1 = new Vector(b.vectorSubtract(a));
			vector2 = new Vector(c.vectorSubtract(a));
		} catch (IllegalArgumentException e) {
			// case 2 points are the same
			throw new IllegalArgumentException("There are 2 equal points");
		}
		try {
			// if all points are on the same line
			// cross product will be 0
			// and exception will thrown
			_plumb = vector1.crossProduct(vector2).normalize();
		} catch (IllegalArgumentException e) {
			// case all points are on the same line
			throw new IllegalArgumentException("all 3 points are on the same line");
		}
		_point = new Point3D(a);
	}

	/**
	 * constructor with point and plumb
	 * 
	 * @param point
	 * @param plumb
	 * @param color
	 *            TODO
	 */
	public Plane(Point3D point, Vector plumb, Color color) {
		super(color);
		_point = new Point3D(point);
		_plumb = new Vector(plumb).normalize();
	}

	/**
	 * copy constructor
	 * 
	 * @param other
	 */
	public Plane(Plane other) {
		super(other);
		_point = new Point3D(other._point);
		_plumb = new Vector(other._plumb);
	}

	/***************** Getters ****************************/

	/**
	 * @return the _point
	 */
	public Point3D get_point() {
		return _point;
	}

	/**
	 * @return the _plumb
	 */
	public Vector get_plumb() {
		return _plumb;
	}

	/***************** Administration *******************/

	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Plane))
			return false;
		Plane other = (Plane) obj;
		return _point.equals(other._point) && _plumb.equals(other._plumb);
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "Plane: \npoint: " + _point.toString() + " ,plumb: " + _plumb.toString();
	}

	/***************** Operations ************************/

	/**
	 * return normal from a point on the plane
	 * 
	 * @param point
	 *            on the plane
	 */
	public Vector getNormal(Point3D point) {
		return _plumb;
	}

	/**
	 * function find Intersections
	 * 
	 * @param ray
	 * @return list of points of the intersection
	 */
	@Override
	public List<Point3D> findIntersections(Ray ray) {
		List<Point3D> list = new ArrayList<Point3D>();
		try {
			Point3D rayPoint = ray.getPoint();
			Vector rayVector = ray.getDirection();
			// Q0 - P0
			Vector Q0P0 = _point.vectorSubtract(rayPoint);

			// V * N
			double VN = _plumb.dotProduct(rayVector);
			if (Coordinate.ZERO.equals(VN)) {
				// V and N are orthogonal
				// means the ray is parallel to the plane
				return list;
			}
			
			// N * (Q0 - P0)
			double t = _plumb.dotProduct(Q0P0);
			if (Coordinate.ZERO.equals(t)) {
				// means the ray point is on the plane
				// no intersection
				return list;
			}
			if (t > 0) {
				// point = P0 + t*V
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t)));
				return list;
			} else {
				return list;
			}
		} catch (IllegalArgumentException e) {
			// case both points are the same
			// the sub is vector 0
			// the intersection is the plane point
			// means - no intersection
			return list;
		}
	}
}
