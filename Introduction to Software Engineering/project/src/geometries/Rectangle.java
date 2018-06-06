/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import primitives.Color;
import primitives.Material;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;

/**
 * class represents rectangle
 */
public class Rectangle extends Geometry {

	Triangle triangle1;
	Triangle triangle2;

	/***************** Constructors **********************/

	/**
	 * constructor 
	 * @param a
	 * @param b
	 * @param c
	 * @param d
	 * @param color
	 * @param material
	 */
	public Rectangle(Point3D a, Point3D b, Point3D c, Point3D d, Color color, Material material) {
		super(color, material);
		triangle1 = new Triangle(a, b, c, color, material);
		triangle2 = new Triangle(d, b, c, color, material);
	}

	/***************** Operations ************************/

	/**
	 * function find Intersections
	 * @param ray
	 * @return list of points of the intersection
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> triangle1Map = triangle1.findIntersections(ray);
		Map<Geometry, List<Point3D>> triangle2Map = triangle2.findIntersections(ray);
		Map<Geometry, List<Point3D>> intersection = new HashMap<>();
		if (!triangle1Map.isEmpty()) {
			List<Point3D> list = triangle1Map.get(triangle1);
			intersection.put(this, list);
		}
		if (!triangle2Map.isEmpty()) {
			List<Point3D> list = triangle2Map.get(triangle2);
			intersection.put(this, list);
		}
		return intersection;
	}

	/**
	 * return normal from a point on the plane
	 * @param point
	 */
	@Override
	public Vector getNormal(Point3D point) {
		return triangle1.getNormal(point);
	}

}
