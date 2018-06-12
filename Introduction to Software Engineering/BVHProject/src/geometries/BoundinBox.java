/**
 * 
 */
package geometries;

import java.util.List;
import java.util.Map;

import primitives.Coordinate;
import primitives.Point3D;
import primitives.Ray;


/**
 * @author itzik yeret
 *
 */
public abstract class BoundinBox {

	protected double minX;
	protected double maxX;
	protected double minY;
	protected double maxY;
	protected double minZ;
	protected double maxZ;
	
	/**
	 * check if a bounding box is intersected by a ray
	 * @param ray ray to intersection with
	 * @return return true if bounding box is intersected by the ray else return false
	 */
	protected boolean isIntersectedBox(Ray ray) {
		
		Point3D rayPoint = ray.getPoint();
		Point3D rayDirection = ray.getDirection().getVector();
		
		double rayPointX = rayPoint.getX().getValue();
		double rayPointY = rayPoint.getY().getValue();
		double rayPointZ = rayPoint.getZ().getValue();
		
		double rayDirX = rayDirection.getX().getValue();
		double rayDirY = rayDirection.getY().getValue();
		double rayDirZ = rayDirection.getZ().getValue();
		
		double tMin = (minX - rayPointX) / rayDirX;
		double tMax = (maxX - rayPointX) / rayDirX;
		
		if(tMin > tMax) {
			double temp = tMin;
			tMin = tMax;
			tMax = temp;
		}
		
		double tyMin = (minY - rayPointY) / rayDirY;
		double tyMax = (maxY - rayPointY) / rayDirY;
		
		if(tyMin > tyMax) {
			double temp = tyMin;
			tyMin = tyMax;
			tyMax = temp;
		}
		
		if(tMin > tyMax || tMax < tyMin) 
			return false;
		
		if(tyMin > tMin)
			tMin = tyMin;
		
		if(tyMax < tMax)
			tMax = tyMax;
		
		double tzMin = (minZ - rayPointZ) / rayDirZ;
		double tzMax = (maxZ - rayPointZ) / rayDirZ;
		
		if(tzMin > tzMax) {
			double temp = tzMin;
			tzMin = tzMax;
			tzMax = temp;
		}
		
		if(tMin > tzMax || tMax < tzMin)
			return false;
		
		return true;
	}
	
	/**
	 * set the min and max X, Y, Z for each Geometry
	 */
	protected abstract void setMinMax();
	
	/**
	 * get the intersection with the geometry
	 * 
	 * @param ray ray to find intersections with
	 * @return Map holds a pair of geometry and list the point of intersection with
	 *         the geometry
	 */
	protected abstract Map<Geometry, List<Point3D>> findIntersections(Ray ray);

}
