/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import primitives.Point3D;
import primitives.Ray;


/**
 * Class represent a collection of shapes
 * Class inherits from Geometry
 * and should deal with the collection of shapes as a single form
 * according to the principle of structural pattern - composite
 */
public class Geometries implements Intersectable {
	
	/**
	 * List hold all the shapes that make up the structure
	 */
	private List<Geometry> listShape = new ArrayList<Geometry>();
	

	/***************** Getter ****************************/

	/**
	 * get list of geometries
	 * @return
	 */
	public List<Geometry> getGeometries() {
		return listShape;
	}
	
	/***************** Operations ************************/

	/**
	 * Add geometry to the geometries
	 * @param geometry
	 *            - Geometry to add
	 */
	public void addGeometry(Geometry geometry) {
		this.listShape.add(geometry);
	}

	/**
	 * override findIntersections
	 * @param ray - the ray for which you want the cut points with the geometry
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> intersections = new HashMap<>();
		for(Geometry shape : listShape) {
			intersections.putAll(shape.findIntersections(ray));
		}
		return intersections;
	}

}
