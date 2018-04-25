/**
 * 
 */
package unittests;

import primitives.*;

import static org.junit.Assert.*;

import org.junit.Test;

/**
* @author itzik yeret 206244485 yeret82088@gmail.com
* @author meir shimon 305625295 nthr120@gmail.com
*/
public class VectorTests {

	Vector vector_1 = new Vector(1,1,1);
	Vector vector_1e = new Vector(1.00000001,1.00000001,1.00000001);
	Vector vector_1me = new Vector(0.99999999,0.99999999,0.99999999);
	Vector vector_1n = new Vector(-1,-1,-1);
	Vector vector_1ne = new Vector(-1.00000001,-1.00000001,-1.00000001);
	Vector vector_1nme = new Vector(-0.99999999,-0.99999999,-0.99999999);
	Vector vector_2 = new Vector(2,2,2);
	Vector vector_2n = new Vector(-2,-2,-2);
	
	Vector vectorX = new Vector(1,0,0);
	Vector vectorXe = new Vector(1.00000001,0,0);
	Vector vectorXme = new Vector(0.9999999,0,0);
	Vector vectorXn = new Vector(-1,0,0);
	Vector vectorY = new Vector(0,1,0);
	Vector vectorYe = new Vector(0,1.00000001,0);
	Vector vectorYme = new Vector(0,0.9999999,0);
	Vector vectorYn = new Vector(0,-1,0);
	Vector vectorZ = new Vector(0,0,1);
	Vector vectorZe = new Vector(0,0,1.00000001);
	Vector vectorZme = new Vector(0,0,0.9999999);
	Vector vectorZn = new Vector(0,0,-1);
	Vector vectorXY = new Vector(1,1,0);
	Vector vectorXZ = new Vector(1,0,1);
	Vector vectorYZ = new Vector(0,1,1);
	Vector vectorXnY = new Vector(-1,1,0);
	Vector vectorXYn = new Vector(1,-1,0);
	Vector vectorYnZ = new Vector(0,-1,1);
	Vector vectorYZn = new Vector(0,1,-1);
	Vector vectorXnZ = new Vector(-1,0,1);
	Vector vectorXZn = new Vector(1,0,-1);
	Vector vectorXnYn = new Vector(-1,-1,0);
	Vector vectorYnZn = new Vector(0,-1,-1);
	Vector vectorXnZn = new Vector(-1,0,-1);
	
	Vector vector1 = new Vector(1,2,3);
	Vector vector1n = new Vector(-1,-2,3);
	Vector vector2 = new Vector(2,3,4);
	Vector vector2n = new Vector(-2,3,4);
	
	
	Coordinate coor1 = new Coordinate(1);
	Coordinate coor1n = new Coordinate(-1);
	Coordinate coor20 = new Coordinate(20);
	Coordinate coor16 = new Coordinate(16);
	Coordinate coor8 = new Coordinate(8);
	Coordinate sqrt3 = new Coordinate(Math.sqrt(3));
	

	@Test
	public void testConstructor() {
		try {
			new Vector(0,0,0);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Coordinate(0),new Coordinate(0),new Coordinate(0));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Point3D(0,0,0));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(0.00000001,0.00000001,0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Coordinate(0.00000001),new Coordinate(0.00000001),new Coordinate(0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Point3D(0.00000001,0.00000001,0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(-0.00000001,-0.00000001,-0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Coordinate(-0.00000001),new Coordinate(-0.00000001),new Coordinate(-0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			new Vector(new Point3D(-0.00000001,-0.00000001,-0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
//			new Vector(1/26200,1/26200,1/262);
			new Vector(0.0001,0.0001,0.0001);
			new Vector(new Coordinate(0.0001),new Coordinate(0.0001),new Coordinate(0.0001));
			new Vector(new Point3D(0.0001,0.0001,0.0001));
			new Vector(-0.0001,-0.0001,-0.0001);
			new Vector(new Coordinate(-0.0001),new Coordinate(-0.0001),new Coordinate(-0.0001));
			new Vector(new Point3D(-0.0001,-0.0001,-0.0001));
		} catch (IllegalArgumentException e) {
			fail("not expected IllegalArgumentException");
		}
	}
	
	@Test
	public void testEquals() {
		assertEquals(vector_1.equals(vector_1e),true);
		assertEquals(vector_1.equals(vector_1me),true);
	}
	
	
	@Test
	public void testAdd() {
		assertEquals(vector_1.add(vector_1),vector_2);
		assertEquals(vector_1.add(vector_1e),vector_2);
		assertEquals(vector_1.add(vector_1me),vector_2);
		
		assertEquals(vector_1e.add(vector_1),vector_2);
		assertEquals(vector_1me.add(vector_1),vector_2);
		
		try {
			vector_1.add(vector_1n);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.add(vector_1ne);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.add(vector_1nme);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1n.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1ne.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1nme.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1nme.add(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
	}
	
	@Test
	public void testSub() {
		assertEquals(vector_2.sub(vector_1),vector_1);
		assertEquals(vector_2.sub(vector_1e),vector_1);
		assertEquals(vector_2.sub(vector_1me),vector_1);
		
		assertEquals(vector_1.sub(vector_2),vector_1n);
		assertEquals(vector_1e.sub(vector_2),vector_1n);
		assertEquals(vector_1me.sub(vector_2),vector_1n);
		
		try {
			vector_1.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.sub(vector_1e);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.sub(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1e.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1me.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1me.sub(vector_1e);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
	}
	
	@Test
	public void testSceling() {
		assertEquals(vector_1.scaleVector(1), vector_1);
		assertEquals(vector_1.scaleVector(-1), vector_1n);
		assertEquals(vector_1.scaleVector(1.00000001), vector_1);
		assertEquals(vector_1.scaleVector(0.99999999), vector_1);
		assertEquals(vector_1.scaleVector(5), new Vector(5,5,5));
		
		try {
			vector_1.scaleVector(0);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.scaleVector(0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.scaleVector(-0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
	}
	
	@Test
	public void testDotProduct() {
		assertEquals(vectorX.dotProduct(vectorY), Coordinate.zeroCoordinate);
		assertEquals(vectorX.dotProduct(vectorYn), Coordinate.zeroCoordinate);
		assertEquals(vectorXn.dotProduct(vectorY), Coordinate.zeroCoordinate);
		assertEquals(vectorXn.dotProduct(vectorYn), Coordinate.zeroCoordinate);
		assertEquals(vectorZ.dotProduct(vectorYn), Coordinate.zeroCoordinate);
		assertEquals(vectorZ.dotProduct(vectorXn), Coordinate.zeroCoordinate);
		assertEquals(vectorZ.dotProduct(vectorX), Coordinate.zeroCoordinate);
		
		assertEquals(vectorXY.dotProduct(vectorZ), Coordinate.zeroCoordinate);
		assertEquals(vectorXY.dotProduct(vectorZn), Coordinate.zeroCoordinate);
		assertEquals(vectorYZ.dotProduct(vectorX), Coordinate.zeroCoordinate);
		assertEquals(vectorYZ.dotProduct(vectorXn), Coordinate.zeroCoordinate);
		assertEquals(vectorXZ.dotProduct(vectorY), Coordinate.zeroCoordinate);
		assertEquals(vectorXZ.dotProduct(vectorYn), Coordinate.zeroCoordinate);
		
		assertEquals(vectorXY.dotProduct(vectorX),coor1);
		assertEquals(vectorXY.dotProduct(vectorY),coor1);
		assertEquals(vectorXZ.dotProduct(vectorX),coor1);
		assertEquals(vectorXZ.dotProduct(vectorZ),coor1);
		assertEquals(vectorYZ.dotProduct(vectorY),coor1);
		assertEquals(vectorYZ.dotProduct(vectorZ),coor1);
		
		assertEquals(vectorXY.dotProduct(vectorXn),coor1n);
		assertEquals(vectorXY.dotProduct(vectorYn),coor1n);
		assertEquals(vectorXZ.dotProduct(vectorXn),coor1n);
		assertEquals(vectorXZ.dotProduct(vectorZn),coor1n);
		assertEquals(vectorYZ.dotProduct(vectorYn),coor1n);
		assertEquals(vectorYZ.dotProduct(vectorZn),coor1n);
		
		assertEquals(vectorX.dotProduct(vectorXnYn), coor1n);
		assertEquals(vectorY.dotProduct(vectorYnZn), coor1n);
		assertEquals(vectorZ.dotProduct(vectorXnZn), coor1n);
		
		assertEquals(vectorX.dotProduct(vectorXYn), coor1);
		assertEquals(vectorY.dotProduct(vectorXY), coor1);
		assertEquals(vectorZ.dotProduct(vectorYZ), coor1);
		
		assertEquals(vector1.dotProduct(vector2),coor20);
		assertEquals(vector1.dotProduct(vector2n),coor16);
		assertEquals(vector1n.dotProduct(vector2n),coor8);		
	}
	
	@Test
	public void testLength() {
		assertEquals(vector_1.size(),sqrt3);
		assertEquals(vector_1e.size(),sqrt3);
		assertEquals(vector_1me.size(),sqrt3);
	}
	
	@Test
	public void testNormelize() {
		assertEquals(vector_1.normalize().size(),coor1);
		assertEquals(vector_1e.normalize().size(),coor1);
		assertEquals(vector_1me.normalize().size(),coor1);
		assertEquals(vector_1n.normalize().size(),coor1);
		assertEquals(vector_2.normalize().size(),coor1);
		assertEquals(vector2.normalize().size(),coor1);
	}
	
	@Test
	public void testCrossProduct() {
		assertEquals(vectorX.crossProduct(vectorY),vectorZ);
		assertEquals(vectorXe.crossProduct(vectorYme),vectorZ);
		assertEquals(vectorXme.crossProduct(vectorYe),vectorZ);
		assertEquals(vectorXme.crossProduct(vectorYme),vectorZ);
		assertEquals(vectorY.crossProduct(vectorX),vectorZ.scaleVector(-1));
		assertEquals(vectorYe.crossProduct(vectorXme),vectorZ.scaleVector(-1));
		assertEquals(vectorYme.crossProduct(vectorXe),vectorZ.scaleVector(-1));
		assertEquals(vectorYme.crossProduct(vectorXme),vectorZ.scaleVector(-1));
		
		try {
			vector_1.crossProduct(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.crossProduct(vector_1n);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
		try {
			vector_1.crossProduct(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {}
	}
}
