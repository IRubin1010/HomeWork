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
	
	/**
	 * constructor
	 * @param Kd
	 * @param Ks
	 * @param nShininess
	 * @param Kr
	 * @param Kt
	 */
	public Material(double Kd, double Ks, int nShininess, double Kr, double Kt) {
		_Kd = Kd;
		_Ks = Ks;
		_nShininess = nShininess;
		_Kr = Kr;
		_Kt = Kt;
	}

	/***************** Getteres ****************************/
	
	/**
	 * @return the Kd
	 */
	public double getKd() {
		return _Kd;
	}

	/**
	 * @return the Ks
	 */
	public double getKr() {
		return _Kr;
	}
	
	/**
	 * @return the Ks
	 */
	public double getKt() {
		return _Kt;
	}
	
	/**
	 * @return the Ks
	 */
	public double getKs() {
		return _Ks;
	}

	/**
	 * @return the nShininess
	 */
	public int getNShininess() {
		return _nShininess;
	}
}
