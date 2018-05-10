package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.awt.Color;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.*;
import primitives.*;
import renderer.ImageWriter;
import renderer.Render;
import scene.Scene;

public class RenderTest {
	
	@Test
	public void basicRendering(){
		Scene scene = new Scene("Test scene");
		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.set_distance(100);
		scene.set_backGround(new Color(0, 0, 0));
		Geometries geometries = new Geometries();
		scene.set_geometries(geometries);
		scene.addGeometry(new Sphere(new Point3D(0, 0, 149), new Coordinate(50)));
		
		scene.addGeometry(new Triangle(new Point3D( 100, 0, 149),
				 							new Point3D(  0, 100, 149),
				 							
				 							new Point3D( 100, 100, 149)));
		
		scene.addGeometry(new Triangle(new Point3D( 100, 0, 149),
				 			 				new Point3D(  0, -100, 149),
				 			 				new Point3D( 100,-100, 149)));
		
		scene.addGeometry(new Triangle(new Point3D(-100, 0, 149),
				 							new Point3D(  0, 100, 149),
				 							new Point3D(-100, 100, 149)));
		
		scene.addGeometry(new Triangle(new Point3D(-100, 0, 149),
				 			 				new Point3D(  0,  -100, 149),
				 			 				new Point3D(-100, -100, 149)));
		
		ImageWriter imageWriter = new ImageWriter("test0", 500, 500, 500, 500);
		Render render = new Render(scene, imageWriter);
		
		render.renderImage();
		render.printGrid(50);
		render.writeToImage();
	}
}