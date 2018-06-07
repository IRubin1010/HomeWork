/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package elements;

import primitives.*;

/**
 * class to represent camera
 * @param _p0 center point of the camera
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
	 * constructor
	 * @param vUp
	 * @param vTo
	 * @param pc
	 */
	public Camera(Vector vUp, Vector vTo, Point3D pc) {
		// if the vector are not vertical each other
		if (!Coordinate.ZERO.equals(vUp.dotProduct(vTo))) {
			throw new IllegalArgumentException("Vectors are not vertical to each other");
		}
		this._vUp = vUp.normalize();
		this._vTo = vTo.normalize();
		this._vRight = new Vector(vTo.crossProduct(vUp).normalize());
		this._p0 = pc;
	}
	
	/**
	 * copy constructor
	 * @param camera
	 */
	public Camera(Camera camera) {
		_p0 = new Point3D(camera._p0);
		_vUp = new Vector(camera._vUp);
		_vTo = new Vector(camera._vTo);
		_vRight = new Vector(camera._vRight);
	}

	/***************** Getters ****************************/

	/**
	 * @return the p0
	 */
	public Point3D getP0() {
		return _p0;
	}

	/***************** Operations ************************/

	/**
	 * constructor ray through a pixel
	 * 
	 * @param Nx
	 *            number of pixels across the plane
	 * @param Ny
	 *            number of pixels to the height of the plane
	 * @param i
	 *            column
	 * @param j
	 *            row
	 * @param screenDistance
	 * @param screenWidth
	 * @param screenHight
	 */
	public Ray constructRayThroghPixel(int Nx, int Ny, int i, int j, double screenDistance, double screenWidth,
			double screenHight) {
		Point3D pc = _p0.addVectorToPoint(_vTo.scaleVector(screenDistance));
		double Ry = screenHight / Ny;
		double Rx = screenWidth / Nx;
		double pcX = ((double) Nx + 1) / 2;
		double pcY = ((double) Ny + 1) / 2;
		Point3D Pij = pc;
		if (pcX != i)
			Pij = Pij.addVectorToPoint(_vRight.scaleVector((i - pcX) * Rx));
		if (pcY != j)
			Pij = Pij.addVectorToPoint(_vUp.scaleVector((pcY - j) * Ry));
		Vector Vij = Pij.vectorSubtract(_p0);
		Ray ray = new Ray(_p0, Vij);
		return ray;
	}
}
