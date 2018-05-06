/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;
import java.util.ArrayList;
import java.util.List;

import primitives.*;

/**
 * class represent tube
 */
public class Tube extends RadialGeometry {
	
	private Ray _ray;

	/***************** Constructors **********************/

	/**
	 * constructor with ray and radius
	 * @param ray
	 * @param radius
	 */
	public Tube(Ray ray, Coordinate radius) {
		super(radius);
		_ray = new Ray(ray);
	}

	/**
	 * copy constructor
	 * @param other
	 */
	public Tube(Tube other) {
		super(other.getRadius());
		_ray = new Ray(other._ray);
	}

	/***************** Getter ****************************/

	/**
	 * @return the _ray
	 */
	public Ray getRay() {
		return _ray;
	}
	
	/***************** Administration *******************/

	/**
	 * override equals
	 */
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

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "Tube: \nray: " + _ray.toString() + " ," + super.toString();
	}
	
	/***************** Operations ************************/ 

	/**
	 * return normal from a point on the tube
	 * @param point on the tube
	 */
	public Vector getNormal(Point3D point){
		
		// formula: surcharge = c = (PtoPVector*rayVector(normalize))*rayVector
		
		// get ray vector
		Vector rayVector = getRay().getDirection(); 
		// vector from center point to point on the tube 
		Vector PtoPVector = point.vectorSubtract(getRay().getPoint());
		// get ray normalize vector 
		Vector normalRayVector = rayVector.normalize();
		// get the surcharge
		Coordinate surcharge = PtoPVector.dotProduct(normalRayVector);
		// mult ray normalize vector by the surcharge
		Vector surchargeVector = normalRayVector.scaleVector(surcharge.getValue());
		return new Vector(PtoPVector.sub(surchargeVector)).normalize();
	}

	@Override
	public List<Point3D> findIntersections(Ray ray) {
		// TODO Auto-generated method stub
		return null;
	}
	
}
