/**
 * 
 */
package unittests;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import geometries.*;
import primitives.*;

/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
class PlaneTests {
	
	Plane planeXY = new Plane(new Point3D(1,0,0),new Point3D(0,1,0),new Point3D(1,1,0));
	Plane planeXZ = new Plane(new Point3D(0,0,0),new Vector(0,1,0));
	// plane z = x + y
	Plane crookedPlane = new Plane(new Point3D(0,0,0),new Point3D(1,1,2),new Point3D(1,0,1));
	// plane z = x + y + 1, there is no point 0
	// constructor with point and plumb
	Plane crookedPlaneNo0PointPlumbConstructor = new Plane(new Point3D(0,0,1),new Vector(-1,-1,1));
	// plane z = x + y + 1, there is no point 0
	// constructor with 3 points
	Plane crookedPlaneNo0Point = new Plane(new Point3D(0,0,1),new Point3D(1,0,2),new Point3D(0,1,2));
	
	Vector XYnormal = new Vector(0,0,-1);
	Vector XZnormal = new Vector(0,1,0);
	Vector crookedPlaneNormal = new Vector(1,1,-1).normalize();

	@Test
	public void testConstructor() {
		try {
			// 2 same points
			new Plane(new Point3D(1,1,1),new Point3D(1,1,1),new Point3D(1,2,3));
			fail("expected Exeption");
		} catch (Exception e) {}
		try {
			// all 3 points are on the same line
			new Plane(new Point3D(1,1,1),new Point3D(2,2,2),new Point3D(3,3,3));
			fail("expected Exeption");
		} catch (Exception e) {}
		try {
			new Plane(new Point3D(1,1,1),new Point3D(2,1,3),new Point3D(1,2,3));
			new Plane(new Point3D(1,1,1),new Vector(1,2,3));
		} catch (Exception e) {
			fail("not expected Exeption");
		}
	}
	
	@Test
	public void testGetNormal() {
		try {
			assertEquals(XYnormal, planeXY.getNormal(new Point3D(2,2,0))); 
			assertEquals(XYnormal, planeXY.getNormal(new Point3D(1,0,0))); // normal for the same point as plane point
			assertEquals(XZnormal, planeXZ.getNormal(new Point3D(1,0,1)));
			assertEquals(XZnormal, planeXZ.getNormal(new Point3D(0,0,0))); // normal for the same point as plane point, and point 0 
			assertEquals(crookedPlaneNormal, crookedPlane.getNormal(new Point3D(1,3,4))); // Normal for crooked plane
			assertEquals(crookedPlaneNo0Point.getNormal(new Point3D(1,1,3)), crookedPlaneNo0PointPlumbConstructor.getNormal(new Point3D(1,2,4))); // check that both normals are the same - same plane
		} catch (Exception e) {
			fail("not expected Exeption");
		}
		
		// normal for points not on the plane
		try {
			planeXY.getNormal(new Point3D(2,2,1));
			fail("not expected Exeption");
		} catch (Exception e) {}
		try {
			planeXZ.getNormal(new Point3D(0,1,0));
			fail("not expected Exeption");
		} catch (Exception e) {}
		try {
			planeXY.getNormal(new Point3D(1,1,3));
			fail("not expected Exeption");
		} catch (Exception e) {}
		try {
			crookedPlaneNo0Point.getNormal(new Point3D(0,0,0));
			fail("not expected Exeption");
		} catch (Exception e) {}
	}
	
}
