/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package elements;

import primitives.Color;

/**
 * class represents ambient light
 *
 */
public class AmbientLight extends Light{

	double _Ka;
	
	/***************** Constructors **********************/
	
	/**
	 * constructor with 4 parameters
	 * @param red
	 * @param green
	 * @param blue
	 * @param Ka
	 */
	public AmbientLight(double red, double green, double blue, double Ka) {
		super(new Color(red,green,blue).scale(Ka));
		_Ka = Ka;
	}
	
	/**
	 * constructor with Color and Ka
	 * @param color
	 * @param Ka
	 */
	public AmbientLight(Color color, double Ka) {
		super(new Color(color).scale(Ka));
		_Ka = Ka;
	}
	
	/**
	 * constructor with java.awt.Color and Ka
	 * @param color
	 * @param Ka
	 */
	public AmbientLight(java.awt.Color color, double Ka) {
		super(new Color(color).scale(Ka));
		_Ka = Ka;
	}
	
}
