/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
 * class represent sphere
 */
public class Sphere extends RadialGeometry {

	private Point3D _point;

	/***************** Constructors **********************/

	/**
	 * constructor with point and radius
	 * 
	 * @param point
	 * @param radius
	 * @param color
	 *            TODO
	 */
	public Sphere(Point3D point, Coordinate radius, Color color) {
		super(radius, color);
		_point = new Point3D(point);
	}

	/**
	 * copy constructor
	 * 
	 * @param other
	 */
	public Sphere(Sphere other) {
		super(other);
		_point = new Point3D(other._point);
	}

	/***************** Getter ****************************/

	/**
	 * @return the _point
	 */
	public Point3D get_point() {
		return _point;
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
		if (!(obj instanceof Sphere))
			return false;
		if (!super.equals(obj))
			return false;
		Sphere other = (Sphere) obj;
		return _point.equals(other._point);
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "Sphere: \npoint: " + _point.toString() + " ," + super.toString();
	}

	/***************** Operations ************************/

	/**
	 * return normal from a point on the sphere
	 * 
	 * @param point
	 *            on the sphere
	 */
	public Vector getNormal(Point3D point) {
		// vector from the center point to other point
		return point.vectorSubtract(_point).normalize();
	}

	/**
	 * function find Intersections
	 * 
	 * @param ray
	 * @return list of points of the intersection
	 */
	public List<Point3D> findIntersections(Ray ray) {
		List<Point3D> list = new ArrayList<>();
		Point3D rayPoint = ray.getPoint();
		Vector rayVector = ray.getDirection();
		Vector u;
		try {
			// u = O - P0
			u = _point.vectorSubtract(rayPoint);
		} catch (IllegalArgumentException e) {
			// case P0 is same as _point
			// U = 0, tm = 0, d = 0, th = radius
			// intersection = Po + t*V
			list.add(_point.addVectorToPoint(rayVector.scaleVector(_radius)));
			return list;
		}

		// tm = u * v
		double tm = u.dotProduct(rayVector);
		// d = sqrt(|U|^2 - tm^2)
		double d = Math.sqrt(u.dotProduct(u) - tm * tm);
		// if d > 0 - no intersection
		if (d > _radius)
			return list;
		// th = sqrt(r^2 - d^2)
		double th = Math.sqrt(_radius * _radius - d * d);
		if (Coordinate.ZERO.equals(th)) {
			if (tm > 0)
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(tm)));
		} else {
			double t1 = tm + th;
			double t2 = tm - th;
			if (t1 > 0)
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t1)));
			if (t2 > 0)
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t2)));
		}
		return list;
	}
}
