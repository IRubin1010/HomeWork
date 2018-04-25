package unittests;

import primitives.*;
import elements.*;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * Junit to test Camera Class
 */
public class CameraTests {

	Vector vUp1=new Vector(1,2,3);
	Vector vTo1=new Vector(0,-3,2);
	Vector vUp2=new Vector(1,3,3);
	Vector vTo2=new Vector(0,-3,2);
	Point3D pc=new Point3D(1,1,1);
	
	@Test
	public void testConstructor() {
		try {
			new Camera(vUp2, vTo2, pc);
			fail("expected IllegalArgumentException");
		} catch (Exception e) {
		}
		try {
			new Camera(vUp1, vUp2, pc);
			fail("expected IllegalArgumentException");
		} catch (Exception e) {
		}
		try {
			new Camera(vUp1, vTo1, pc);
		} catch (Exception e) {
			fail("not expected IllegalArgumentException");
		}
		
	}
	
}
