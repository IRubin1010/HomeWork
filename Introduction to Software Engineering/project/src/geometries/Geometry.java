/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package geometries;
import java.util.List;
import java.util.Map;

import primitives.*;

/**
* abstract class Geometry 
*/
public abstract class Geometry implements Intersectable {

	protected Color _emmission;
	
	/***************** Constructors **********************/

	/**
	 * constructor
	 */
	public Geometry(Color color) {
		_emmission = color;
	}
	
	/**
	 * copy constructor 
	 * @param other
	 */
	public Geometry(Geometry other) {
		_emmission = other._emmission;
	}
	
	/***************** Getter ****************************/

	/**
	 * @return the _emmission
	 */
	public Color get_emmission() {
		return _emmission;
	}
	
	/***************** Operations ************************/ 

	/**
	 * abstract function get normal
	 * @param point
	 * @return
	 */
	public abstract Vector getNormal(Point3D point);
	
}
