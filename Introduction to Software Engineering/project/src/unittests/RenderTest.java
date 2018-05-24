package unittests;

import static org.junit.Assert.fail;

import java.util.ArrayList;
import java.util.List;

//import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;
import org.omg.CORBA.PUBLIC_MEMBER;

import geometries.*;
import primitives.*;
import elements.AmbientLight;
import elements.Camera;
import elements.LightSource;
import elements.PointLight;
import elements.SpotLight;
import scene.Scene;
//import java.awt.Color;
import renderer.*;


public class RenderTest {
	
//	@Test
//	public void aviImage(){
//		Scene scene = new Scene("Avi scene");
//		scene.set_camera(new Camera( new Vector(0, -1, 0), new Vector(0, 0, 1),new Point3D(0, 0, 0)));
//		scene.set_distance(100);
//		scene.set_background(new Color(135,206,250));
//		Geometries geometries = new Geometries();
//		scene.set_geometries(geometries);
//
//		geometries.addGeometry(new Triangle(new Point3D(-150,   0, 149),
//											new Point3D(  75,   0, 149),
//											new Point3D(  75, -50, 149), new Color(255,255,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150,   0, 149),
//											new Point3D(  75, -50, 149),
//											new Point3D(-150, -50, 149), new Color(255,255,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
//				 							new Point3D(  50, -200, 149),
//				 							new Point3D(  50, -150, 149), new Color(255,255,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
//				 			 				new Point3D(  50, -150, 149),
//				 			 				new Point3D(-150, -150, 149), new Color(255,255,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(   0, -200, 149),
//											new Point3D(  50, -200, 149),
//											new Point3D(  50,    0, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D(   0, -200, 149),
//	 										new Point3D(  50,    0, 149),
//	 										new Point3D(   0,    0, 149), new Color(255,255,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
//											new Point3D(-200, -200, 149),
//											new Point3D(-200, -100, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
//											new Point3D(-250, -100, 149),
//											new Point3D(-200, -100, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
//											new Point3D( 150, -200, 149),
//											new Point3D( 350,    0, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
//											new Point3D( 300,    0, 149),
//											new Point3D( 350,    0, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
//											new Point3D( 325, -200, 149),
//											new Point3D( 325, -125, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
//											new Point3D( 275, -125, 149),
//											new Point3D( 325, -125, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
//											new Point3D( 325, -125, 149),
//											new Point3D( 275,  -75, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
//											new Point3D( 275,  -75, 149),
//											new Point3D( 250, -100, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
//											new Point3D( 150, -100, 149),
//											new Point3D( 150,    0, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
//											new Point3D( 100,    0, 149),
//											new Point3D( 150,    0, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
//											new Point3D( 100, -100, 149),
//											new Point3D( 150, -100, 149), new Color(255,255,255)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
//											new Point3D( 150, -100, 149),
//											new Point3D( 175, -125, 149), new Color(255,255,255)));
//		
//		ImageWriter imageWriter = new ImageWriter("AVI", 500, 500, 500, 500);
//		Render render = new Render( scene,imageWriter);
//		
//		render.renderImage();
//		//render.printGrid(50);
//		render.writeToImage();
//	}
//
//	@Test
//	public void basicRendering(){
//		Scene scene = new Scene("Test scene");
//		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.set_distance(100);
//		scene.set_background(new Color(0, 0, 0));
//		Geometries geometries = new Geometries();
//		scene.set_geometries(geometries);
//		geometries.addGeometry(new Sphere(new Point3D(0, 0, 150), 66, new Color(90,70,130)));
//
//		geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
//				 							new Point3D(  0, 150, 149),
//				 							new Point3D( 150, 150, 149), new Color(255,0,0)));
//		
//		geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
//				 			 				new Point3D(  0, -150, 149),
//				 			 				new Point3D( 150,-150, 149), new Color(0,255,0)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
//				 							new Point3D(  0, 150, 149),
//				 							new Point3D(-150, 150, 149), new Color(0,0,255)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
//				 			 				new Point3D(  0,  -150, 149),
//				 			 				new Point3D(-150, -150, 149), new Color(20,20,20)));
//		
//		ImageWriter imageWriter = new ImageWriter("test0", 500, 500, 500, 500);
//		Render render = new Render(scene, imageWriter);
//		
//		render.renderImage();
//		render.printGrid(50);
//		render.writeToImage();
//	}
//	@Test
//	public void house(){
//		Scene scene = new Scene("Test scene");
//		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.set_distance(100);
//		scene.set_background(new Color(255, 255, 255));
//		Geometries geometries = new Geometries();
//		scene.set_geometries(geometries);
//		
//		geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
//											new Point3D(  0, 375, 149),
//											new Point3D(-150, 375, 149), new Color(140,17,17), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
//											new Point3D(  0, 525, 149),
//											new Point3D(0, 225, 149),  new Color(140,17,17), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
//											new Point3D(  0, 225, 149),
//											new Point3D(-75, 150, 149), new Color(255,0,0), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(-10, 187.5, 149),
//											new Point3D(  -10, 215, 149),
//											new Point3D(-37.5, 187.5, 149), new Color(255,0,0), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(0, 375, 149),
//											new Point3D(  75, 375, 149),
//											new Point3D(37.5, 337.5, 149), new Color(0,255,0), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(37.5, 375, 149),
//											new Point3D(  112.5, 375, 149),
//											new Point3D(75, 337.5, 149), new Color(0,255,0), new Material(2,3,4)));
//		
//		geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
//											new Point3D(  375, -150, 149),
//											new Point3D(375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
//											new Point3D(  0, -375, 149),
//											new Point3D(375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
//											new Point3D(  -375, -150, 149),
//											new Point3D(-375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
//		geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
//											new Point3D(  0, -375, 149),
//											new Point3D(-375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
//		
//		geometries.addGeometry(new Sphere(new Point3D(-20, 184, 150), 5, new Color(165,165,165), new Material(2,3,4)));
//		geometries.addGeometry(new Sphere(new Point3D(-20, 177, 150), 5, new Color(165,165,165), new Material(2,3,4)));
//		geometries.addGeometry(new Sphere(new Point3D(-17, 170, 150), 5, new Color(165,165,165), new Material(2,3,4)));
//		
//		geometries.addGeometry(new Sphere(new Point3D(-380, -380, 140), 50, new Color(230,230,0), new Material(2,3,4)));
//
//
//
//		ImageWriter imageWriter = new ImageWriter("house", 500, 500, 500, 500);
//		Render render = new Render(scene, imageWriter);
//		
//		render.renderImage();
//		render.printGrid(50);
//		render.writeToImage();

		

//		
//		try {
//			Triangle t1 = new Triangle(new Point3D(100, 0, -49), new Point3D(0, 100, -49), new Point3D(100, 100, -49),
//					new Color(150, 0, 0));
//			Triangle t2 = new Triangle(new Point3D(-100, 0, -49), new Point3D(0, 100, -49),
//					new Point3D(-100, 100, -49), new Color(0, 150, 0));
//			Triangle t3 = new Triangle(new Point3D(100, 0, -49), new Point3D(0, -100, -49),
//					new Point3D(100, -100, -49), new Color(0,0,150));
//			Triangle t4 = new Triangle(new Point3D(-100, 0, -49), new Point3D(0, -100, -49),
//					new Point3D(-100, -100, -49), new Color(255,255,255));
//			Sphere s = new Sphere( new Point3D(0, 0, -50),40, new Color(0,250,250));
//			Scene testScene = new Scene("testScene");
//			testScene.set_background(new Color(75, 127, 190));
//			testScene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, -1),Point3D.ZERO));
//			testScene.set_distance(50);
//			Geometries geometries = new Geometries();
//			testScene.set_geometries(geometries);
//			geometries.addGeometry(t1);
//			geometries.addGeometry(t2);
//			geometries.addGeometry(t3);
//			geometries.addGeometry(t4);
//			geometries.addGeometry(s);
//			ImageWriter testImageWriter = new ImageWriter("4TrianglesAndSphere", 500, 500, 500, 500);
//			Render testRender = new Render(testScene, testImageWriter);
//			testRender.renderImage();
//			testRender.printGrid(50);
//			testRender.writeToImage();
//		} catch (Exception e) {
//			fail(e.getMessage());
//		}
		
		
//	}
	
//	@Test
//	public void pointLightTest() {
//		Scene scene = new Scene("Test light");
//		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.set_distance(100);
//		scene.set_background(new Color(0,0,0));
//		Geometries geometries = new Geometries();
//		scene.set_geometries(geometries);
//		List<LightSource> lights = new ArrayList<LightSource>();
//		scene.set_lights(lights);
//		Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6, 151),new Material(0.9,0.8,1000));
//		geometries.addGeometry(sphere);
//		lights.add(new PointLight(new Point3D(5,5,0), 0,0, new Color(255,255,255)));
//		//lights.add(new SpotLight(new Vector(-1,37,33) ,new Point3D(0,0,0), 0,0, new Color(255,255,255)));
//		ImageWriter imageWriter = new ImageWriter("Point light test1", 500, 500, 500, 500);
//		Render testRender = new Render(scene, imageWriter);
//		testRender.renderImage();
//		//testRender.printGrid(50);
//		testRender.writeToImage();
//		//15, 7, 242
//		//255, 222, 10
//		
////		Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6, 151),new Material(0.9,0.8, 5));
////		geometries.addGeometry(sphere);
////		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
//	}
//	
//	@Test
//	public void spotLightTest() {
//		Scene scene = new Scene("Test light");
//		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.set_distance(100);
//		scene.set_background(new Color(0,0,0));
//		Geometries geometries = new Geometries();
//		scene.set_geometries(geometries);
//		List<LightSource> lights = new ArrayList<LightSource>();
//		scene.set_lights(lights);
//		Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6, 151),new Material(0.9,0.8,1000));
//		geometries.addGeometry(sphere);
//		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
//		lights.add(new SpotLight(new Vector(-1,37,33) ,new Point3D(0,0,0), 0,0, new Color(255,255,255)));
//		ImageWriter imageWriter = new ImageWriter("spot light test", 500, 500, 500, 500);
//		Render testRender = new Render(scene, imageWriter);
//		testRender.renderImage();
//		//testRender.printGrid(50);
//		testRender.writeToImage();
//		//15, 7, 242
//		//255, 222, 10
//		
////		Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6, 151),new Material(0.9,0.8, 5));
////		geometries.addGeometry(sphere);
////		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
//	}
//	
	@Test
	public void spotLightTest2() {
		Scene scene = new Scene("Test light");
		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.set_distance(100);
		scene.set_background(new Color(0,0,0));
		Geometries geometries = new Geometries();
		scene.set_geometries(geometries);
		List<LightSource> lights = new ArrayList<LightSource>();
		scene.set_lights(lights);
		Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6, 151),new Material(0.9,0.8,100));
		geometries.addGeometry(sphere);
		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
		lights.add(new SpotLight(new Vector(-50,0,80) ,new Point3D(50,0,0), 0,0, new Color(255,255,255)));
		ImageWriter imageWriter = new ImageWriter("spot light test222", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		//testRender.printGrid(50);
		testRender.writeToImage();
		//15, 7, 242
		//255, 222, 10
		
//		Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6, 151),new Material(0.9,0.8, 5));
//		geometries.addGeometry(sphere);
//		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
	}
	
	@Test
	void test2() {
			
			Sphere sphere = new Sphere(new Point3D(0,0,-250),100, new Color(50,0,0),new Material(500, 0.5, 100));
			Camera camera = new Camera(new Vector(0,-1,0), new Vector(0,0,-1),Point3D.ZERO);
			Scene scene = new Scene("test2");
			SpotLight spot = new SpotLight(new Vector(-70,0,-250).normalize(),new Point3D(70,0,0), 2,0.01, new Color(100,100,100));
			Geometries geometries = new Geometries();
			scene.set_geometries(geometries);
			geometries.addGeometry(sphere);
			scene.set_ambientlight(new AmbientLight(new Color(130,130,130),0.1));
			List<LightSource> lights = new ArrayList<LightSource>();
			scene.set_lights(lights);
			lights.add(spot);
			scene.set_background(new Color(0,0,0));
			scene.set_distance(149);
			scene.set_camera(camera);
			
			ImageWriter imageWriter = new ImageWriter("test222",250,250,250,250);
			Render render = new Render(scene, imageWriter);
			render.renderImage();
			render.writeToImage();
		}

	@Test
	public void spotLightTest3() {
		Scene scene = new Scene("Test light");
		scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.set_distance(100);
		scene.set_background(new Color(0,0,0));
		Geometries geometries = new Geometries();
		scene.set_geometries(geometries);
		List<LightSource> lights = new ArrayList<LightSource>();
		scene.set_lights(lights);
		Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6, 151),new Material(0.9,0.8,100));
		Triangle triangle1 = new Triangle(new Point3D(-250,-250,120),new Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new Material(0.9, 0.8, 100));
		Triangle triangle2 = new Triangle(new Point3D(250,250,120),new Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new Material(0.9, 0.8, 100));
		geometries.addGeometry(sphere);
		geometries.addGeometry(triangle1);
		geometries.addGeometry(triangle2);
		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
		lights.add(new SpotLight(new Vector(-30,0,80) ,new Point3D(30,0,0), 0,0, new Color(255,255,255)));
		ImageWriter imageWriter = new ImageWriter("spot light test333", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		//testRender.printGrid(50);
		testRender.writeToImage();
		//15, 7, 242
		//255, 222, 10
		
//		Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6, 151),new Material(0.9,0.8, 5));
//		geometries.addGeometry(sphere);
//		//lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new Color(255,255,255)));
	}
}