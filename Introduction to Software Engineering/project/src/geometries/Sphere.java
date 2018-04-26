package geometries;

import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Sphere extends RadialGeometry {

	private Point3D _point;

	/***************** Constructors **********************/

	public Sphere(Point3D point, Coordinate radius) {
		super(radius);
		_point = new Point3D(point);
	}

	public Sphere(Sphere other) {
		super(other.getRadius());
		_point = new Point3D(other._point);
	}

	/***************** Getter ****************************/

	public Point3D getPoint() {
		return _point;
	}

	/***************** Administration *******************/

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

	/***************** Operations ************************/

	public Vector getNormal(Point3D point){
//		if (!(point.distanceFrom(_point).equals(getRadius()))) {
//			throw new Exception("the point is not on the sphere");
//		}
		return new Vector(point.vectorSubtract(_point)).normalize();
	}
}
