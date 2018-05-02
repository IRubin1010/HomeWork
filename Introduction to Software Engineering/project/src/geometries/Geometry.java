/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package geometries;
import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
* abstract class Geometry 
*/
public abstract class Geometry {

	/**
	 * constructor
	 */
	public Geometry() {
	}
	
	/**
	 * copy constructor 
	 * @param other
	 */
	public Geometry(Geometry other) {
	}
	
	/**
	 * abstract function get normal
	 * @param point
	 * @return
	 */
	public abstract Vector getNormal(Point3D point);
	
	/**
	 * abstract function find Intersections
	 * @param ray
	 * @return point of the intersection
	 */
	public abstract List<Point3D> findIntersections(Ray ray);

}
