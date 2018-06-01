/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
package primitives;

/**
 * class represents material
 */
public class Material {
	double _Kd;
	double _Ks;
	int _nShininess;
	double _Kr;
	double _Kt;
	
	public Material(double Kd, double Ks, double Kr, double Kt, int nShininess) {
		_Kd = Kd;
		_Ks = Ks;
		_nShininess = nShininess;
		_Kr = Kr;
		_Kt = Kt;
	}

	/***************** Getteres ****************************/
	
	/**
	 * @return the _Kd
	 */
	public double get_Kd() {
		return _Kd;
	}

	/**
	 * @return the _Ks
	 */
	public double get_Kr() {
		return _Kr;
	}
	
	/**
	 * @return the _Ks
	 */
	public double get_Kt() {
		return _Kt;
	}
	
	/**
	 * @return the _Ks
	 */
	public double get_Ks() {
		return _Ks;
	}

	/**
	 * @return the _nShininess
	 */
	public int get_nShininess() {
		return _nShininess;
	}
}
