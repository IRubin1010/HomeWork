/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package elements;

import java.awt.Point;

import primitives.*;

/**
 * interface light source
 */
public interface LightSource {
	
	/**
	 * get intensity
	 * @param point
	 * @return Color
	 */
	public Color getIntensity(Point3D point);
	
	/**
	 * get L
	 * @param point
	 * @return Vector from light position to the point on the geometry 
	 */
	public Vector getL(Point3D point);
	
	/**
	 * get direction
	 * @param point
	 * @return vector of the light direction
	 */
	public Vector getD(Point3D point);
	
}
