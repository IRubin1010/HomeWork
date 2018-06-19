/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import primitives.Color;
import primitives.Coordinate;
import primitives.Material;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;

/**
 * class represents rectangle
 */
public class Rectangle extends Plane {

	Point3D _a;
	Point3D _b;
	Point3D _c;
	Point3D _d;

	/***************** Constructors **********************/

	/**
	 * constructor
	 * 
	 * @param a
	 *            point a
	 * @param b
	 *            point b
	 * @param c
	 *            point c
	 * @param d
	 *            point d
	 * @param color
	 *            emission color of the plane
	 * @param material
	 *            material of the plane
	 */
	public Rectangle(Point3D a, Point3D b, Point3D c, Point3D d, Color color, Material material) {
		super(a, b, c, color, material);
		_a = new Point3D(a);
		_b = new Point3D(b);
		_c = new Point3D(c);
		_d = new Point3D(d);
		setMinMax();
		Vector ab = _b.vectorSubtract(_a);
		Vector ac = _c.vectorSubtract(_a);
		if (!Coordinate.ZERO.equals(ab.dotProduct(ac))) {
			throw new IllegalArgumentException("ab is not orthogonal to ac");
		}
	}

	/***************** Operations ************************/

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.Plane#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> planeIntersection = new HashMap<Geometry, List<Point3D>>();
		if (isIntersectedBox(ray)) {

			// get plane intersections
			planeIntersection = super.findIntersections(ray);

			if (planeIntersection.isEmpty())
				return planeIntersection;

			List<Point3D> intersectionList = planeIntersection.entrySet().iterator().next().getValue();
			// the point is inside the rectangle if (0 < PA * AB < AB * AB) AND (0 < PA * AC
			// < AC * AC)
			Vector AB = _b.vectorSubtract(_a);
			Vector AC = _c.vectorSubtract(_a);

			if (intersectionList.get(0).equals(_a))
				return planeIntersection;

			Vector PA = intersectionList.get(0).vectorSubtract(_a);
			double u = PA.dotProduct(AB);
			double v = PA.dotProduct(AC);
			if (!(u >= 0.0 && u <= AB.dotProduct(AB) && v >= 0.0 && v <= AC.dotProduct(AC)))
				planeIntersection.clear();
		}

		return planeIntersection;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.BoundinBox#setMinMax()
	 */
	@Override
	protected void setMinMax() {

		double p1X = _a.getX().getValue();
		double p1Y = _a.getY().getValue();
		double p1Z = _a.getZ().getValue();

		double p2X = _b.getX().getValue();
		double p2Y = _b.getY().getValue();
		double p2Z = _b.getZ().getValue();

		double p3X = _c.getX().getValue();
		double p3Y = _c.getY().getValue();
		double p3Z = _c.getZ().getValue();

		double p4X = _d.getX().getValue();
		double p4Y = _d.getY().getValue();
		double p4Z = _d.getZ().getValue();

		minX = getMin(p1X, p2X, p3X, p4X);
		maxX = getMax(p1X, p2X, p3X, p4X);

		minY = getMin(p1Y, p2Y, p3Y, p4Y);
		maxY = getMax(p1Y, p2Y, p3Y, p4Y);

		minZ = getMin(p1Z, p2Z, p3Z, p4Z);
		maxZ = getMax(p1Z, p2Z, p3Z, p4Z);

	}

	/**
	 * return the minimum number between 4 number
	 * 
	 * @param n1
	 * @param n2
	 * @param n3
	 * @param n4
	 * @return the minimum number
	 */
	protected double getMin(double n1, double n2, double n3, double n4) {
		double min = super.getMin(n1, n2, n3);
		if (n4 < min)
			return n4;
		return min;
	}

	/**
	 * return the maximum number between 4 number
	 * 
	 * @param n1
	 * @param n2
	 * @param n3
	 * @param n4
	 * @return the maximum number
	 */
	protected double getMax(double n1, double n2, double n3, double n4) {
		double max = super.getMax(n1, n2, n3);
		if (n4 > max)
			return n4;
		return max;
	}

}
