package unittests;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Geometries;
import geometries.Rectangle;
import geometries.Sphere;
import geometries.Triangle;
import lights.AmbientLight;
import lights.DirectionalLight;
import lights.LightSource;
import lights.SpotLight;
import primitives.Color;
import primitives.Material;
import primitives.Point3D;
import primitives.Vector;
import renderer.ImageWriter;
import renderer.Render;
import scene.Scene;

class BVHTests {

//	@Test
//	void BVHtest() {
//		Geometries g1 = new Geometries();
//		Geometries g2 = new Geometries();
//		Geometries g3 = new Geometries();
//		Geometries g4 = new Geometries();
//		Geometries g5 = new Geometries();
//		Geometries g6 = new Geometries();
//		Scene scene = new Scene("Test BVH");
//		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.setDistance(100);
//		scene.setBackground(new Color(0, 0, 0));
//		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
//		Sphere sphere1 = new Sphere(new Point3D(70, 70, 80), 30, new Color(0, 19, 86),
//				new Material(400, 500, 18, 0.7, 0.12));
//		Sphere sphere11 = new Sphere(new Point3D(70, 70, 80), 20, new Color(247, 59, 165),
//				new Material(300, 700, 18, 0.8, 0.2));
//		Sphere sphere2 = new Sphere(new Point3D(-70, -70, 80), 30, new Color(0, 19, 86),
//				new Material(400, 500, 18, 0.7, 0.12));
//		Sphere sphere22 = new Sphere(new Point3D(-70, -70, 80), 20, new Color(247, 59, 165),
//				new Material(300, 700, 18, 0.8, 0.2));
//		Sphere sphere3 = new Sphere(new Point3D(70, -70, 80), 30, new Color(0, 19, 86),
//				new Material(400, 500, 18, 0.7, 0.12));
//		Sphere sphere33 = new Sphere(new Point3D(70, -70, 80), 20, new Color(247, 59, 165),
//				new Material(300, 700, 18, 0.8, 0.2));
//		Sphere sphere4 = new Sphere(new Point3D(-70, 70, 80), 30, new Color(0, 19, 86),
//				new Material(400, 500, 18, 0.7, 0.12));
//		Sphere sphere44 = new Sphere(new Point3D(-70, 70, 80), 20, new Color(247, 59, 165),
//				new Material(300, 700, 18, 0.8, 0.2));
//		Sphere sphere5 = new Sphere(new Point3D(0, 0, 80), 30, new Color(0, 19, 86),
//				new Material(400, 500, 18, 0.7, 0.12));
//		Sphere sphere55 = new Sphere(new Point3D(0, 0, 80), 20, new Color(247, 59, 165),
//				new Material(300, 700, 18, 0.8, 0.2));
//		Rectangle rectangle = new Rectangle(new Point3D(300, 300, 150), new Point3D(300, -300, 150),
//				new Point3D(-300, 300, 150), new Point3D(-300, -300, 150), new Color(0, 0, 0),
//				new Material(2000, 500, 10, 0, 0));
//		g1.addGeometry(rectangle);
//		g1.addGeometry(g2);
//		g1.addGeometry(g3);
//		g1.addGeometry(g4);
//		g1.addGeometry(g5);
//		g1.addGeometry(g6);
//		g2.addGeometry(sphere1);
//		g2.addGeometry(sphere11);
//		g3.addGeometry(sphere2);
//		g3.addGeometry(sphere22);
//		g4.addGeometry(sphere3);
//		g4.addGeometry(sphere33);
//		g5.addGeometry(sphere4);
//		g5.addGeometry(sphere44);
//		g6.addGeometry(sphere5);
//		g6.addGeometry(sphere55);
//		scene.setGeometries(g1);
//		List<LightSource> lights = new ArrayList<LightSource>();
//		lights.add(new SpotLight(new Vector(-35, -35, 100), new Point3D(15, 15, -10), 10, 0, new Color(241, 60, 151)));
//		scene.setLights(lights);
//		ImageWriter imageWriter = new ImageWriter("BVH test", 500, 500, 500, 500);
//		Render testRender = new Render(scene, imageWriter);
//		testRender.renderImage();
//		testRender.writeToImage();
//	}
	
	
	
	Color red = new Color(200, 0, 0);
	Color yelow = new Color(247, 255, 32);
	Color blue = new Color(33, 118, 255);
	Color green = new Color(62, 255, 32);
	
	Material material = new Material(0, 0, 1, 0, 0);
	
	double z1 = 100;
	double z2 = 100;
	double z3 = 100;
	double z4 = 100;
	double c = 100;
	
	Geometries RGB(double x,double y) {
		Geometries g= new Geometries();
	
		Rectangle rec1 = new Rectangle(new Point3D(x, y, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), new Point3D(x + c, y + c, z1), red,material);
		Rectangle rec2 = new Rectangle(new Point3D(x + c + 1, y, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), new Point3D(x + 2 * c, y + 2 * c, z2), green,material);
		Rectangle rec3 = new Rectangle(new Point3D(x, y + c + 1, z3), new Point3D(x + c + 1, y + c + 1, z3),
				new Point3D(x, y + 2 * c + 1, z3), new Point3D(x + c + 1, y + 2 * c + 1, z3), green,material);
		Rectangle rec4 = new Rectangle(new Point3D(x + c + 1, y + c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), new Point3D(x + 2 * c + 1, y + 2 * c + 1, z4), blue,material);
		g.addGeometry(rec1);
		g.addGeometry(rec2);
		g.addGeometry(rec3);
		g.addGeometry(rec4);
		return g;
	}
	
	Geometries RYB(double x,double y) {
		Geometries g= new Geometries();
	
		Rectangle rec1 = new Rectangle(new Point3D(x, y, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), new Point3D(x + c, y + c, z1), blue,material);
		Rectangle rec2 = new Rectangle(new Point3D(x + c + 1, y, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), new Point3D(x + 2 * c + 1, y + 2 * c + 1, z2), yelow,material);
		Rectangle rec3 = new Rectangle(new Point3D(x, y + c, z3), new Point3D(x + c, y + c, z3),
				new Point3D(x, y + 2 * c + 1, z3), new Point3D(x + c + 1, y + 2 * c + 1, z3), yelow,material);
		Rectangle rec4 = new Rectangle(new Point3D(x + c + 1, y + c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), new Point3D(x + 2 * c + 1, y + 2 * c + 1, z4), red,material);
		g.addGeometry(rec1);
		g.addGeometry(rec2);
		g.addGeometry(rec3);
		g.addGeometry(rec4);
		return g;
	}
	
	
	
	Geometries RGBTriangle(double x,double y) {
		Geometries g= new Geometries();
	
		Triangle tr1 = new Triangle(new Point3D(x, y, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), red,material);
		Triangle tr2 = new Triangle( new Point3D(x + c, y + c, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), red,material);
		Triangle tr3 = new Triangle(new Point3D(x + c + 1, y, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), green,material);
		Triangle tr4 = new Triangle(new Point3D(x + 2 * c + 1, y + c + 1, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), green,material);
		Triangle tr5 = new Triangle(new Point3D(x, y + c + 1, z3), new Point3D(x + c, y + c + 1, z3),
				new Point3D(x, y + 2 * c + 1, z3), green,material);
		Triangle tr6 = new Triangle(new Point3D(x + c , y + 2 * c + 1, z3), new Point3D(x + c , y + c + 1, z3),
				new Point3D(x, y + 2 * c + 1, z3), green,material);
		Triangle tr7 = new Triangle(new Point3D(x + c + 1, y + c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), blue,material);
		Triangle tr8 = new Triangle(new Point3D(x + 2 * c + 1, y + 2 * c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), blue,material);
		g.addGeometry(tr1);
		g.addGeometry(tr2);
		g.addGeometry(tr3);
		g.addGeometry(tr4);
		g.addGeometry(tr5);
		g.addGeometry(tr6);
		g.addGeometry(tr7);
		g.addGeometry(tr8);
		return g;
	}
	
	Geometries RYBTriangle(double x,double y) {
		Geometries g= new Geometries();
	
		Triangle tr1 = new Triangle(new Point3D(x, y, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), blue,material);
		Triangle tr2 = new Triangle( new Point3D(x + c, y + c, z1), new Point3D(x + c, y, z1),
				new Point3D(x, y + c, z1), blue,material);
		Triangle tr3 = new Triangle(new Point3D(x + c + 1, y, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), yelow,material);
		Triangle tr4 = new Triangle(new Point3D(x + 2 * c + 1, y + c + 1, z2), new Point3D(x + 2 * c + 1, y, z2),
				new Point3D(x + c + 1, y + c + 1, z2), yelow,material);
		Triangle tr5 = new Triangle(new Point3D(x, y + c + 1, z3), new Point3D(x + c, y + c + 1, z3),
				new Point3D(x, y + 2 * c + 1, z3), yelow,material);
		Triangle tr6 = new Triangle(new Point3D(x + c , y + 2 * c + 1, z3), new Point3D(x + c , y + c + 1, z3),
				new Point3D(x, y + 2 * c + 1, z3), yelow,material);
		Triangle tr7 = new Triangle(new Point3D(x + c + 1, y + c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), red,material);
		Triangle tr8 = new Triangle(new Point3D(x + 2 * c + 1, y + 2 * c + 1, z4), new Point3D(x + 2 * c + 1, y + c + 1, z4),
				new Point3D(x + c + 1, y + 2 * c + 1, z4), red,material);
		g.addGeometry(tr1);
		g.addGeometry(tr2);
		g.addGeometry(tr3);
		g.addGeometry(tr4);
		g.addGeometry(tr5);
		g.addGeometry(tr6);
		g.addGeometry(tr7);
		g.addGeometry(tr8);
		return g;

	}
	
	Geometries fourOnFourRec(double x,double y) {
		Geometries g = new Geometries();
		
		g.addGeometry(RGB(x, y));
		g.addGeometry(RYB(x + 2 * c + 1, y));
		g.addGeometry(RYB(x, y + 2 * c + 1));
		g.addGeometry(RGB(x + 2 * c + 1, y + 2 * c + 1));
		return g;
	}
	
	Geometries eightOnEightRec(double x, double y) {
		Geometries g = new Geometries();
		
		g.addGeometry(fourOnFourRec(x, y));
		g.addGeometry(fourOnFourRec(x + 4 * c + 1, y));
		g.addGeometry(fourOnFourRec(x, y + 4 * c + 1));
		g.addGeometry(fourOnFourRec(x + 4 * c, y + 4 * c + 1));
		
		return g;
	}
	
	@Test
	void BVH() {
		
		Scene scene = new Scene("Test BVH");		
		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.setDistance(10);
		scene.setBackground(new Color(0, 0, 0));
		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
		List<LightSource> lights = new ArrayList<LightSource>();
		lights.add(new DirectionalLight(new Vector(0,0,1), new Color(50,50,50)));
		scene.setLights(lights);
		
		double x = -2500;
		double y = -2500;
		
		Geometries geometries = new Geometries();
		for (int i = 0; i < 6; i++) {
			Geometries g = new Geometries();
			for (int j = 0; j < 6; j++) {
				g.addGeometry(eightOnEightRec(x + j * 8 * c + 1, y  + i * 8 * c + 1));
			}
			geometries.addGeometry(g);
		}
		scene.setGeometries(geometries);
		ImageWriter imageWriter = new ImageWriter("BVHfinalTest", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();
	}


}
