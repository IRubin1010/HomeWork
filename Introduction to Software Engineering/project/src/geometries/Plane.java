/**
 * 
 */
package geometries;

import primitives.*;

/**
 * @author itzik yeret
 *
 */
public class Plane extends Geometry {
	
	private Point3D _point;
	private Vector _plumb;
	
	public Plane(Point3D point, Vector plumb) {
		_point = new Point3D(point);
		_plumb = new Vector(plumb);
	}
	
	public Plane(Plane other) {
		_point = new Point3D(other._point);
		_plumb = new Vector(other._plumb);
	}

	/**
	 * @return the _point
	 */
	public Point3D getPoint() {
		return _point;
	}

	/**
	 * @return the _plumb
	 */
	public Vector getPlumb() {
		return _plumb;
	}

	public Vector getNormal(Point3D point) {
		return null;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Plane))
			return false;
		Plane other = (Plane) obj;
		return _point.equals(other._point) && _plumb.equals(other._plumb);
	}

	@Override
	public String toString() {
		return "Plane: \npoint: " + _point.toString() + " ,plumb: " + _plumb.toString();
	}
	
	

}
