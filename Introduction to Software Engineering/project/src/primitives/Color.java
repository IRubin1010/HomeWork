/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/

package primitives;

/**
 * class represents Color
 *
 */
public class Color {
	
	double _red;
	double _green;
	double _blue;
	
	/***************** Constructors **********************/

	/**
	 * constructor with 3 double parameters
	 * @param red
	 * @param green
	 * @param blue
	 */
	public Color(double red, double green, double blue) {
		_red = red;
		_green = green;
		_blue = blue;
	}
	
	/**
	 * copy constructor with Color parameter
	 * @param color
	 */
	public Color(Color color) {
		_red = color._red;
		_green = color._green;
		_blue = color._blue;
	}
	
	/**
	 * constructor with java.awt.Color parameter
	 * @param color
	 */
	public Color(java.awt.Color color) {
		_red = color.getRed();
		_green = color.getGreen();
		_blue = color.getBlue();
	}
	
	/***************** Getter ****************************/
	
	/**
	 * create java.awt.Color from color
	 * @return java.awt.Color
	 */
	public java.awt.Color getColor(){
		int red = getIntFromRGB(_red);
		int green = getIntFromRGB(_green);
		int blue = getIntFromRGB(_blue);
		return new java.awt.Color(red,green,blue);
	}
	
	/***************** Operations ************************/ 
	
	/**
	 * add 2 colors
	 * @param color
	 * @return this color added by other color
	 */
	public Color add(Color color) {
		_red += color._red;
		_green += color._green;
		_blue += color._blue;
		return this;
	}
	
	/**
	 * multiply color by number
	 * @param num
	 * @return this color multiplied by num
	 */
	public Color scale(double num) {
		_red *= num;
		_green *= num;
		_blue *= num;
		return this;
	}
	
	/**
	 * divide color by number
	 * @param num
	 * @return this color divided by num
	 */
	public Color reduce(double num) {
		_red /= num;
		_green /= num;
		_blue /= num;
		return this;
	}
	
	/***************** Helpers ************************/ 

	/**
	 * return valid number between 0-255 from double color
	 * @param color
	 * @return int between 0-255
	 */
	private int getIntFromRGB(double doubleColor) {
		int intColor;
		if(doubleColor > 255) {
			intColor = 255;
		}
		else {
			intColor = doubleColor < 0 ? 0 : (int)doubleColor;
		}
		return intColor;
	}
}
