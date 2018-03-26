/**
 * 
 */
package primitives;

/**
 * @author itzik yeret
 *
 */
public class Point2D {
	private Coordinate _x;
	private Coordinate _y;

	public Point2D(double x, double y) {
		_x = new Coordinate(x);
		_y = new Coordinate(y);
	}

	public Point2D(Coordinate x, Coordinate y) {
		_x = new Coordinate(x);
		_y = new Coordinate(y);
	}

	public Point2D(Point2D other) {
		_x = new Coordinate(other._x);
		_y = new Coordinate(other._y);
	}

	/**
	 * @return the x
	 */
	public Coordinate getX() {
		return _x;
	}

	/**
	 * @return the y
	 */
	public Coordinate getY() {
		return _y;
	}

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

	@Override
	public String toString() {
		return "[" + _x.toString() + ',' + _y.toString() + "]";
	}

	/**
	 * add point to another point
	 * 
	 * @param other
	 * @return new point of adding the two points
	 */
	protected Point2D addPoint2D(Point2D other) {
		return new Point2D(_x.add(other._x), _y.add(other._y));
	}

	/**
	 * sub point from another point
	 * @param other
	 * @return new point of Subtract the second point from the first
	 */
	protected Point2D subPoint2D(Point2D other) {
		return new Point2D(_x.subtract(other._x), _y.subtract(other._y));
	}

	/**
	 * multiply point by scalar
	 * @param num
	 * @return new point multiplied by the scalar
	 */
	protected Point2D scalePoint2D(double num) {
		return new Point2D(_x.scale(num), _y.scale(num));
	}

	/**
	 * multiply point by another point
	 * @param other
	 */
	protected double multiplyPoint2D(Point2D other) {
		return _x.multiply(other._x).getValue() + _y.multiply(other._y).getValue();
	}
	
	/**
	 * divide point2D by a scalar
	 * @param scalar
	 * @return new point2D divided by the scalar
	 */
	protected Point2D scalarDivisionPoint2D(double scalar) {
		return new Point2D(_x.divide(scalar),_y.divide(scalar));
	}

}
