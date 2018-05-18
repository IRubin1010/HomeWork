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
	protected Material _material;
	
	/***************** Constructors **********************/

	/**
	 * constructor
	 * @param material TODO
	 */
	public Geometry(Color color, Material material) {
		_emmission = color;
		_material = material;
	}
	
	/**
	 * copy constructor 
	 * @param other
	 */
	public Geometry(Geometry other) {
		_emmission = other._emmission;
		_material = other._material;
	}
	
	/***************** Getter ****************************/

	/**
	 * @return the _emmission
	 */
	public Color get_emmission() {
		return _emmission;
	}
	
	/**
	 * @return the _material
	 */
	public Material get_material() {
		return _material;
	}
	
	/***************** Operations ************************/ 

	/**
	 * abstract function get normal
	 * @param point
	 * @return
	 */
	public abstract Vector getNormal(Point3D point);
	
}
