/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import primitives.*;

/**
 * class represent Radial Geometry
 */
public abstract class RadialGeometry extends Geometry {

	protected double _radius;

	/***************** Constructors **********************/

	/**
	 * constructor with radius
	 * @param radius radius of the geometry
	 * @param color emission color of the geometry
	 * @param material material of the geometry
	 */
	public RadialGeometry(double radius,Color color, Material material) {
		super(color, material);
		_radius = radius;
	}

	/**
	 * copy constructor
	 * @param other radial geometry
	 */
	public RadialGeometry(RadialGeometry other) {
		super(other);
		if(other == null) throw new IllegalArgumentException("param can't be null"); 
			_radius = other._radius;
	}

}
