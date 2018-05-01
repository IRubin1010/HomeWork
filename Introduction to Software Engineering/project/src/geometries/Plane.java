/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;

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
	 * @param x
	 * @param y
	 * @param z
	 */
	public Plane(Point3D x, Point3D y, Point3D z) {
		try {
			// if 2 points are the same point
			// the vactor substract will be 0
			// and exception will thrown
			Vector Vector1 = new Vector(y.vectorSubtract(x));
			Vector Vector2 = new Vector(z.vectorSubtract(x));
			try {
				// if all points are on the same line
				// cross product will be 0
				// and exception will thrown
				Vector1.crossProduct(Vector2);
			} catch (IllegalArgumentException e) {
				// case all points are on the same line
				throw new IllegalArgumentException("all 3 points are on the same line");
			}
			_point = new Point3D(x);
			_plumb = new Vector(Vector1.crossProduct(Vector2));
		} catch (IllegalArgumentException e) {
			// case 2 points are the same
			if (e.getMessage() == "all 3 points are on the same line")
				throw new IllegalArgumentException("all 3 points are on the same line");// FIX
			throw new IllegalArgumentException("There is 2 same points");
		}
	}

	/**
	 * constructor with point and plumb
	 * 
	 * @param point
	 * @param plumb
	 */
	public Plane(Point3D point, Vector plumb) {
		_point = new Point3D(point);
		_plumb = new Vector(plumb);
	}

	/**
	 * copy constructor
	 * 
	 * @param other
	 */
	public Plane(Plane other) {
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
		return new Vector(_plumb).normalize();
	}

	/**
	 * function find Intersections
	 * @param ray
	 * @return list of points of the intersection
	 */
	@Override
	public ArrayList<Point3D> findIntersections(Ray ray) {
		try {
			ArrayList<Point3D> list = new ArrayList<Point3D>();
			Point3D rayPoint = ray.getPoint();
			Vector rayVector = ray.getDirection();
			// Q0 - P0
			Vector Q0P0 = _point.vectorSubtract(rayPoint);
			// N * (Q0 - P0)
			Coordinate N_dot_Q0P0 = _plumb.dotProduct(Q0P0);
			if (N_dot_Q0P0.equals(Coordinate.zeroCoordinate)) {
				// means the ray point is on the plane
				// no intersection
				return null;
			}
			// V * N
			Coordinate VN = _plumb.dotProduct(rayVector);
			if (VN.equals(Coordinate.zeroCoordinate)) {
				// V and N are orthogonal
				// means the ray is parallel to the plane
				return null; 
			}
			// t = N_dot_Q0P0/VN
			double t = N_dot_Q0P0.coordinateDivide(VN).getValue();
			if (t > 0) {
				// point = P0 + t*V
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t)));
				return list;
			} else {
				return null; 
			}
		} catch (IllegalArgumentException e) {
			// case both points are the same
			// the sub is vector 0
			// the intersection is the plane point
			// means - no intersection
			return null;
		}
	}
}
