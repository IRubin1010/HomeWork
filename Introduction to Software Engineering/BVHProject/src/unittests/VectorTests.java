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

	// vectors to test add sub and etc. actions
	Vector vector_1 = new Vector(1, 1, 1);
	Vector vector_1e = new Vector(1.00000001, 1.00000001, 1.00000001);
	Vector vector_1me = new Vector(0.99999999, 0.99999999, 0.99999999);
	Vector vector_1n = new Vector(-1, -1, -1);
	Vector vector_1ne = new Vector(-1.00000001, -1.00000001, -1.00000001);
	Vector vector_1nme = new Vector(-0.99999999, -0.99999999, -0.99999999);
	Vector vector_2 = new Vector(2, 2, 2);
	Vector vector_2n = new Vector(-2, -2, -2);

	// vectors to test other operations

	// vector on the hinges
	Vector vectorX = new Vector(1, 0, 0);
	Vector vectorXe = new Vector(1.00000001, 0, 0);
	Vector vectorXme = new Vector(0.9999999, 0, 0);
	Vector vectorXn = new Vector(-1, 0, 0);
	Vector vectorY = new Vector(0, 1, 0);
	Vector vectorYe = new Vector(0, 1.00000001, 0);
	Vector vectorYme = new Vector(0, 0.9999999, 0);
	Vector vectorYn = new Vector(0, -1, 0);
	Vector vectorZ = new Vector(0, 0, 1);
	Vector vectorZe = new Vector(0, 0, 1.00000001);
	Vector vectorZme = new Vector(0, 0, 0.9999999);
	Vector vectorZn = new Vector(0, 0, -1);
	Vector vectorXY = new Vector(1, 1, 0);
	Vector vectorXZ = new Vector(1, 0, 1);
	Vector vectorYZ = new Vector(0, 1, 1);
	Vector vectorXnY = new Vector(-1, 1, 0);
	Vector vectorXYn = new Vector(1, -1, 0);
	Vector vectorYnZ = new Vector(0, -1, 1);
	Vector vectorYZn = new Vector(0, 1, -1);
	Vector vectorXnZ = new Vector(-1, 0, 1);
	Vector vectorXZn = new Vector(1, 0, -1);
	Vector vectorXnYn = new Vector(-1, -1, 0);
	Vector vectorYnZn = new Vector(0, -1, -1);
	Vector vectorXnZn = new Vector(-1, 0, -1);

	// not on the hinges
	Vector vector1 = new Vector(1, 2, 3);
	Vector vector1n = new Vector(-1, -2, 3);
	Vector vector2 = new Vector(2, 3, 4);
	Vector vector2n = new Vector(-2, 3, 4);

	// coordinates
	double coor1 = new Double(1);
	double coor1n = new Double(-1);
	double coor20 = new Double(20);
	double coor16 = new Double(16);
	double coor8 = new Double(8);
	double sqrt3 = Math.sqrt(3);

	/**
	 * test constructors
	 */
	@Test
	public void testConstructor() {
		// vector 0 test constructor
		try {
			new Vector(0, 0, 0);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Coordinate(0), new Coordinate(0), new Coordinate(0));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Point3D(0, 0, 0));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}

		// vector 0+e and 0-e test constructor
		try {
			new Vector(0.00000001, 0.00000001, 0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Coordinate(0.00000001), new Coordinate(0.00000001), new Coordinate(0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Point3D(0.00000001, 0.00000001, 0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(-0.00000001, -0.00000001, -0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Coordinate(-0.00000001), new Coordinate(-0.00000001), new Coordinate(-0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			new Vector(new Point3D(-0.00000001, -0.00000001, -0.00000001));
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			// not vector 0
			new Vector(0.0001, 0.0001, 0.0001);
			new Vector(new Coordinate(0.0001), new Coordinate(0.0001), new Coordinate(0.0001));
			new Vector(new Point3D(0.0001, 0.0001, 0.0001));
			new Vector(-0.0001, -0.0001, -0.0001);
			new Vector(new Coordinate(-0.0001), new Coordinate(-0.0001), new Coordinate(-0.0001));
			new Vector(new Point3D(-0.0001, -0.0001, -0.0001));
		} catch (IllegalArgumentException e) {
			fail("not expected IllegalArgumentException");
		}
	}

	/**
	 * test equals
	 */
	@Test
	public void testEquals() {
		assertEquals(vector_1.equals(vector_1e), true);
		assertEquals(vector_1.equals(vector_1me), true);
	}

	/**
	 * test add function
	 */
	@Test
	public void testAdd() {
		// add 1,1+e,1-e to vector 1
		assertEquals(vector_1.add(vector_1), vector_2);
		assertEquals(vector_1.add(vector_1e), vector_2);
		assertEquals(vector_1.add(vector_1me), vector_2);

		// add 1 to vector 1+e,1-e
		assertEquals(vector_1e.add(vector_1), vector_2);
		assertEquals(vector_1me.add(vector_1), vector_2);

		// add vector 1 to vector -1
		// need to throw exception of vector 0
		try {
			vector_1.add(vector_1n);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.add(vector_1ne);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.add(vector_1nme);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1n.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1ne.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1nme.add(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1nme.add(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
	}

	/**
	 * test sub function
	 */
	@Test
	public void testSub() {
		// sub 1,1+e,1-e from vector 2
		assertEquals(vector_2.sub(vector_1), vector_1);
		assertEquals(vector_2.sub(vector_1e), vector_1);
		assertEquals(vector_2.sub(vector_1me), vector_1);

		// sub 2 from vector 1+e,1-e
		assertEquals(vector_1.sub(vector_2), vector_1n);
		assertEquals(vector_1e.sub(vector_2), vector_1n);
		assertEquals(vector_1me.sub(vector_2), vector_1n);

		// sub vector 1 from vector 1
		// need to throw exception of vector 0
		try {
			vector_1.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.sub(vector_1e);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.sub(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1e.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1me.sub(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1me.sub(vector_1e);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
	}

	/**
	 * test scale function
	 */
	@Test
	public void testSceling() {
		// scale by 1,1+e etc.
		assertEquals(vector_1.scaleVector(1), vector_1);
		assertEquals(vector_1.scaleVector(-1), vector_1n);
		assertEquals(vector_1.scaleVector(1.00000001), vector_1);
		assertEquals(vector_1.scaleVector(0.99999999), vector_1);
		assertEquals(vector_1.scaleVector(5), new Vector(5, 5, 5));

		// scale with 0
		try {
			vector_1.scaleVector(0);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.scaleVector(0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.scaleVector(-0.00000001);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
	}

	/**
	 * test dot product
	 */
	@Test
	public void testDotProduct() {
		// 2d vectors orthogonal
		assertEquals(vectorX.dotProduct(vectorY), 0,1e-7);
		assertEquals(vectorX.dotProduct(vectorYn), 0,1e-7);
		assertEquals(vectorXn.dotProduct(vectorY), 0,1e-7);
		assertEquals(vectorXn.dotProduct(vectorYn), 0,1e-7);
		assertEquals(vectorZ.dotProduct(vectorYn), 0,1e-7);
		assertEquals(vectorZ.dotProduct(vectorXn), 0,1e-7);
		assertEquals(vectorZ.dotProduct(vectorX), 0,1e-7);

		// 3d vectors orthogonal
		assertEquals(vectorXY.dotProduct(vectorZ), 0,1e-7);
		assertEquals(vectorXY.dotProduct(vectorZn), 0,1e-7);
		assertEquals(vectorYZ.dotProduct(vectorX), 0,1e-7);
		assertEquals(vectorYZ.dotProduct(vectorXn), 0,1e-7);
		assertEquals(vectorXZ.dotProduct(vectorY), 0,1e-7);
		assertEquals(vectorXZ.dotProduct(vectorYn), 0,1e-7);

		// 3d vectors 45 degree
		assertEquals(vectorXY.dotProduct(vectorX), coor1, 1e-7);
		assertEquals(vectorXY.dotProduct(vectorY), coor1, 1e-7);
		assertEquals(vectorXZ.dotProduct(vectorX), coor1, 1e-7);
		assertEquals(vectorXZ.dotProduct(vectorZ), coor1, 1e-7);
		assertEquals(vectorYZ.dotProduct(vectorY), coor1, 1e-7);
		assertEquals(vectorYZ.dotProduct(vectorZ), coor1, 1e-7);

		// 3d vectors 135 degree
		assertEquals(vectorXY.dotProduct(vectorXn), coor1n, 1e-7);
		assertEquals(vectorXY.dotProduct(vectorYn), coor1n, 1e-7);
		assertEquals(vectorXZ.dotProduct(vectorXn), coor1n, 1e-7);
		assertEquals(vectorXZ.dotProduct(vectorZn), coor1n, 1e-7);
		assertEquals(vectorYZ.dotProduct(vectorYn), coor1n, 1e-7);
		assertEquals(vectorYZ.dotProduct(vectorZn), coor1n, 1e-7);

		// 3d vectors 315 degree
		assertEquals(vectorX.dotProduct(vectorXnYn), coor1n, 1e-7);
		assertEquals(vectorY.dotProduct(vectorYnZn), coor1n, 1e-7);
		assertEquals(vectorZ.dotProduct(vectorXnZn), coor1n, 1e-7);

		// 3d vectors 270 degree
		assertEquals(vectorX.dotProduct(vectorXYn), coor1, 1e-7);
		assertEquals(vectorY.dotProduct(vectorXY), coor1, 1e-7);
		assertEquals(vectorZ.dotProduct(vectorYZ), coor1, 1e-7);

		// 3d vectors
		assertEquals(vector1.dotProduct(vector2), coor20, 1e-7);
		assertEquals(vector1.dotProduct(vector2n), coor16, 1e-7);
		assertEquals(vector1n.dotProduct(vector2n), coor8, 1e-7);
	}

	/**
	 * test length function
	 */
	@Test
	public void testLength() {
		// 1,1+e,1-e
		assertEquals(vector_1.size(), sqrt3, 1e-7);
		assertEquals(vector_1e.size(), sqrt3, 1e-7);
		assertEquals(vector_1me.size(), sqrt3, 1e-7);
	}

	/**
	 * test normalize function
	 */
	@Test
	public void testNormelize() {
		// 1,1+e etc.
		assertEquals(vector_1.normalize().size(), coor1, 1e-7);
		assertEquals(vector_1.normalize().size(), coor1, 1e-7);
		assertEquals(vector_1e.normalize().size(), coor1, 1e-7);
		assertEquals(vector_1me.normalize().size(), coor1, 1e-7);
		assertEquals(vector_1n.normalize().size(), coor1, 1e-7);
		assertEquals(vector_2.normalize().size(), coor1, 1e-7);
		assertEquals(vector2.normalize().size(), coor1, 1e-7);
	}

	/**
	 * test cross product function
	 */
	@Test
	public void testCrossProduct() {

		assertEquals(vectorX.crossProduct(vectorY), vectorZ);
		assertEquals(vectorXe.crossProduct(vectorYme), vectorZ);
		assertEquals(vectorXme.crossProduct(vectorYe), vectorZ);
		assertEquals(vectorXme.crossProduct(vectorYme), vectorZ);
		assertEquals(vectorY.crossProduct(vectorX), vectorZ.scaleVector(-1));
		assertEquals(vectorYe.crossProduct(vectorXme), vectorZ.scaleVector(-1));
		assertEquals(vectorYme.crossProduct(vectorXe), vectorZ.scaleVector(-1));
		assertEquals(vectorYme.crossProduct(vectorXme), vectorZ.scaleVector(-1));

		// same vector return vector 0
		// need to throw vector 0 exception
		try {
			vector_1.crossProduct(vector_1);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.crossProduct(vector_1n);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
		try {
			vector_1.crossProduct(vector_1me);
			fail("expected IllegalArgumentException");
		} catch (IllegalArgumentException e) {
		}
	}
}
