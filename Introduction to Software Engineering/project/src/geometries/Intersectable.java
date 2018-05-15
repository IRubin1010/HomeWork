/**
 * 
 */
package geometries;

import java.util.List;
import java.util.Map;

import primitives.Point3D;
import primitives.Ray;

/**
 * interface to hold the intersectable geometries
 */
public interface Intersectable {
	/**
	 * get the intersection with the geometry
	 * 
	 * @param ray
	 * @return Map holds a pair of geometry and list the point of intersection with
	 *         the geometry
	 */
	Map<Geometry, List<Point3D>> findIntersections(Ray ray);
}
