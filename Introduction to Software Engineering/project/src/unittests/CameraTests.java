package unittests;

import primitives.*;
import elements.*;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * Junit to test Camera Class
 */
public class CameraTests {

	Vector vUp1 = new Vector(1, 2, 3);
	Vector vTo1 = new Vector(0, -3, 2);
	Vector vUp2 = new Vector(1, 3, 3);
	Vector vTo2 = new Vector(0, -3, 2);
	Point3D pc = new Point3D(1, 1, 1);

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
	
	@Test
	public void testRayConstructorThroughPixel() {
		Camera camera=new Camera(new Vector(0,-1,0), new Vector(0,0,-1), Point3D.zeroPoint);
		Ray ray=camera.constructorRay(3, 3, 3, 3, 100, 150, 150);
		Ray rayExpected=new Ray(Point3D.zeroPoint, new Vector(-1/Math.sqrt(6),1/Math.sqrt(6),-Math.sqrt((double)2/3)));
		assertEquals(ray, rayExpected);
		
		Camera camera2=new Camera(new Vector(0,-1,0), new Vector(0,0,1), Point3D.zeroPoint);
		Ray ray2=camera2.constructorRay(4, 4, 2, 2, 100, 160, 160);
		Ray rayExpected2=new Ray(Point3D.zeroPoint, new Vector(-Math.sqrt(3)/9,-Math.sqrt(3)/9,5*Math.sqrt(3)/9));
		assertEquals(ray2, rayExpected2);
	}

}
