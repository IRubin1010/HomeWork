package geometries;
import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Plane extends Geometry {
	
	private Point3D _point;
	private Vector _plumb;
	
	/***************** Constructors **********************/

	public Plane(Point3D point, Vector plumb) {
		_point = new Point3D(point);
		_plumb = new Vector(plumb);
	}
	
	public Plane(Plane other) {
		_point = new Point3D(other._point);
		_plumb = new Vector(other._plumb);
	}

	/***************** Getters ****************************/

	public Point3D getPoint() {
		return _point;
	}

	public Vector getPlumb() {
		return _plumb;
	}

	/***************** Administration *******************/

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
	
	/***************** Operations ************************/ 

	public Vector getNormal(Point3D point) {
		return null;
	}

}
