package elements;

//import org.omg.CORBA._PolicyStub;

import primitives.*;

/**
 * class to represent camera
 * @param _pc center point of the camera
 * @param _vUp
 * @param _vTo
 * @param _vRight
 */
public class Camera {
	
	private Point3D _pc;
	private Vector _vUp;
	private Vector _vTo;
	private Vector _vRight;
	
	/***************** Constructors **********************/
	
	/**
	 * @exception if the vector are not vertical each other
	 */
	public Camera(Vector vUp, Vector vTo, Point3D pc) {
		if (!(vUp.dotProduct(vTo).equals(Coordinate.zeroCoordinate))) {
			throw new IllegalArgumentException("Vectors are not vertical to each other");
		}
		this._vUp=vUp.normalize();
		this._vTo=vTo.normalize();
		this._vRight=new Vector(vUp.crossProduct(vTo).normalize());
		this._pc=pc;
	}

}
