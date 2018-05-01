package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.Collection;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Sphere;
import primitives.Coordinate;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;

class SphereTests {

	private ArrayList<Point3D> getIntersections(Camera camera, Sphere sphere){
        ArrayList<Point3D> list = new ArrayList<Point3D>();
        for(int i = 1 ; i < 4 ;++i) {
            for (int j = 1; j < 4; ++j) {
                Ray r = camera.constructorRay(3, 3, i, j, 1, 9, 9);
                list.addAll((Collection<? extends Point3D>) sphere.findIntersection(r));
            }
        }
        return list;
    }
	@Test
	void testIntersectionPoints() {
		Sphere sphere = new Sphere(new Point3D(0,0,-3),new Coordinate(3));
		Camera camera = new Camera(new Vector(0,-1,0), new Vector(0,0,-1), new Point3D(0,0,0.5));
		ArrayList<Point3D> list = getIntersections(camera, sphere);
		if(list != null) {
			assertEquals(18,list.size());
			
		}
		else {
			fail("jkshdfk");
		}
	}

}
