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
 * class represent sphere
 */
public class Sphere extends RadialGeometry {

	private Point3D _point;

	/***************** Constructors **********************/

	/**
	 * constructor with point and radius
	 * 
	 * @param point the middle point of the sphere
	 * @param radius the radius of the sphere
	 * @param color emission color of the sphere
	 * @param material material of the sphere
	 */

	public Sphere(Point3D point, double radius, Color color, Material material) {
		super(radius, color, material);
		_point = new Point3D(point);
	}

	/**
	 * copy constructor
	 * @param other sphere
	 */
	public Sphere(Sphere other) {
		super(other);
		_point = new Point3D(other._point);
	}

	/***************** Operations ************************/
	
	/* (non-Javadoc)
	 * @see geometries.Geometry#getNormal(primitives.Point3D)
	 */
	@Override
	public Vector getNormal(Point3D point) {
		// vector from the center point to other point
		return point.vectorSubtract(_point).normalize();
	}

	/* (non-Javadoc)
	 * @see geometries.Intersectable#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> intersections = new HashMap<>();
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
			intersections.put(this, list);
			return intersections;
		}

		// tm = u * v
		double tm = u.dotProduct(rayVector);
		// d = sqrt(|U|^2 - tm^2)
		double d = Math.sqrt(u.dotProduct(u) - tm * tm);
		// if d > 0 - no intersection
		if (d > _radius)
			return intersections;
		// th = sqrt(r^2 - d^2)
		double th = Math.sqrt(_radius * _radius - d * d);
		if (Coordinate.ZERO.equals(th)) {
			if (tm > 0) {
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(tm)));
			}
		} else {
			double t1 = tm + th;
			double t2 = tm - th;
			if (t1 > 0 && !Coordinate.ZERO.equals(t1)) {
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t1)));
			}
			if (t2 > 0 && !Coordinate.ZERO.equals(t2)) {
				list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t2)));
			}
		}
		if (!list.isEmpty()) {
			intersections.put(this, list);
		}
		return intersections;
	}
	

}
