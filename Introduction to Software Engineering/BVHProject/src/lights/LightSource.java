/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package lights;

import primitives.*;

/**
 * interface light source
 */
public interface LightSource {
	
	/**
	 * get intensity of the light on a specific point
	 * @param point point to get the intensity for
	 * @return the intensity of the color
	 */
	public Color getIntensity(Point3D point);
	
	/**
	 * get vector from the light to the point
	 * @param point point to get vector to
	 * @return Vector from light position to the point on the geometry 
	 */
	public Vector getL(Point3D point);
	
	/**
	 * get the direction of the light
	 * @param point to calculate the direction to
	 * @return vector of the light direction
	 */
	public Vector getD(Point3D point);
	
	/**
	 * get the distance from the light to the point
	 * @param point point to calculate the distance
	 * @return distance between the point and the light
	 */
	double getDistance(Point3D point);
	
}
