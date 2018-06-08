/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package primitives;

import javax.security.auth.x500.X500Principal;

/**
 * 
 * class represents Point2D
 *
 */
public class Point2D {
	
	private Coordinate _x;
	private Coordinate _y;

	/***************** Constructors **********************/
	
	/**
	 * constructor with 2 double parameters
	 * @param x coordinate
	 * @param y coordinate
	 */
	public Point2D(double x, double y) {
		_x = new Coordinate(x);
		_y = new Coordinate(y);
	}

	/**
	 * constructor with 2 Coordinate parameters
	 * @param x coordinate
	 * @param y coordinate
	 */
	public Point2D(Coordinate x, Coordinate y) {
		if(x == null || y == null) throw new IllegalArgumentException("param can't be null"); 
		_x = new Coordinate(x);
		_y = new Coordinate(y);
	}

	/**
	 * copy constructor
	 * @param other point2D
	 */
	public Point2D(Point2D other) {
		if(other == null) throw new IllegalArgumentException("param can't be null"); 
		_x = new Coordinate(other._x);
		_y = new Coordinate(other._y);
	}

	/***************** Getters ****************************/
	
	/**
	 * getX
	 * @return x coordinate
	 */
	public Coordinate getX() {
		return _x;
	}

	/**
	 * getY
	 * @return y coordinate
	 */
	public Coordinate getY() {
		return _y;
	}

	/***************** Administration  *******************/
	
	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (obj == null)
			return false;
		if (obj == this)
			return true;
		if (!(obj instanceof Point2D))
			return false;
		Point2D other = (Point2D) obj;
		return _x.equals(other._x) && _y.equals(other._y);
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "[" + _x.toString() + ',' + _y.toString() + "]";
	}
	
	/***************** Operations ************************/ 

	/**
	 * add point to another point
	 * @param other point2D
	 * @return point added by other point
	 */
	protected Point2D add(Point2D other) {
		return new Point2D(_x.add(other.getX()),_y.add(other.getY()));
	}

	/**
	 * sub point from another point
	 * @param other point2D
	 * @return point of Subtract the second point from the first
	 */
	protected Point2D sub(Point2D other) {
		return new Point2D(_x.subtract(other._x),_y.subtract(other._y));
	}

	/**
	 * multiply point by scalar
	 * @param num double
	 * @return point multiplied by the scalar
	 */
	protected Point2D scale(double num) {
		return new Point2D(_x.scale(num),_y.scale(num));
	}

	/**
	 * multiply point by another point
	 * @param other point2D
	 */
	protected Coordinate multiply(Point2D other) {
		return new Coordinate(_x.multiply(other._x).add(_y.multiply(other._y)));
	}
	
	/**
	 * divide point by a scalar
	 * @param scalar double
	 * @return new point divided by the scalar
	 */
	protected Point2D scalarDivision(double scalar) {
		return new Point2D(_x.divide(scalar),_y.divide(scalar));
	}

}
