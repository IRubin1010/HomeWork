/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import primitives.*;

/**
 * class represent triangle
 */
public class Triangle extends Plane {

	private Point3D _p1;
	private Point3D _p2;
	private Point3D _p3;

	/***************** Constructors **********************/

	/**
	 * constructor with 3 points
	 * @param p1
	 * @param p2
	 * @param p3
	 */
	public Triangle(Point3D p1, Point3D p2, Point3D p3) {
		super(p1, p2, p3);
		_p1 = new Point3D(p1);
		_p2 = new Point3D(p2);
		_p3 = new Point3D(p3);
	}

	/**
	 * copy constructor
	 * @param other
	 */
	public Triangle(Triangle other) {
		super(other._p1, other._p2, other._p3);
		_p1 = new Point3D(other._p1);
		_p2 = new Point3D(other._p2);
		_p3 = new Point3D(other._p3);
	}

	/***************** Getters ****************************/

	/**
	 * @return the _p1
	 */
	public Point3D get_p1() {
		return _p1;
	}

	/**
	 * @return the _p2
	 */
	public Point3D get_p2() {
		return _p2;
	}

	/**
	 * @return the _p3
	 */
	public Point3D get_p3() {
		return _p3;
	}

	/***************** Administration *******************/

	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (obj == null)
			return false;
		if (obj == this)
			return true;
		if (!(obj instanceof Triangle))
			return false;
		Triangle other = (Triangle) obj;
		return _p1.equals(other._p1) && _p2.equals(other._p2) && _p3.equals(other._p3)
				|| _p1.equals(other._p1) && _p2.equals(other._p3) && _p3.equals(other._p2)
				|| _p1.equals(other._p2) && _p2.equals(other._p1) && _p3.equals(other._p3)
				|| _p1.equals(other._p2) && _p2.equals(other._p3) && _p3.equals(other._p1)
				|| _p1.equals(other._p3) && _p2.equals(other._p1) && _p3.equals(other._p2)
				|| _p1.equals(other._p3) && _p2.equals(other._p2) && _p3.equals(other._p1);
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "Triangle: \n(" + _p1.toString() + "," + _p2.toString() + "," + _p3.toString() + ")";
	}

}
