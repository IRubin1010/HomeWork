package test;

public class intersections {

	public static void main(String[] args) {
		System.out.println(isIntersect(-1,-1,-1,-4,12,-20));
		
		System.out.println(getMin(1,2,3));
		System.out.println(getMin(1,3,2));
		System.out.println(getMin(2,1,3));
		System.out.println(getMin(2,3,1));
		System.out.println(getMin(3,1,2));
		System.out.println(getMin(3,2,1));
		
		System.out.println(getMin(1,1,2));
		System.out.println(getMin(1,1,1));
		System.out.println(getMin(2,1,1));
		System.out.println(getMin(1,1,0));
		System.out.println(getMin(1,2,1));
		
		System.out.println("==========");
		
		System.out.println(getMax(1,2,3));
		System.out.println(getMax(1,3,2));
		System.out.println(getMax(2,1,3));
		System.out.println(getMax(2,3,1));
		System.out.println(getMax(3,1,2));
		System.out.println(getMax(3,2,1));
		
		System.out.println(getMax(1,1,2));
		System.out.println(getMax(1,1,1));
		System.out.println(getMax(2,1,1));
		System.out.println(getMax(1,1,0));
		System.out.println(getMax(1,2,1));

	}
	
	public static boolean isIntersect(double bX,double bY, double bZ, double dirX,double dirY, double dirZ) {
		int Xmin = -10;
		int Xmax = -3;
		int Ymin = 3;
		int Ymax = 8;
		int Zmin = -12;
		int Zmax = -29;
		
		double tmin = ((double)Xmin - bX)/dirX;
		double tmax = ((double)Xmax - bX)/dirX;
		
		if(tmin > tmax) {
			double temp = tmin;
			tmin = tmax;
			tmax = temp;
		}
		
		double tymin = ((double)Ymin - bY)/dirY;
		double tymax = ((double)Ymax - bY)/dirY;
		
		if(tymin > tymax) {
			double temp = tymin;
			tymin = tymax;
			tymax = temp;
		}
		
		if(tmin > tymax || tmax < tymin)
			return false;
		
		if(tymin > tmin)
			tmin = tymin;
		if(tymax < tmax)
			tmax = tymax;
		
		double tzmin = ((double)Zmin - bZ)/dirZ;
		double tzmax = ((double)Zmax - bZ)/dirZ;
		
		if(tzmin > tzmax) {
			double temp = tzmin;
			tzmin = tzmax;
			tzmax = temp;
		}
		
		if(tmin > tzmax || tmax < tzmin)
			return false;
		
		if(tzmin > tmin)
			tmin = tzmin;
		if(tzmax < tmax)
			tmax = tzmax;
		
		
		return true;
		
	}
	
	
	private static double getMin(double n1, double n2, double n3) {
		if(n1 > n2) {
			if(n2 > n3)
				return n3;
			else
				return n2;
		}else {
			if(n1 > n3)
				return n3;
			else
				return n1;
		}
	}
	
	private static double getMax(double n1, double n2, double n3) {
		if(n1 > n2) {
			if(n3 > n1)
				return n3;
			else
				return n1;
		}else {
			if(n3 > n2)
				return n3;
			else
				return n2;
		}
	}
	
}
