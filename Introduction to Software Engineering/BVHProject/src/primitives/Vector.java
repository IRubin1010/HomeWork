/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package primitives;


/**
 * class represents Vector
 *
 */
public class Vector {
	
	private Point3D _head;

	/***************** Constructors **********************/
	
	/**
	 * constructor with 3 double parameters
	 * @param x coordinate
	 * @param y coordinate
	 * @param z coordinate
	 */
	public Vector(double x, double y, double z) {
		if(new Point3D(x, y, z).equals(Point3D.ZERO)) throw new IllegalArgumentException("vector can't be vector 0");
		_head = new Point3D(x, y, z);
	}
	
	/**
	 * constructor with 3 coordinate parameters
	 * @param x coordinate
	 * @param y coordinate
	 * @param z coordinate
	 */
	public Vector(Coordinate x, Coordinate y, Coordinate z) {
		if(new Point3D(x, y, z).equals(Point3D.ZERO)) throw new IllegalArgumentException("vector can't be vector 0");
		_head = new Point3D(x, y, z);
	}

	/**
	 * constructor from point 
	 * @param point3D point
	 */
	public Vector(Point3D point) {
		if(point.equals(Point3D.ZERO)) throw new IllegalArgumentException("vector can't be vector 0");
		_head = new Point3D(point);
	}
	
	/**
	 * copy constructor
	 * @param other vector
	 */
	public Vector(Vector other) {
		_head = new Point3D(other._head);
	}

	/***************** Getter ****************************/
	
	/**
	 * get the head of the vector
	 * @return point3D - the vectors head
	 */
	public Point3D getVector() {
		return _head;
	}
	
	/***************** Administration  *******************/

	/**
	 * overrode equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (obj == null)
			return false;
		if (obj == this)
			return true;
		if (!(obj instanceof Vector))
			return false;
		Vector other = (Vector) obj;
		return _head.equals(other._head);
	}
	
	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "(" + _head.toString().substring(1,_head.toString().length()-1) + ")";
	}
	
	/***************** Operations ************************/ 
	
	/**
	 * add Vector to Vector
	 * @param other vector
	 * @return new Vector of adding both Vectors
	 */
	public Vector add(Vector other) {
		return new Vector(_head.add(other._head));
	}
	
	/**
	 * subtract Vector from another Vector
	 * @param other Vector 
	 * @return new Vector of Subtract the second Vector from the first
	 */
	public Vector sub(Vector other) {
		return new Vector(_head.sub(other._head));
	}
	
	/**
	 * multiply Vector by scalar
	 * @param num double 
	 * @return new Vector multiplied by the scalar
	 */
	public Vector scaleVector(double num) {
		return new Vector(_head.scale(num));
	}
	
	/**
	 * Dot Product Vector with other Vector
	 * @param other vector
	 * @return new Vector Dot Producted by the other Vector
	 */
	public double dotProduct(Vector other) {
		return _head.multiply(other._head);
	}
	
	/**
	 * Cross Product Vector with other Vector
	 * @param other vector
	 * @return new Vector Cross Producted by the other Vector
	 */
	public Vector crossProduct(Vector other) {
		Coordinate x = _head.getY().multiply(other._head.getZ()).subtract(_head.getZ().multiply(other._head.getY()));
		Coordinate y = _head.getZ().multiply(other._head.getX()).subtract(_head.getX().multiply(other._head.getZ()));
		Coordinate z = _head.getX().multiply(other._head.getY()).subtract(_head.getY().multiply(other._head.getX()));
		try {			
			return new Vector(x,y,z);
		} catch (IllegalArgumentException e) {
			throw new IllegalArgumentException("both vectors are the same");
		}
	}
	
	/**
	 * get the length of a vector
	 * @return the vector size
	 */
	public double size() {
		return _head.distanceFrom(Point3D.ZERO);
	}
	
	/**
	 * normalize the vector
	 * @return new normalize Vector
	 */
	public Vector normalize() {
		double vectorSize = size();
		return new Vector(_head.scalarDivision(vectorSize));
	}
}
