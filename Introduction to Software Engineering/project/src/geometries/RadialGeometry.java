/**
 * 
 */
package geometries;

import primitives.*;
import primitives.Vector;

/**
 * @author itzik yeret
 *
 */
public class RadialGeometry extends Geometry {

	private double _radius;
	
	public RadialGeometry(double radius) {
		_radius = radius;
	}
	
	public RadialGeometry(RadialGeometry other) {
		_radius = other._radius;
	}
	
	public double getRadius() {
		return _radius;
	}
	
	public Vector getNormal(Point3D point) {
		return null;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#hashCode()
	 */
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		long temp;
		temp = Double.doubleToLongBits(_radius);
		result = prime * result + (int) (temp ^ (temp >>> 32));
		return result;
	}

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
		if(_radius % 1 == 0) 
			return "radius: " + (int)_radius;
		return "radius: " + _radius;
	}
	
	

}
