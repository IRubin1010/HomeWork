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
	 * @param color
	 *            emission color of the plane
	 * @param material
	 *            material of the plane
	 */
	public Rectangle(Point3D a, Point3D b, Point3D c, Color color, Material material) {
		super(a, b, c, color, material);
		_a = new Point3D(a);
		_b = new Point3D(b);
		_c = new Point3D(c);
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
		// get plane intersections
		Map<Geometry, List<Point3D>> planeIntersection = super.findIntersections(ray);
		
		if (planeIntersection.isEmpty())
            return planeIntersection;

        List<Point3D> intersectionList = planeIntersection.entrySet().iterator().next().getValue();
        //the point is inside the rectangle if (0 < PA * AB < AB * AB) AND (0 < PA * AC < AC * AC)
        Vector AB = _b.vectorSubtract(_a);
        Vector AC = _c.vectorSubtract(_a);

        if(intersectionList.get(0).equals(_a))
            return planeIntersection;

        Vector PA = intersectionList.get(0).vectorSubtract(_a);
        double u = PA.dotProduct(AB);
        double v = PA.dotProduct(AC);
        if (!(u >= 0.0 && u <= AB.dotProduct(AB)
                && v >= 0.0 && v <= AC.dotProduct(AC)))
        	planeIntersection.clear();

        return planeIntersection;
	}

}
