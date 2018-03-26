/**
 * 
 */
package geometries;
import primitives.*;

/**
 * @author itzik yeret
 *
 */
public abstract class Geometry {

	public Geometry() {
	}
	
	public Geometry(Geometry other) {
	}
	
	public abstract Vector getNormal(Point3D point);

}
