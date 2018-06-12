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
	 * @param Kd Diffuse factor
	 * @param Ks Specular factor
	 * @param nShininess object Shininess
	 * @param Kr Reflection factor
	 * @param Kt Transparency factor
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
	 * get Kd
	 * @return the Diffuse factor
	 */
	public double getKd() {
		return _Kd;
	}

	/**
	 * get Kr
	 * @return the Reflection factor
	 */
	public double getKr() {
		return _Kr;
	}
	
	/**
	 * get Kt
	 * @return the Transparency factor
	 */
	public double getKt() {
		return _Kt;
	}
	
	/**
	 * get Ks
	 * @return the Specular factor
	 */
	public double getKs() {
		return _Ks;
	}

	/**
	 * get nShininess
	 * @return the object Shininess
	 */
	public int getNShininess() {
		return _nShininess;
	}
}
