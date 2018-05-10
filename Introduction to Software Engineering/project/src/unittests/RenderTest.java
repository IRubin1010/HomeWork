package unittests;

//import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;
import geometries.*;
import primitives.*;
import elements.Camera;
import scene.Scene;
//import java.awt.Color;
import renderer.*;


public class RenderTest {
	
	@Test
	public void aviImage(){
		Scene scene = new Scene("Avi scene");
		scene.set_camera(new Camera( new Vector(0, -1, 0), new Vector(0, 0, 1),new Point3D(0, 0, 0)));
		scene.set_distance(100);
		scene.set_backGround(new Color(135,206,250));
		Geometries geometries = new Geometries();
		scene.set_geometries(geometries);

		geometries.addGeometry(new Triangle(new Point3D(-150,   0, 149),
											new Point3D(  75,   0, 149),
											new Point3D(  75, -50, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-150,   0, 149),
											new Point3D(  75, -50, 149),
											new Point3D(-150, -50, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
				 							new Point3D(  50, -200, 149),
				 							new Point3D(  50, -150, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
				 			 				new Point3D(  50, -150, 149),
				 			 				new Point3D(-150, -150, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(   0, -200, 149),
											new Point3D(  50, -200, 149),
											new Point3D(  50,    0, 149)));

		geometries.addGeometry(new Triangle(new Point3D(   0, -200, 149),
	 										new Point3D(  50,    0, 149),
	 										new Point3D(   0,    0, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
											new Point3D(-200, -200, 149),
											new Point3D(-200, -100, 149)));

		geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
											new Point3D(-250, -100, 149),
											new Point3D(-200, -100, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
											new Point3D( 150, -200, 149),
											new Point3D( 350,    0, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
											new Point3D( 300,    0, 149),
											new Point3D( 350,    0, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
											new Point3D( 325, -200, 149),
											new Point3D( 325, -125, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
											new Point3D( 275, -125, 149),
											new Point3D( 325, -125, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
											new Point3D( 325, -125, 149),
											new Point3D( 275,  -75, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
											new Point3D( 275,  -75, 149),
											new Point3D( 250, -100, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
											new Point3D( 150, -100, 149),
											new Point3D( 150,    0, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
											new Point3D( 100,    0, 149),
											new Point3D( 150,    0, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
											new Point3D( 100, -100, 149),
											new Point3D( 150, -100, 149)));

		geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
											new Point3D( 150, -100, 149),
											new Point3D( 175, -125, 149)));
		
		ImageWriter imageWriter = new ImageWriter("AVI", 500, 500, 500, 500);
		Render render = new Render( scene,imageWriter);
		
		render.renderImage();
		//render.printGrid(50);
		render.writeToImage();
	}

	@Test
	public void basicRendering(){
		Scene scene = new Scene("Test scene");
		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.set_distance(100);
		scene.set_backGround(new Color(0, 0, 0));
		Geometries geometries = new Geometries();
		scene.set_geometries(geometries);
		geometries.addGeometry(new Sphere(new Point3D(0, 0, 150), new Coordinate(66), new Color(255,255,255)));

		geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
				 							new Point3D(  0, 150, 149),
				 							new Point3D( 150, 150, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
				 			 				new Point3D(  0, -150, 149),
				 			 				new Point3D( 150,-150, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
				 							new Point3D(  0, 150, 149),
				 							new Point3D(-150, 150, 149)));
		
		geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
				 			 				new Point3D(  0,  -150, 149),
				 			 				new Point3D(-150, -150, 149)));
		
		ImageWriter imageWriter = new ImageWriter("test0", 500, 500, 500, 500);
		Render render = new Render(scene, imageWriter);
		
		render.renderImage();
		render.printGrid(50);
		render.writeToImage();
	}
}