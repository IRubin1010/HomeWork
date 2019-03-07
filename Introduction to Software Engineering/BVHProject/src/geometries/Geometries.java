/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */
package geometries;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import primitives.Point3D;
import primitives.Ray;

/**
 * Class represent a collection of shapes Class inherits from Geometry and
 * should deal with the collection of shapes as a single form according to the
 * principle of structural pattern - composite
 */
public class Geometries extends BoundinBox {

	/**
	 * List hold all the shapes that make up the structure
	 */
	private List<BoundinBox> listShape = new ArrayList<BoundinBox>();

	private BoundinBox _geometry;

	/***************** Getter ****************************/

	/**
	 * get list of geometries
	 * 
	 * @return the geometries list
	 */
	public List<BoundinBox> getGeometries() {
		return listShape;
	}

	/***************** Operations ************************/

	/**
	 * Add geometry to the geometries
	 * 
	 * @param geometry
	 *            Geometry to add
	 */
	public void addGeometry(BoundinBox geometry) {
		_geometry = geometry;
		setMinMax();
		this.listShape.add(geometry);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.Intersectable#findIntersections(primitives.Ray)
	 */
	@Override
	public Map<Geometry, List<Point3D>> findIntersections(Ray ray) {
		Map<Geometry, List<Point3D>> intersections = new HashMap<>();
		if (isIntersectedBox(ray)) {
			for (BoundinBox shape : listShape) {
				intersections.putAll(shape.findIntersections(ray));
			}
		}
		return intersections;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see geometries.BoundinBox#setMinMax()
	 */
	@Override
	protected void setMinMax() {
		if (_geometry.minX < minX)
			minX = _geometry.minX;
		if (_geometry.maxX > maxX)
			maxX = _geometry.maxX;
		if (_geometry.minY < minY)
			minY = _geometry.minY;
		if (_geometry.maxY > maxY)
			maxY = _geometry.maxY;
		if (_geometry.minZ < minZ)
			minZ = _geometry.minZ;
		if (_geometry.maxZ > maxZ)
			maxZ = _geometry.maxZ;
	}

}
