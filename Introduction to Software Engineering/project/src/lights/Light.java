/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package lights;

import primitives.Color;

/**
 * abstract class represents light
 *
 */
public abstract class Light {
	
	protected Color _color;
	
	/***************** Constructor **********************/

	/**
	 * constructor
	 * @param color the color of the light
	 */
	public Light(Color color) {
		_color = new Color(color);
	}
	
	/***************** Operations ************************/

	/**
	 * get the intensity of the light
	 * @return the real intensity 
	 */
	public Color getIntensity() {
		return new Color(_color);
	}
		
}
