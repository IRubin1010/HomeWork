package geometries;
import primitives.*;

/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
public abstract class Geometry {

	public Geometry() {
	}
	
	public Geometry(Geometry other) {
	}
	
	public abstract Vector getNormal(Point3D point);

}
