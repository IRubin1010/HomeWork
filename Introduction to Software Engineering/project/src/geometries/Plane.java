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

	protected Point3D _point;
	protected Vector _normal;

	/***************** Constructors **********************/
	/**
	 * constructor with 3 points
	 * 
	 * @param a
	 * @param b
	 * @param c
	 * @param color
	 */
	public Plane(Point3D a, Point3D b, Point3D c, Color color) {
		super(color);
		Vector vector1, vector2;
		try {
			// if 2 points are the same point
			// the vector substract will be 0
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
			_normal = vector1.crossProduct(vector2).normalize();
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
		_normal = new Vector(plumb).normalize();
	}

	/**
	 * copy constructor
	 * 
	 * @param other
	 */
	public Plane(Plane other) {
		super(other);
		_point = new Point3D(other._point);
		_normal = new Vector(other._normal);
	}

	/***************** Operations ************************/

	/**
	 * return normal from a point on the plane
	 * 
	 * @param point
	 *            on the plane
	 */
	public Vector getNormal(Point3D point) {
		return _normal;
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
			// N * (Q0 - P0)
			double N_dot_Q0P0 = _normal.dotProduct(Q0P0);
			if (Coordinate.ZERO.equals(N_dot_Q0P0)) {
				// means the ray point is on the plane
				// no intersection
				return list;
			}
			// V * N
			double VN = _normal.dotProduct(rayVector);
			if (Coordinate.ZERO.equals(VN)) {
				// V and N are orthogonal
				// means the ray is parallel to the plane
				return list; 
			}
			// t = N_dot_Q0P0/VN
			double t = N_dot_Q0P0 / VN;
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
