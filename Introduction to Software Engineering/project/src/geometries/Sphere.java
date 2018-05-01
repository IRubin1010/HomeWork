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
	 * @param point
	 * @param radius
	 */
	public Sphere(Point3D point, Coordinate radius) {
		super(radius);
		_point = new Point3D(point);
	}

	/**
	 * copy constructor
	 * @param other
	 */
	public Sphere(Sphere other) {
		super(other.getRadius());
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
	 * @param point on the sphere
	 */
	public Vector getNormal(Point3D point){
		// vector from the center point to other point
		return new Vector(point.vectorSubtract(_point)).normalize();
	}
	
	public ArrayList<Point3D> findIntersection(Ray ray){
		ArrayList<Point3D> list = new ArrayList<Point3D>();
		Point3D rayPoint = ray.getPoint();
		Vector rayVector = ray.getDirection().normalize();
		Vector U = _point.vectorSubtract(rayPoint); //////check if the same point
		double tm = U.dotProduct(rayVector).getValue();
		double d = Math.sqrt(U.dotProduct(U).getValue() - Math.pow(tm, 2));
		if(d > getRadius().getValue()) return null;
		double th = Math.sqrt(Math.pow(getRadius().getValue(), 2) - Math.pow(d, 2));
		double t1 = tm + th;
		double t2 = tm - th;
		if(t1 >= 0) list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t1)));
		if(t2 >= 0) list.add(rayPoint.addVectorToPoint(rayVector.scaleVector(t2)));
		return list;
	}
}
