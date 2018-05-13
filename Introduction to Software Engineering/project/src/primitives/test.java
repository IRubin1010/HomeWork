package primitives;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.fail;

import java.util.ArrayList;
import java.util.Collection;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.*;

public class test {

	public static void main(String[] args){
		try {
			Point3D point3d = new Point3D(1,2,3);
			Point3D point3d2 = new Point3D(3,5,7);
			System.out.println(point3d);
			System.out.println(point3d2);
			Vector vector = new Vector(4,7,2);
			System.out.println(vector);
			Vector vector2 = point3d.toVector();
			Vector vector3 = new Vector(vector2);
			//point3d2 = null;
			//Vector vector3 = new Vector(point3d2);
			//System.out.println("======" + vector3);
			System.out.println(vector2);
			System.out.println(point3d.vectorSubtract(point3d2));
			System.out.println(point3d.addVectorToPoint(vector));
			System.out.println(point3d.distanceFrom(point3d2));
			System.out.println(vector.crossProduct(vector2));
			System.out.println(vector.size());
			System.out.println(vector2.normalize());
			System.out.println("------------");
			Ray ray = new Ray(point3d, vector);
			System.out.println(ray);
			Coordinate coordinate = new Coordinate(3);
			Cylinder cylinder = new Cylinder(5,ray,coordinate);
			System.out.println(cylinder);
			
			
			System.out.println("===============================================================");
			Triangle triangle = new Triangle(new Point3D(1,1,0),new Point3D(2,1,0),new Point3D(4,5,0));
			System.out.println(triangle);
			
			Vector traingleNormal = triangle.getNormal(new Point3D(2,5,0));
			System.out.println(traingleNormal);
			System.out.println("===============================================================");
			
			Sphere sphere = new Sphere(new Point3D(0,0,0), new Coordinate(4), new Color(255,255,255));
			
			System.out.println(sphere.getNormal(new Point3D(4,0,0)));
			System.out.println("===============================================================");
			//System.out.println(new Vector(1000000000,1000000000,1000000000).add(new Vector(1.00000001,1.000000001,1.000000001)));
			Ray ray3 = new Ray(new Point3D(0,0,0),new Vector(0,1,0));
			
			Tube tube = new Tube(ray3,new Coordinate(2), new Color(255,255,255));
			System.out.println("tube");
			System.out.println(tube.getNormal(new Point3D(1,1,1)));
			
			System.out.println("======================findintersection==============================");
			Sphere sphere1 = new Sphere(new Point3D(0,0,-3),new Coordinate(3), new Color(255,255,255));
			Camera camera1 = new Camera(new Vector(0,-1,0), new Vector(0,0,-1), new Point3D(0,0,100));
			ArrayList<Point3D> list = getIntersections(camera1, sphere1);
			for (int i = 0; i < list.size(); i++) {
				System.out.println(list.get(i));
			}
			
			/*
			System.out.println(vector.add(vector2));
			System.out.println(vector.sub(vector2));
			System.out.println(point3d.addPoint3D(point3d2));
			System.out.println(point3d.subPoint3D(point3d2));
			System.out.println(vector.scaleVector(3));
			System.out.println(vector.dotProduct(vector2));
			*/
			Vector vup=new Vector(0,-1,0);
			Vector vto=new Vector(0,0,-1);
			Point3D pc=new Point3D(0,0,0);

			Camera cam=new Camera(vup, vto, pc);
			Ray ray1 = cam.constructRayThroghPixel(3, 3, 3, 3, 100, 150, 150);
			System.out.println("==================meir============");
			System.out.println(ray1);
			System.out.println("==================meir============");
			Camera camera2=new Camera(new Vector(0,-1,0), new Vector(0,0,1), Point3D.ZERO);
			Ray ray2=camera2.constructRayThroghPixel(4, 4, 2, 2, 100, 160, 160);
			Ray rayExpected2=new Ray(Point3D.ZERO, new Vector(1.0/26200,1.0/26200,1.0/262));
			System.out.println(ray2);
			System.out.println(rayExpected2);
			System.out.println("==================meir============");
		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		}
		catch (Exception e) {
			System.out.println(e.getMessage());
		}
		
	}
	
	private static ArrayList<Point3D> getIntersections(Camera camera, Sphere sphere){
        ArrayList<Point3D> list = new ArrayList<Point3D>();
        for(int i = 1 ; i < 4 ;++i) {
            for (int j = 1; j < 4; ++j) {
                Ray r = camera.constructRayThroghPixel(3, 3, i, j, 1, 9, 9);
                list.addAll((Collection<? extends Point3D>) sphere.findIntersections((r)));
            }
        }
        return list;
    }
//	void testIntersectionPoints() {
//		Sphere sphere = new Sphere(new Point3D(0,0,-3),new Coordinate(3));
//		Camera camera = new Camera(new Vector(0,-1,0), new Vector(0,0,-1), new Point3D(0,0,0.5));
//		ArrayList<Point3D> list = getIntersections(camera, sphere);
//		if(list != null) {
//			assertEquals(18,list.size());
//			
//		}
//		else {
//			fail("jkshdfk");
//		}
//	}

}
