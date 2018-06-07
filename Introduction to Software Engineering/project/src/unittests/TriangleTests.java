/**
 * 
 */
package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Geometry;
import geometries.Triangle;
import primitives.Color;
import primitives.Material;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;
import scene.Scene;

/**
 * @author itzik yeret
 *
 */
class TriangleTests {

	private ArrayList<Point3D> getIntersections(Scene scene, Triangle triangle){
		ArrayList<Point3D> list = new ArrayList<>();
		for(int i = 1 ; i < 4 ;++i) {
			for (int j = 1; j < 4; ++j) {
				Ray r = scene.get_camera().constructRayThroghPixel(3, 3, i, j, scene.get_distance(), 9, 9);
				Map<Geometry, List<Point3D>> map = triangle.findIntersections(r);
				if(!map.isEmpty())
					list.addAll(map.get(triangle));
			}
		}
		return list;
	}
	
	@Test
	public void testFindIntersections() {
		Scene scene = new Scene("test scene");
        Camera camera = new Camera(new Vector(0,-1,0),new Vector(0,0,-1),new Point3D(0,0,0.5));
        scene.set_camera(camera);
        scene.set_distance(4);
        
        // 7 points
        Triangle triangle1 = new Triangle(new Point3D(-5,-5,-2),new Point3D(-5,5,-2),new Point3D(5,0,-2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list1 = getIntersections(scene, triangle1);
        if(list1 != null) {
        	assertEquals(7, list1.size());
        }
        else {
        	fail("null list");
        }
        
        // 9 points
        Triangle triangle2 = new Triangle(new Point3D(-5,-10,-2),new Point3D(-5,10,-2),new Point3D(5,0,-2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list2 = getIntersections(scene, triangle2);
        if(list2 != null) {
        	assertEquals(9, list2.size());
        }
        else {
        	fail("null list");
        }
        
        // 5 points
        Triangle triangle3 = new Triangle(new Point3D(-3,-3,-2),new Point3D(-3,3,-2),new Point3D(5,0,-2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list3 = getIntersections(scene, triangle3);
        if(list3 != null) {
        	assertEquals(5, list3.size());
        }
        else {
        	fail("null list");
        }
        
        // 4 points
        Triangle triangle4 = new Triangle(new Point3D(-1.5,-3,-2),new Point3D(-1.5,3,-2),new Point3D(5,0,-2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list4 = getIntersections(scene, triangle4);
        if(list4 != null) {
        	assertEquals(4, list4.size());
        }
        else {
        	fail("null list");
        }
        
        // 1 points
        Triangle triangle5 = new Triangle(new Point3D(-0.5,-0.5,-2),new Point3D(-0.5,0.5,-2),new Point3D(0.5,0,-2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list5 = getIntersections(scene, triangle5);
        if(list5 != null) {
        	assertEquals(1, list5.size());
        }
        else {
        	fail("null list");
        }
        
        // 0 points
        Triangle triangle6 = new Triangle(new Point3D(-5,-10,2),new Point3D(-5,10,2),new Point3D(5,0,2), new Color(255,255,255), new Material(2,3,0, 4, 0));
        ArrayList<Point3D> list6 = getIntersections(scene, triangle6);
        if(list6 != null) {
        	assertEquals(0, list6.size());
        }
        else {
        	fail("null list");
        }
	}

}
