/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package geometries;

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
	 * @param color
	 * @param material
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
	 * @return the emmission
	 */
	public Color getEmmission() {
		return _emmission;
	}

	/**
	 * @return the material
	 */
	public Material getMaterial() {
		return _material;
	}

	/***************** Operations ************************/

	/**
	 * abstract function get normal
	 * 
	 * @param point
	 * @return
	 */
	public abstract Vector getNormal(Point3D point);

}
