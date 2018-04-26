/**
 * 
 */
package geometries;

import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class RadialGeometry extends Geometry {

	private Coordinate _radius;

	/***************** Constructors **********************/

	public RadialGeometry(Coordinate radius) {
		super();
		_radius = radius;
	}

	public RadialGeometry(RadialGeometry other) {
		super(other);
		if(other == null) throw new IllegalArgumentException("param can't be null"); 
			_radius = other._radius;
	}

	/***************** Getter ****************************/

	public Coordinate getRadius() {
		return _radius;
	}
	
	/***************** Administration  *******************/

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

	@Override
	public String toString() {
		return "radius: " + _radius;
	}
	
	/***************** Operations ************************/ 

	public Vector getNormal(Point3D point){
		return null;
	}


}
