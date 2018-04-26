package geometries;
import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Tube extends RadialGeometry {
	
	private Ray _ray;

	/***************** Constructors **********************/

	public Tube(Ray ray, Coordinate radius) {
		super(radius);
		_ray = new Ray(ray);
	}

	public Tube(Tube other) {
		super(other.getRadius());
		_ray = new Ray(other._ray);
	}

	/***************** Getter ****************************/

	public Ray getRay() {
		return _ray;
	}
	
	/***************** Administration *******************/

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
	
	/***************** Operations ************************/ 

	public Vector getNormal(Point3D point){
		// formula: surcharge = c = (PtoPVector*rayVector/(|rayVector|)^2)*rayVector
		Vector PtoPVector = point.vectorSubtract(getRay().getPoint());
		Vector surcharge = getRay().getDirection().scaleVector(PtoPVector.dotProduct(getRay().getDirection()).divide(Math.pow(getRay().getDirection().size().getValue(),2)).getValue());
		return new Vector(PtoPVector.sub(surcharge)).normalize();
		
		
		
//		Vector dotVector = PtoPVector.crossProduct(getRay().getDirection());
//		Coordinate distance = dotVector.size().coordinateDivide(getRay().getDirection().size());
//		if(!distance.equals(getRadius()))
//			throw new Exception("the point is not on the Tube");
//		Vector direction = getRay().getDirection().normalize();
//		direction.scaleVector(Math.sqrt(Math.pow(PtoPVector.size().getValue(),2) - Math.pow(getRadius().getValue(), 2)));
//		return new Vector(PtoPVector.sub(direction));
	}
}
