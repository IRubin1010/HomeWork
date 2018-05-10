package geometries;
import primitives.*;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Cylinder extends Tube {

	private double _highet;

	/***************** Constructors **********************/

	public Cylinder(double highet, Ray ray, Coordinate radius) {
		super(ray, radius, new Color(255,255,255));
		_highet = highet;
	}

	public Cylinder(Cylinder other) {
		super(other.getRay() , other.getRadius(), new Color(255,255,255));
		_highet = other._highet;
	}

	/***************** Getter ****************************/

	public double getHighet() {
		return _highet;
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
		return _highet == other._highet;
	}

	@Override
	public String toString() {
		if(_highet % 1 ==0)
			return "Cylinder: \nhighet: " + (int)_highet + " ," + super.toString().substring(7);
		return "Cylinder: \nhighet: " + _highet + " " + super.toString().substring(7);
	}
	
	/***************** Operations ************************/ 

}
