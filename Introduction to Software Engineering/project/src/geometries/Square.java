/**
 * 
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
 * @author itzik yeret
 *
 */
public class Square extends Geometry {

	Triangle triangle1;
	Triangle triangle2;

	public Square(Point3D a, Point3D b, Point3D c, Point3D d, Color color, Material material) {
		super(color, material);
		triangle1 = new Triangle(a, b, c, color, material);
		triangle2 = new Triangle(d, b, c, color, material);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.Intersectable#findIntersections(primitives.Ray)
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

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.Geometry#getNormal(primitives.Point3D)
	 */
	@Override
	public Vector getNormal(Point3D point) {
		return triangle1.getNormal(point);
	}

}
