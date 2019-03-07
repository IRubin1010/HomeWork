/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package geometries;

import primitives.*;

/**
 * abstract class Geometry
 */
public abstract class Geometry extends BoundinBox {

	protected Color _emission;
	protected Material _material;

	/***************** Constructors **********************/

	/**
	 * constructor
	 * @param color the emission color of the geometry
	 * @param material material of the geometry
	 */
	public Geometry(Color color, Material material) {
		_emission = color;
		_material = material;
	}

	/**
	 * copy constructor
	 * @param other Geometry
	 */
	public Geometry(Geometry other) {
		_emission = other._emission;
		_material = other._material;
	}

	/***************** Getter ****************************/

	/**
	 * get emission
	 * @return the emission color of the geometry
	 */
	public Color getEmmission() {
		return _emission;
	}

	/**
	 * get material
	 * @return the material of the geometry
	 */
	public Material getMaterial() {
		return _material;
	}

	/***************** Operations ************************/

	/**
	 * get the normal to the geometry on a given point
	 * @param point point to get the normal from
	 * @return vector normal
	 */
	public abstract Vector getNormal(Point3D point);

}
