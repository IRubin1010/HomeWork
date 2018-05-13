package geometries;
import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Cylinder extends Tube {

	private double _height;

	/***************** Constructors **********************/

	public Cylinder(double height, Ray ray, Coordinate radius) {
		super(ray, radius, new Color(255,255,255));
		_height = height;
	}

	public Cylinder(Cylinder other) {
		super(other);
		_height = other._height;
	}

	/***************** Getter ****************************/

	public double getHeight() {
		return _height;
	}
	
	/***************** Administration *******************/

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Cylinder))
			return false;
		if(!super.equals(obj))
			return false;
		Cylinder other = (Cylinder) obj;
		return _height == other._height;
	}

	@Override
	public String toString() {
		if(_height % 1 ==0)
			return "Cylinder: \nhighet: " + (int)_height + " ," + super.toString().substring(7);
		return "Cylinder: \nhighet: " + _height + " " + super.toString().substring(7);
	}
	
	/***************** Operations ************************/ 

}
