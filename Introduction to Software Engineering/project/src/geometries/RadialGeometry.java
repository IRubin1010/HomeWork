/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
 * class represent Radial Geometry
 */
public abstract class RadialGeometry extends Geometry {

	protected double _radius;

	/***************** Constructors **********************/

	/**
	 * constructor with radius
	 * @param radius
	 */
	public RadialGeometry(double radius,Color color) {
		super(color);
		_radius = radius;
	}

	/**
	 * copy constructor
	 * @param other
	 */
	public RadialGeometry(RadialGeometry other) {
		super(other);
		if(other == null) throw new IllegalArgumentException("param can't be null"); 
			_radius = other._radius;
	}

}
