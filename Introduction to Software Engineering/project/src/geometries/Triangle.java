/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
 * class represent triangle
 */
public class Triangle extends Plane {

	private Point3D _p1;
	private Point3D _p2;
	private Point3D _p3;

	/***************** Constructors **********************/

	/**
	 * constructor with 3 points
	 * 
	 * @param p1
	 * @param p2
	 * @param p3
	 */
	public Triangle(Point3D p1, Point3D p2, Point3D p3) {
		super(p1, p2, p3, new Color(255,255,255));
		_p1 = new Point3D(p1);
		_p2 = new Point3D(p2);
		_p3 = new Point3D(p3);
	}

	/**
	 * copy constructor
	 * 
	 * @param other
	 */
	public Triangle(Triangle other) {
		super(other);
		_p1 = new Point3D(other._p1);
		_p2 = new Point3D(other._p2);
		_p3 = new Point3D(other._p3);
	}
	
	/***************** Operations ************************/

	/**
	 * function find Intersections
	 * 
	 * @param ray
	 * @return list of points of the intersection
	 */
	public List<Point3D> findIntersections(Ray ray) {
		// get plane intersection
		List<Point3D> planeIntersection = super.findIntersections(ray);
		if (planeIntersection.isEmpty())
			return planeIntersection;

		Point3D P0 = ray.getPoint();
		
		// V1,V2,V3
		Vector V1 = _p1.vectorSubtract(P0);
		Vector V2 = _p2.vectorSubtract(P0);
		Vector V3 = _p3.vectorSubtract(P0);

		// N1,N2,N3
		Vector N1 = V1.crossProduct(V2);
		Vector N2 = V2.crossProduct(V3);
		Vector N3 = V3.crossProduct(V1);

		// P0P * Ni
		Vector P0P = planeIntersection.get(0).vectorSubtract(P0);
		double P0PN1 = P0P.dotProduct(N1);
		double P0PN2 = P0P.dotProduct(N2);
		double P0PN3 = P0P.dotProduct(N3);
		if (!(P0PN1 > 0 && P0PN2 > 0 && P0PN3 > 0
				|| P0PN1 < 0 && P0PN2 < 0 && P0PN3 < 0))
			planeIntersection.clear();

		return planeIntersection;
	}

}
