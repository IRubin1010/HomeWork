/**
 * 
 */
package primitives;

/**
 * @author itzik yeret
 *
 */
public class Point3D extends Point2D {
	private Coordinate _z;
	
	/**
	 * create new Point3D
	 * @param double x
	 * @param double y
	 * @param double z
	 */
	public Point3D(double x, double y, double z) {
		super(x,y);
		_z = new Coordinate(z);
	}
	
	/**
	 * create new Point3D from coordinate
	 * @param coordinate x
	 * @param coordinate y
	 * @param coordinate z
	 */
	public Point3D(Coordinate x, Coordinate y, Coordinate z) {
		super(x,y);
		_z = new Coordinate(z);
	}
	
	/**
	 * create new Point3D from other Point3D
	 * @param other
	 */
	public Point3D(Point3D other) {
		super(other);
		_z = new Coordinate(other._z);
	}
	
	public Coordinate getZ() {
		return _z;
	}

	/** 
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if(obj == null)
			return false;
		if (this == obj)
			return true;
		if (!super.equals(obj))
			return false;
		Point3D other = (Point3D) obj;
		return _z.equals(other._z);
	}
	
	@Override
	public String toString() {
		return super.toString().substring(0,super.toString().length() -1) + ',' + _z.toString() + "]";
	}
	
	/**
	 * create a vector from a 3D point
	 * @return Vector base of the point
	 */
	public Vector toVector() {
		return new Vector(this);
	}
	
	/**
	public double distancefrom(Point3D other) {
		zPow = Math.pow(, b)
		double dis = Math.sqrt(Math.pow(other._z.get(),2) + )
	}
	*/
	
	/**
	 * add point to another point
	 * @param Point3D other
	 * @return new point of adding the two points 
	 */
	protected Point3D addPoint3D(Point3D other) {
		Point2D point = addPoint2D(other);
		return new Point3D(point.getX(),point.getY(),_z.add(other.getZ()));
	}
	
	/**
	 * sub point from another point
	 * @param Point3D other
	 * @return new point of Subtract the second point from the first
	 */
	protected Point3D subPoint3D(Point3D other) {
		Point2D point = subPoint2D(other);
		return new Point3D(point.getX(),point.getY(),_z.subtract(other.getZ()));
	}
	
	/**
	 * multiply point by scalar
	 * @param num
	 * @return new point multiplied by the scalar 
	 */
	protected Point3D scalePoint3D(int num) {
		Point2D point = scalePoint2D(num);
		return new Point3D(point.getX(),point.getY(),_z.scale(num));
	} 
	
	/**
	 * multiply point by another point
	 * @param Point3D other
	 */
	public double multiplyPoint3D(Point3D other) {
		return multiplyPoint2D(other) + _z.multiply(other._z).getValue();
	}
	
	public Vector vectorSubtract(Point3D other) {
		return subPoint3D(other).toVector();
	}
	
	public Point3D addVectorToPoint(Vector other) {
		return addPoint3D(new Point3D(other.getVector()));
	}
	
	public double distanceFrom(Point3D other) {
		Point3D point = subPoint3D(other);
		double xPow = Math.pow(point.getX().getValue(),2);
		double yPow = Math.pow(point.getY().getValue(),2);
		double zPow = Math.pow(point._z.getValue(),2);
		return Math.sqrt(xPow + yPow + zPow);
	}
}
