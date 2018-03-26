/**
 * 
 */
package primitives;

/**
 * @author itzik yeret
 *
 */
public class Vector {
	private Point3D _head;

	/**
	 * create new Vector 
	 * @param double x
	 * @param double y
	 * @param double z
	 */
	public Vector(double x, double y, double z) {
		_head = new Point3D(x, y, z);
	}
	
	/**
	 * create new Vector from Coordinates 
	 * @param Coordinate x
	 * @param Coordinate y
	 * @param Coordinate z
	 */
	public Vector(Coordinate x, Coordinate y, Coordinate z) {
		_head = new Point3D(x, y, z);
	}

	/**
	 * create new Vector from other Vector
	 * @param Vector other
	 */
	public Vector(Vector other) {
		_head = new Point3D(other._head);
	}
	
	/**
	 * create new Vector from 3D point
	 * @param Point3D other
	 */
	public Vector(Point3D other) {
		_head = new Point3D(other);
	}

	public Point3D getVector() {
		return _head;
	}

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
	
	@Override
	public String toString() {
		return "(" + _head.toString().substring(1,_head.toString().length()-1) + ")";
	}
	
	/**
	 * add Vector to Vector
	 * @param Vector other
	 * @return new Vector of adding both Vectors
	 */
	public Vector add(Vector other) {
		return new Vector(_head.addPoint3D(other._head));
	}
	
	/**
	 * subtract Vector from another Vector
	 * @param Vector other
	 * @return new Vector of Subtract the second Vector from the first
	 */
	public Vector sub(Vector other) {
		return new Vector(_head.subPoint3D(other._head));
	}
	
	/**
	 * multiply Vector by scalar
	 * @param num
	 * @return Vector multiplied by the scalar
	 */
	public Vector scaleVector(double num) {
		return new Vector(_head.scalePoint3D(num));
	}
	
	/**
	 * Dot Product Vector with other Vector
	 * @param num
	 * @return Vector Dot Producted by the other Vector
	 */
	public double dotProduct(Vector other) {
		return _head.multiplyPoint3D(other._head);
	}
	
	/**
	 * Cross Product Vector with other Vector
	 * @param other
	 * @return Vector Cross Producted by the other Vector
	 */
	public Vector crossProduct(Vector other) {
		Coordinate x = _head.getY().multiply(other._head.getZ()).subtract(_head.getZ().multiply(other._head.getY()));
		Coordinate y = _head.getZ().multiply(other._head.getX()).subtract(_head.getX().multiply(other._head.getZ()));
		Coordinate z = _head.getX().multiply(other._head.getY()).subtract(_head.getY().multiply(other._head.getX()));
		return new Vector(x,y,z);
	}
	
	/**
	 * @return the vector size
	 */
	public double size() {
		Vector vector0 = new Vector(0,0,0);
		return this._head.distanceFrom(vector0._head);
	}
	
	/**
	 * normalize the vector
	 * @return new normalize Vector
	 */
	public Vector normalize() {
		double vectorSize = size();
		return new Vector(_head.scalarDivisionPoint3D(vectorSize));
	}
}
