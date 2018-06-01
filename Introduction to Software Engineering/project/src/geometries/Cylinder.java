/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;
import primitives.*;

/**
 * class represents Cylinder
 *
 */
public class Cylinder extends Tube {

	private double _height;

	/***************** Constructors **********************/

	public Cylinder(double height, Ray ray, double radius) {
		super(ray, radius, new Color(255,255,255), new Material(2,3,4, 0, 0));
		_height = height;
	}

	public Cylinder(Cylinder other) {
		super(other);
		_height = other._height;
	}

}
