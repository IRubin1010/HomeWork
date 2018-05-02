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

	private Coordinate _radius;

	/***************** Constructors **********************/

	/**
	 * constructor with radius
	 * @param radius
	 */
	public RadialGeometry(Coordinate radius) {
		super();
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

	/***************** Getter ****************************/
	
	/**
	 * @return the _radius
	 */
	public Coordinate getRadius() {
		return _radius;
	}

	/***************** Administration  *******************/

	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof RadialGeometry))
			return false;
		RadialGeometry other = (RadialGeometry) obj;
		return _radius == other._radius;
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "radius: " + _radius;
	}
	
//	/***************** Operations ************************/ 
//
//	/**
//	 * get normal
//	 */
//	public Vector getNormal(Point3D point){
//		return null;
//	}
//	
//	/**
//	 * abstract function find Intersections
//	 * @param ray
//	 * @return point of the intersection
//	 */
//	@Override
//	public List<Point3D> findIntersections(Ray ray) {
//		return null;
//	}

}
