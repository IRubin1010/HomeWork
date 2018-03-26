/**
 * 
 */
package geometries;

import primitives.*;

/**
 * @author itzik yeret
 *
 */
public class Sphere extends RadialGeometry {

	private Point3D _point;

	public Sphere(Point3D point, double radius) {
		super(radius);
		_point = new Point3D(point);
	}

	public Sphere(Sphere other) {
		super(other.getRadius());
		_point = new Point3D(other._point);
	}

	/**
	 * @return the _point
	 */
	public Point3D getPoint() {
		return _point;
	}

	@Override
	public Vector getNormal(Point3D point) {
		return null;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Sphere))
			return false;
		if (!super.equals(obj))
			return false;
		Sphere other = (Sphere) obj;
		return _point.equals(other._point);
	}

	@Override
	public String toString() {
		return "Sphere: \npoint: " + _point.toString() + " ," + super.toString();
	}
}
