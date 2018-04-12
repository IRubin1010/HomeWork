package primitives;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
public class Point3D extends Point2D {
	
	private Coordinate _z;
	
	/***************** Constructors **********************/
	
	public Point3D(double x, double y, double z) {
		super(x,y);
		_z = new Coordinate(z);
	}
	
	public Point3D(Coordinate x, Coordinate y, Coordinate z) {
		super(x,y);
		if(z == null) throw new IllegalArgumentException("param can't be null");
		_z = new Coordinate(z);
	}
	
	public Point3D(Point3D other) {
		super(other);
		_z = new Coordinate(other._z);
	}
	
	/***************** Getter ****************************/
	
	public Coordinate getZ() {
		return _z;
	}

	/***************** Administration  *******************/
	
	@Override
	public boolean equals(Object obj) {
		if(obj == null)
			return false;
		if (this == obj)
			return true;
		if(!(obj instanceof Point3D))
			return false;
		if (!super.equals(obj))
			return false;
		Point3D other = (Point3D) obj;
		return _z.equals(other._z);
	}
	
	@Override
	public String toString() {
		return super.toString().substring(0,super.toString().length() -1) + ',' + _z.toString() + "]";
	}
	
	/***************** Operations ************************/ 
	
	// CHECK ABOUT OVERRIDE METHODES
	
	/**
	 * create a vector from a 3D point
	 * @return Vector base of the point
	 */
	public Vector toVector() {
		return new Vector(this);
	}
	
	/**
	 * add point to another point
	 * @param Point3D other
	 * @return new point of adding the two points 
	 */
	protected Point3D add(Point3D other) {
		Point2D point = super.add(other);
		return new Point3D(point.getX(),point.getY(),_z.add(other.getZ()));
	}
	
	/**
	 * sub point from another point
	 * @param Point3D other
	 * @return new point of Subtract the second point from the first
	 */
	protected Point3D sub(Point3D other) {
		Point2D point = super.sub(other);
		return new Point3D(point.getX(),point.getY(),_z.subtract(other.getZ()));
	}
	
	/**
	 * multiply point by scalar
	 * @param num
	 * @return new point multiplied by the scalar 
	 */
	protected Point3D scale(double num) {
		Point2D point = super.scale(num);
		return new Point3D(point.getX(),point.getY(),_z.scale(num));
	} 
	
	/**
	 * multiply point with another point
	 * @param Point3D other
	 */
	public double multiply(Point3D other) {
		return super.multiply(other) + _z.multiply(other._z).getValue();
	}
	
	/**
	 * divide point3D by a scalar
	 * @param scalar
	 * @return new point3D divided by the scalar
	 */
	protected Point3D scalarDivision(double scalar) {
		Point2D point = super.scalarDivision(scalar);
		return new Point3D(point.getX(),point.getY(),_z.divide(scalar));
	}
	
	/**
	 * sub point from another point
	 * @param other
	 * @return new vector from other point to this point
	 */
	public Vector vectorSubtract(Point3D other) {
		return sub(other).toVector();
	}
	
	/**
	 * add a vector to a point
	 * @param other
	 * @return new point 
	 */
	public Point3D addVectorToPoint(Vector other) {
		return add(other.getVector());
	}
	
	/**
	 * calculate the distance of 2 points
	 * @param other
	 * @return distance
	 */
	public double distanceFrom(Point3D other) {
		Point3D point = sub(other);
		double xPow = Math.pow(point.getX().getValue(),2);
		double yPow = Math.pow(point.getY().getValue(),2);
		double zPow = Math.pow(point._z.getValue(),2);
		return Math.sqrt(xPow + yPow + zPow);
	}
}
