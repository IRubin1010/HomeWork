/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package elements;

import primitives.Color;

public class AmbientLight {

	Color _color;
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
		_color = new Color(red,green,blue);
		_Ka = Ka;
	}
	
	/**
	 * constructor with Color and Ka
	 * @param color
	 * @param Ka
	 */
	public AmbientLight(Color color, double Ka) {
		_color = new Color(color);
		_Ka = Ka;
	}
	
	/**
	 * constructor with java.awt.Color and Ka
	 * @param color
	 * @param Ka
	 */
	public AmbientLight(java.awt.Color color, double Ka) {
		_color = new Color(color);
		_Ka = Ka;
	}
	
	/***************** Getters/setters ****************************/

	/**
	 * @return the _color
	 */
	public Color get_color() {
		return _color;
	}

	/**
	 * @param _color the _color to set
	 */
	public void set_color(Color _color) {
		this._color = _color;
	}

	/**
	 * @return the _Ka
	 */
	public double get_Ka() {
		return _Ka;
	}

	/**
	 * @param _Ka the _Ka to set
	 */
	public void set_Ka(double _Ka) {
		this._Ka = _Ka;
	}
	
	///////////////////////להכניס לבנאים את המכפלה ליעול קריאות חוזרות//////////////////
	/**
	 * get intensity
	 * @return the ambient light
	 */
	public Color getIntensity() {
		return _color.scale(_Ka);
	}
	
}
