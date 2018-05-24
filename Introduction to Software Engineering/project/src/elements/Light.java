/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package elements;

import primitives.Color;

/**
 * abstract class represents light
 *
 */
public abstract class Light {
	protected Color _color;
	
	/**
	 * copy constructor
	 * @param color
	 */
	public Light(Color color) {
		_color = new Color(color);
	}
	
	/**
	 * get intensity
	 * @return
	 */
	public Color getIntensity() {
		return new Color(_color);
	}
		
}
