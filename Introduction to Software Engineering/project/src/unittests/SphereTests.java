package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import javax.swing.plaf.synth.SynthStyle;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Sphere;
import primitives.Color;
import primitives.Coordinate;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;
import scene.Scene;

class SphereTests {

    
	@Test
	private List<Point3D> getIntersections(Scene scene, Sphere sphere){
		System.out.println("===============================================");
		List<Point3D> list = new ArrayList<>();
		for(int i = 1 ; i < 4 ;++i) {
			for (int j = 1; j < 4; ++j) {
				Ray r = scene.get_camera().constructorRay(3, 3, i, j, scene.get_distance(), 9, 9);
				System.out.println(r);
				list.addAll(sphere.findIntersections(r));
			}
		}
		System.out.println("===============================================");
		return list;
	}
	
	 @Test
		void testFindIntersections() {
	        Scene scene = new Scene("test scene");
	        Camera camera = new Camera(new Vector(0,-1,0),new Vector(0,0,-1),new Point3D(0,0,0.5));
	        scene.set_camera(camera);
	        scene.set_distance(4);

			//2 points
	        Sphere sphere1 = new Sphere(new Point3D(0,0,-7),new Coordinate(1), new Color(255,255,255));
	        List<Point3D> list1 = getIntersections(scene,sphere1);
	        if(list1 != null)
	            assertEquals(2,list1.size(),"2 points");
			else
			    fail("null list");
	        //18 points
	        Sphere sphere2 = new Sphere(new Point3D(0,0,-3),new Coordinate(3), new Color(255,255,255));
	        List<Point3D> list2 = getIntersections(scene,sphere2);
	        if(list2!=null)
	            assertEquals(18,list2.size(),"18 points");
	        else
	            fail("null list");
	        //10 points
	        Sphere sphere3 = new Sphere(new Point3D(0,0,-3),new Coordinate(2.5), new Color(255,255,255));
	        List<Point3D> list3 = getIntersections(scene,sphere3);
	        if(list3!=null)
	            assertEquals(10,list3.size(),"10 points");
	        else
	            fail("null list");
	        //9 points
	        Sphere sphere4 = new Sphere(new Point3D(0,0,0),new Coordinate(3), new Color(255,255,255));
	        List<Point3D> list4 = getIntersections(scene,sphere4);
	        if(list4!=null)
	            assertEquals(9,list4.size(),"9 points");
	        else
	            fail("null list");
	        //0 points
	        Sphere sphere5 = new Sphere(new Point3D(0,0,5),new Coordinate(3), new Color(255,255,255));
	        List<Point3D> list5 = getIntersections(scene,sphere5);
	        if(list5!=null)
	            assertEquals(0,list5.size(),"0 points");
	        else
	            fail("null list");
	    }
	
}
