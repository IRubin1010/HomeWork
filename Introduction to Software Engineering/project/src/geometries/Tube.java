/**
 * 
 */
package geometries;

import primitives.*;

/**
 * @author itzik yeret
 *
 */
public class Tube extends RadialGeometry {
	private Ray _ray;

	public Tube(Ray ray, double radius) {
		super(radius);
		_ray = new Ray(ray);
	}

	public Tube(Tube other) {
		super(other.getRadius());
		_ray = new Ray(other._ray);
	}

	/**
	 * @return the _ray
	 */
	public Ray getRay() {
		return _ray;
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
		if (!(obj instanceof Ray))
			return false;
		if(!super.equals(obj))
			return false;
		Tube other = (Tube) obj;
		return _ray.equals(other._ray);
	}

	@Override
	public String toString() {
		return "Tube: \nray: " + _ray.toString() + " ," + super.toString();
	}
}
