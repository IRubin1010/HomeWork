/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.List;
import java.util.Map;

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
	 * @param a point a
	 * @param b point b
	 * @param c point c
	 * @param color emission color of the triangle
	 * @param material material of the triangle
	 */
	public Triangle(Point3D a, Point3D b, Point3D c, Color color, Material material) {
		super(a, b, c, color,material);
		_p1 = new Point3D(a);
		_p2 = new Point3D(b);
		_p3 = new Point3D(c);
		setMinMax();
	}

	/**
	 * copy constructor
	 * @param other triangle
	 */
	public Triangle(Triangle other) {
		super(other);
		_p1 = new Point3D(other._p1);
		_p2 = new Point3D(other._p2);
		_p3 = new Point3D(other._p3);
		setMinMax();
	}

	/***************** Operations ************************/

	/* (non-Javadoc)
	 * @see geometries.Plane#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		// get plane intersection
		Map<Geometry, List<Point3D>> planeIntersection = super.findIntersections(ray);
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
		Vector P0P = planeIntersection.get(this).get(0).vectorSubtract(P0);
		double P0PN1 = P0P.dotProduct(N1);
		double P0PN2 = P0P.dotProduct(N2);
		double P0PN3 = P0P.dotProduct(N3);
		if (!(P0PN1 > 0 && P0PN2 > 0 && P0PN3 > 0
				|| P0PN1 < 0 && P0PN2 < 0 && P0PN3 < 0))
			planeIntersection.clear();

		return planeIntersection;
	}

	/* (non-Javadoc)
	 * @see geometries.BoundinBox#calcMinMax()
	 */
	@Override
	protected void setMinMax() {
		
		double p1X = _p1.getX().getValue();
		double p1Y = _p1.getY().getValue();
		double p1Z = _p1.getZ().getValue();
		
		double p2X = _p2.getX().getValue();
		double p2Y = _p2.getY().getValue();
		double p2Z = _p2.getZ().getValue();
		
		double p3X = _p3.getX().getValue();
		double p3Y = _p3.getY().getValue();
		double p3Z = _p3.getZ().getValue();
		
		minX = getMin(p1X, p2X, p3X);
		maxX = getMax(p1X, p2X, p3X);
		
		minY = getMin(p1Y, p2Y, p3Y);
		maxY = getMax(p1Y, p2Y, p3Y);
		
		minZ = getMin(p1Z, p2Z, p3Z);
		maxZ = getMax(p1Z, p2Z, p3Z);
	}
	
	
	

}
