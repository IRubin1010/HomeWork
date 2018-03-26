package primitives;

public class test {

	public static void main(String[] args) {
		Point3D point3d = new Point3D(1,2,3);
		Point3D point3d2 = new Point3D(3,5,7);
		System.out.println(point3d);
		System.out.println(point3d2);
		Vector vector = new Vector(4,7,2);
		System.out.println(vector);
		Vector vector2 = point3d.toVector();
		System.out.println(vector2);
		System.out.println(point3d.vectorSubtract(point3d2));
		System.out.println(point3d.addVectorToPoint(vector));
		System.out.println(point3d.distanceFrom(point3d2));
		/*
		System.out.println(vector.add(vector2));
		System.out.println(vector.sub(vector2));
		System.out.println(point3d.addPoint3D(point3d2));
		System.out.println(point3d.subPoint3D(point3d2));
		System.out.println(vector.scaleVector(3));
		System.out.println(vector.dotProduct(vector2));
		*/
		
	}

}
