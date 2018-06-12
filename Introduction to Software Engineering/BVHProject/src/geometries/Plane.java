/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import primitives.*;

/**
 * class represent plane
 */
public abstract class Plane extends Geometry {

	protected Point3D _point;
	protected Vector _normal;

	/***************** Constructors **********************/
	
	/**
	 * constructor with 3 points
	 * @param a point a
	 * @param b point b
	 * @param c point c 
	 * @param color emission color of the plane
	 * @param material material of the plane
	 */
	public Plane(Point3D a, Point3D b, Point3D c, Color color, Material material) {
		super(color, material);
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
	 * constructor with point and normal
	 * @param point point on the plane
	 * @param normal normal to the plane
	 * @param color emission color of the plane
	 * @param material material of the plane
	 */
	public Plane(Point3D point, Vector normal, Color color, Material material) {
		super(color, material);
		_point = new Point3D(point);
		_normal = new Vector(normal).normalize();
	}

	/**
	 * copy constructor
	 * @param other plane
	 */
	public Plane(Plane other) {
		super(other);
		_point = new Point3D(other._point);
		_normal = new Vector(other._normal);
	}

	/***************** Operations ************************/
	
	/* (non-Javadoc)
	 * @see geometries.Geometry#getNormal(primitives.Point3D)
	 */
	@Override
	public Vector getNormal(Point3D point) {
		return _normal;
	}

	/* (non-Javadoc)
	 * @see geometries.Intersectable#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> intersections=new HashMap<>();
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
				return intersections;
			}
			// V * N
			double VN = _normal.dotProduct(rayVector);
			if (Coordinate.ZERO.equals(VN)) {
				// V and N are orthogonal
				// means the ray is parallel to the plane
				return intersections; 
			}
			// t = N_dot_Q0P0/VN
			double t = N_dot_Q0P0 / VN;
			if (t > 0) {
				// point = P0 + t*V
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t)));
				intersections.put(this,list);
				return intersections;
			} else {
				return intersections; 
			}
		} catch (IllegalArgumentException e) {
			// case both points are the same
			// the sub is vector 0
			// the intersection is the plane point
			// means - no intersection
			return intersections;
		}
	}
	
	/**
	 * return the minimum number between 3 number
	 * @param n1
	 * @param n2
	 * @param n3
	 * @return the minimum number
	 */
	protected double getMin(double n1, double n2, double n3) {
		if(n1 > n2) {
			if(n2 > n3)
				return n3;
			else
				return n2;
		}else {
			if(n1 > n3)
				return n3;
			else
				return n1;
		}
	}
	
	/**
	 * return the maximum number between 3 number
	 * @param n1
	 * @param n2
	 * @param n3
	 * @return the maximum number
	 */
	protected double getMax(double n1, double n2, double n3) {
		if(n1 > n2) {
			if(n3 > n1)
				return n3;
			else
				return n1;
		}else {
			if(n3 > n2)
				return n3;
			else
				return n2;
		}
	}

	

}
