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

	Camera camera1 = new Camera(new Vector(0,1,0), new Vector(0,0,1),Point3D.zeroPoint);
	Camera camera2 = new Camera(new Vector(0, -1, 0), new Vector(0, 0, -1),Point3D.zeroPoint);
	Camera camera3 = new Camera(new Vector(0,1,0), new Vector(0,0,-1),Point3D.zeroPoint);
	
	/**
	 * test the Constructor
	 */
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
	
	/**
	 * test to check constructorRay
	 */
	@Test
	public void testconstructorRay() {

		// camera 1 test
		
		//3X3
		Ray ray11 = camera1.constructorRay(3, 3, 1, 1, 100, 150, 150);
		Ray expectedRay11 = new Ray(Point3D.zeroPoint,new Vector(50,50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (1,1)", ray11 ,expectedRay11);
		
		Ray ray33 = camera1.constructorRay(3, 3, 3, 3, 100, 150, 150);
		Ray expectedRay33 = new Ray(Point3D.zeroPoint,new Vector(-50,-50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (3,3)", ray33 ,expectedRay33);
		
		Ray ray21 = camera1.constructorRay(3, 3, 2, 1, 100, 150, 150);
		Ray expectedRay21 = new Ray(Point3D.zeroPoint,new Vector(0,50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (2,1)", ray21 ,expectedRay21);
		
		Ray ray23 = camera1.constructorRay(3, 3, 2, 3, 100, 150, 150);
		Ray expectedRay23 = new Ray(Point3D.zeroPoint,new Vector(0,-50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (2,3)", ray23 ,expectedRay23);
		
		Ray ray12 = camera1.constructorRay(3, 3, 1, 2, 100, 150, 150);
		Ray expectedRay12 = new Ray(Point3D.zeroPoint,new Vector(50,0,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (1,2)", ray12 ,expectedRay12);
		
		Ray ray32 = camera1.constructorRay(3, 3, 3, 2, 100, 150, 150);
		Ray expectedRay32 = new Ray(Point3D.zeroPoint,new Vector(-50,0,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (3,2)", ray32 ,expectedRay32);
		
		Ray ray22 = camera1.constructorRay(3, 3, 2, 2, 100, 150, 150);
		Ray expectedRay22 = new Ray(Point3D.zeroPoint,new Vector(0,0,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X3 in pixel (2,2)", ray22 ,expectedRay22);
		
		
		//3X4 Py={1,2,3} Px={1,2,3,4}

		Ray rayS22 = camera1.constructorRay(4 ,3, 2, 2, 100, 200, 150);
		Ray expectedRayS22 = new Ray(Point3D.zeroPoint,new Vector(25,0,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X4 in pixel (2,2)", rayS22 ,expectedRayS22);
		
		Ray rayS32 = camera1.constructorRay(4,3, 3, 2, 100, 200, 150);
		Ray expectedRayS32 = new Ray(Point3D.zeroPoint,new Vector(-25,0,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X4 in pixel (3,2)", rayS32 ,expectedRayS32);
		
		Ray rayS11 = camera1.constructorRay(4, 3, 1, 1, 100, 200, 150);
		Ray expectedRayS11 = new Ray(Point3D.zeroPoint,new Vector(75,50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X4 in pixel (1,1)", rayS11 ,expectedRayS11);
		
		Ray rayS43 = camera1.constructorRay(4, 3, 4, 3, 100, 200, 150);
		Ray expectedRayS43 = new Ray(Point3D.zeroPoint,new Vector(-75,-50,100).normalize());
		assertEquals("pozitiv up to vectors testing at 3X4 in pixel (4,3)", rayS43 ,expectedRayS43);
		
		//4X3 Py={1,2,3,4} Px={1,2,3} 
		
		Ray ray_c22 = camera1.constructorRay(3, 4, 2, 2, 100, 150, 200);
		Ray expectedRay_c22 = new Ray(Point3D.zeroPoint,new Vector(0,25,100).normalize());
		assertEquals("pozitiv up to vectors testing at 4X3 in pixel (2,2)", ray_c22 ,expectedRay_c22);
		
		Ray ray_c32 = camera1.constructorRay(3, 4, 3, 2, 100, 150, 200);
		Ray expectedRay_c32 = new Ray(Point3D.zeroPoint,new Vector(-50,25,100).normalize());
		assertEquals("pozitiv up to vectors testing at 4X3 in pixel (3,2)", ray_c32 ,expectedRay_c32);
		
		Ray ray_c11 = camera1.constructorRay(3, 4, 1, 1, 100, 150, 200);
		Ray expectedRay_c11 = new Ray(Point3D.zeroPoint,new Vector(50,75,100).normalize());
		assertEquals("pozitiv up to vectors testing at 4X3 in pixel (1,1)", ray_c11 ,expectedRay_c11);
		
		Ray ray_c43 = camera1.constructorRay(3, 4, 3, 4, 100, 150, 200);
		Ray expectedRay_c43 = new Ray(Point3D.zeroPoint,new Vector(-50,-75,100).normalize());
		assertEquals("pozitiv up to vectors testing at 4X3 in pixel (4,3)", ray_c43 ,expectedRay_c43);
		
		
		// camera 2 test
		//Negative vectors.
		
		//3X3
		Ray ray1 = camera2.constructorRay(3, 3, 3, 3, 100, 150, 150);
		Ray resultRay = new Ray(Point3D.zeroPoint, new Vector(-1/Math.sqrt(6), 1/Math.sqrt(6), -(Math.sqrt((double)2/3))));
		assertEquals("Negative vectors testing at 3X3 in pixel (3,3)", ray1, resultRay);
		
		//3X3
		Ray ray_d11 = camera2.constructorRay(3, 3, 1, 1, 100, 150, 150);
		Ray expectedRay_d11 = new Ray(Point3D.zeroPoint,new Vector(50,-50,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (1,1)", ray_d11 ,expectedRay_d11);
		
		Ray ray_d33 = camera2.constructorRay(3, 3, 3, 3, 100, 150, 150);
		Ray expectedRay_d33 = new Ray(Point3D.zeroPoint,new Vector(-50,50,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (3,3)", ray_d33 ,expectedRay_d33);
		
		Ray ray_d21 = camera2.constructorRay(3, 3, 2, 1, 100, 150, 150);
		Ray expectedRay_d21 = new Ray(Point3D.zeroPoint,new Vector(0,-50,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (2,1)", ray_d21 ,expectedRay_d21);
		
		Ray ray_d23 = camera2.constructorRay(3, 3, 2, 3, 100, 150, 150);
		Ray expectedRay_d23 = new Ray(Point3D.zeroPoint,new Vector(0,50,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (2,3)", ray_d23 ,expectedRay_d23);
		
		Ray ray_d12 = camera2.constructorRay(3, 3, 1, 2, 100, 150, 150);
		Ray expectedRay_d12 = new Ray(Point3D.zeroPoint,new Vector(50,0,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (1,2)", ray_d12 ,expectedRay_d12);
		
		Ray ray_d32 = camera2.constructorRay(3, 3, 3, 2, 100, 150, 150);
		Ray expectedRay_d32 = new Ray(Point3D.zeroPoint,new Vector(-50,0,-100).normalize());
		assertEquals("negative up to vectors testing at 3X3 in pixel (3,2)", ray_d32 ,expectedRay_d32);
		
		//camera 3 test
		//vTo negative vUp positive
		
		//3X4
		
		Ray ray_e22 = camera3.constructorRay(4, 3, 2, 2, 100, 200, 150);
		Ray expectedRay_e22 = new Ray(Point3D.zeroPoint,new Vector(-25,0,-100).normalize());
		assertEquals("vTo negative vUp positive vectors testing at 3X4 in pixel (2,2)", ray_e22 ,expectedRay_e22);
		
		Ray ray_e32 = camera3.constructorRay(4, 3, 3, 2, 100, 200, 150);
		Ray expectedRay_e32 = new Ray(Point3D.zeroPoint,new Vector(25,0,-100).normalize());
		assertEquals("vTo negative vUp positive vectors testing at 3X4 in pixel (3,2)", ray_e32 ,expectedRay_e32);
		
		Ray ray_e11 = camera3.constructorRay(4, 3, 1, 1, 100, 200, 150);
		Ray expectedRay_e11 = new Ray(Point3D.zeroPoint,new Vector(-75,50,-100).normalize());
		assertEquals("vTo negative vUp positive vectors testing at 3X4 in pixel (1,1)", ray_e11 ,expectedRay_e11);
		
		Ray ray_e43 = camera3.constructorRay(4, 3, 4, 3, 100, 200, 150);
		Ray expectedRay_e43 = new Ray(Point3D.zeroPoint,new Vector(75,-50,-100).normalize());
		assertEquals("vTo negative vUp positive vectors testing at 3X4 in pixel (4,3)", ray_e43 ,expectedRay_e43);
				
		
		Camera littlCam = new Camera(new Vector(0,1,0),new Vector(0,0,1),Point3D.zeroPoint);
		Ray littl33 = littlCam.constructorRay(3,3, 3, 3, 10, 6, 6);
		Ray checklittl33 = new Ray(Point3D.zeroPoint, new Vector(-2,-2,10).normalize());
		Ray littl11 = littlCam.constructorRay(3,3,1,1,10,6,6);
		Ray checklittl11 = new Ray(Point3D.zeroPoint, new Vector(2,2,10).normalize());
		
		assertEquals("3,3",littl33,checklittl33);
		assertEquals("1,1",littl11,checklittl11);
	}
}

	
