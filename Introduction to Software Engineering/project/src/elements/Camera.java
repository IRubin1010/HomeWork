package elements;

//import org.omg.CORBA._PolicyStub;

import primitives.*;

/**
 * class to represent camera
 * 
 * @param _pc
 *            center point of the camera
 * @param _vUp
 * @param _vTo
 * @param _vRight
 */
public class Camera {

	private Point3D _p0;
	private Vector _vUp;
	private Vector _vTo;
	private Vector _vRight;

	/***************** Constructors **********************/

	/**
	 * @exception if
	 *                the vector are not vertical each other
	 */
	public Camera(Vector vUp, Vector vTo, Point3D pc) {
		if (!(vUp.dotProduct(vTo).equals(Coordinate.zeroCoordinate))) {
			throw new IllegalArgumentException("Vectors are not vertical to each other");
		}
		this._vUp = vUp.normalize();
		this._vTo = vTo.normalize();
		this._vRight = new Vector(vTo.crossProduct(vUp).normalize());
		this._p0 = pc;
	}

	/***************** Getters ****************************/

	public Point3D get_pc() {
		return _p0;
	}

	public Vector get_vUp() {
		return _vUp;
	}

	public Vector get_vTo() {
		return _vTo;
	}

	public Vector get_vRight() {
		return _vRight;
	}

	/***************** Operations ************************/

	public Ray constructorRay(int Nx, int Ny, int i, int j, double screenDistance, double screenWidth,
			double screenHight) {
		Point3D pc = _p0.addVectorToPoint(_vTo.scaleVector(screenDistance));
		double Ry = screenHight / Ny;
		double Rx = screenWidth / Nx;
		double pcX = ((double) Nx + 1) / 2;
		double pcY = ((double) Ny + 1) / 2;
		Point3D Pij;
		if (pcX != i && pcY != j) {
			Pij=pc.addVectorToPoint((_vRight.scaleVector((i - pcX) * Rx)).sub(_vUp.scaleVector((j - pcY) * Ry)));
		} else if (pcX != i) {
			Pij=pc.addVectorToPoint(_vRight.scaleVector((i - pcX) * Rx));
		} else if (pcY!=j) {
			Pij=pc.addVectorToPoint(_vUp.scaleVector(-1 * (j - pcY) * Ry));
		}
		else Pij=pc;
		Vector Vij = Pij.vectorSubtract(_p0);
		Ray ray = new Ray(_p0, Vij.normalize());
		return ray;
	}
}
