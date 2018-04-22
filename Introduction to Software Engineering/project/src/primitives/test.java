package primitives;
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
			
			Sphere sphere = new Sphere(new Point3D(0,0,0), new Coordinate(4));
			
			System.out.println(sphere.getNormal(new Point3D(4,0,0)));
			System.out.println("===============================================================");
			System.out.println(new Vector(1000000000,1000000000,1000000000).add(new Vector(1.00000001,1.000000001,1.000000001)));
			/*
			System.out.println(vector.add(vector2));
			System.out.println(vector.sub(vector2));
			System.out.println(point3d.addPoint3D(point3d2));
			System.out.println(point3d.subPoint3D(point3d2));
			System.out.println(vector.scaleVector(3));
			System.out.println(vector.dotProduct(vector2));
			*/
		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		}
		catch (Exception e) {
			System.out.println(e.getMessage());
		}
		
	}

}
