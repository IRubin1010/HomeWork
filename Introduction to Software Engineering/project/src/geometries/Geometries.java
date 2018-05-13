/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.List;

import primitives.Color;
import primitives.Point3D;
import primitives.Ray;
import primitives.Vector;

/**
 * Class represent a collection of shapes
 * Class inherits from Geometry
 * and should deal with the collection of shapes as a single form
 * according to the principle of structural pattern - composite
 */
public class Geometries extends Geometry {
	/**
	 * List hold all the shapes that make up the structure
	 */
	private List<Geometry> listShape = new ArrayList<Geometry>();
	
	/**
	 * empty constructor that initializes the list to arrayList
	 */
	public Geometries() {
		super(new Color(0,0,0));
	}
	
	/**
	 * copy constructor
	 * @param geometries
	 */
	public Geometries(Geometries geometries) {
		super(new Color(0,0,0));
		listShape = geometries.getGeometries();
	}
	
	/***************** Getter ****************************/

	public List<Geometry> getGeometries() {
		return listShape;
	}
	
	/***************** Operations ************************/

	/**
	 * Add geometry to the scene
	 * 
	 * @param geometry
	 *            - Geometry to add
	 */
	public void addGeometry(Geometry geometry) {
		this.listShape.add(geometry);
	}


	/**
	 * override getNoraml
	 * @return null because there is no normal to the collection of shapes
	 */
	@Override
	public Vector getNormal(Point3D point) {
		return null;
	}

	/**
	 * override findIntersections
	 * @param ray - the ray for which you want the cut points with the shapes
	 */
	@Override
	public List<Point3D> findIntersections(Ray ray) {
		List<Point3D> list = new ArrayList<Point3D>();
		for(Geometry shape : listShape) {
			list.addAll(shape.findIntersections(ray));
		}
		return list;
	}

}
