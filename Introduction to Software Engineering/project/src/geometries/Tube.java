/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.List;
import java.util.Map;
import primitives.*;

/**
 * class represent tube
 */
public class Tube extends RadialGeometry {

	protected Ray _ray;

	/***************** Constructors **********************/

	/**
	 * constructor with ray and radius
	 * 
	 * @param ray
	 * @param radius
	 * @param color
	 * @param material 
	 */
	public Tube(Ray ray, double radius, Color color, Material material) {
		super(radius, color, material);
		_ray = new Ray(ray);
	}

	/**
	 * copy constructor
	 * @param other
	 */
	public Tube(Tube other) {
		super(other);
		_ray = new Ray(other._ray);
	}

	/***************** Operations ************************/

	/**
	 * return normal from a point on the tube
	 * @param point
	 */
	public Vector getNormal(Point3D point) {

		// formula: surcharge = c = (PtoPVector*rayVector(normalize))*rayVector

		// get ray vector
		Vector rayVector = _ray.getDirection();
		// vector from center point to point on the tube
		Vector PtoPVector = point.vectorSubtract(_ray.getPoint());
		// get ray normalize vector
		Vector normalRayVector = rayVector.normalize();
		// get the surcharge
		double surcharge = PtoPVector.dotProduct(normalRayVector);
		// mult ray normalize vector by the surcharge
		Vector surchargeVector = normalRayVector.scaleVector(surcharge);
		return new Vector(PtoPVector.sub(surchargeVector)).normalize();
	}

	/**
	 * function find Intersections
	 * @param ray
	 * @return list of points of the intersection
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		return null;
	}

}
