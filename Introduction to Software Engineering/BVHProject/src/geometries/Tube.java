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
	 * @param ray ray of the tube
	 * @param radius radius of the tube
	 * @param color emission color of the tube
	 * @param material material of the tube
	 */
	public Tube(Ray ray, double radius, Color color, Material material) {
		super(radius, color, material);
		_ray = new Ray(ray);
	}

	/**
	 * copy constructor
	 * @param other tube
	 */
	public Tube(Tube other) {
		super(other);
		_ray = new Ray(other._ray);
	}

	/***************** Operations ************************/

	/* (non-Javadoc)
	 * @see geometries.Geometry#getNormal(primitives.Point3D)
	 */
	@Override
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

	/* (non-Javadoc)
	 * @see geometries.Intersectable#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		return null;
	}

	/* (non-Javadoc)
	 * @see geometries.BoundinBox#setMinMax()
	 */
	@Override
	protected void setMinMax() {
		// TODO Auto-generated method stub
		
	}

	
}
