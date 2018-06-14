package unittests;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Geometries;
import geometries.Rectangle;
import geometries.Sphere;
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
		Rectangle rec2 = new Rectangle(new Point3D(x + c, y, z2), new Point3D(x + 2 * c, y, z2),
				new Point3D(x + c, y + c, z2), new Point3D(x + 2 * c, y + 2 * c, z2), green,material);
		Rectangle rec3 = new Rectangle(new Point3D(x, y + c, z3), new Point3D(x + c, y + c, z3),
				new Point3D(x, y + 2 * c, z3), new Point3D(x + c, y + 2 * c, z3), green,material);
		Rectangle rec4 = new Rectangle(new Point3D(x + c, y + c, z4), new Point3D(x + 2 * c, y + c, z4),
				new Point3D(x + c, y + 2 * c, z4), new Point3D(x + 2 * c, y + 2 * c, z4), blue,material);
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
		Rectangle rec2 = new Rectangle(new Point3D(x + c, y, z2), new Point3D(x + 2 * c, y, z2),
				new Point3D(x + c, y + c, z2), new Point3D(x + 2 * c, y + 2 * c, z2), yelow,material);
		Rectangle rec3 = new Rectangle(new Point3D(x, y + c, z3), new Point3D(x + c, y + c, z3),
				new Point3D(x, y + 2 * c, z3), new Point3D(x + c, y + 2 * c, z3), yelow,material);
		Rectangle rec4 = new Rectangle(new Point3D(x + c, y + c, z4), new Point3D(x + 2 * c, y + c, z4),
				new Point3D(x + c, y + 2 * c, z4), new Point3D(x + 2 * c, y + 2 * c, z4), red,material);
		g.addGeometry(rec1);
		g.addGeometry(rec2);
		g.addGeometry(rec3);
		g.addGeometry(rec4);
		return g;
	}
	
	Geometries fourOnFourRec(double x,double y) {
		Geometries g = new Geometries();
		
		g.addGeometry(RGB(x, y));
		g.addGeometry(RYB(x + 2 * c, y));
		g.addGeometry(RYB(x, y + 2 * c));
		g.addGeometry(RGB(x + 2 * c, y + 2 * c));
		return g;
	}
	
	Geometries eightOnEightRec(double x, double y) {
		Geometries g = new Geometries();
		
		g.addGeometry(fourOnFourRec(x, y));
		g.addGeometry(fourOnFourRec(x + 4 * c, y));
		g.addGeometry(fourOnFourRec(x, y + 4 * c));
		g.addGeometry(fourOnFourRec(x + 4 * c, y + 4 * c));
		
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
			for (int j = 0; j < 6; j++) {
				geometries.addGeometry(eightOnEightRec(x + j * 8 * c, y  + i * 8 * c));
			}
		}
		scene.setGeometries(geometries);
		ImageWriter imageWriter = new ImageWriter("BVH", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();
	}

//	@Test
//	void BVH() {
//		
//		Color red = new Color(200, 0, 0);
//		Color yelow = new Color(247, 255, 32);
//		Color blue = new Color(33, 118, 255);
//		Color green = new Color(62, 255, 32);
//		
//		Material material = new Material(0, 0, 1, 0, 0);
//		
//		Rectangle rec11 = new Rectangle(new Point3D(2500, 2500, 100), new Point3D(2500, 2400, 100),
//				new Point3D(2400, 2500, 100), new Point3D(2400, 2400, 100), red,material);
//		Rectangle rec12 = new Rectangle(new Point3D(2500, 2400, 100), new Point3D(2500, 2300, 100),
//				new Point3D(2400, 2400, 100), new Point3D(2400, 2300, 100), yelow,material);
//		Rectangle rec13 = new Rectangle(new Point3D(2500, 2300, 100), new Point3D(2500, 2200, 100),
//				new Point3D(2400, 2300, 100), new Point3D(2400, 2200, 100), blue,material);
//		Rectangle rec14 = new Rectangle(new Point3D(2500, 2200, 100), new Point3D(2500, 2100, 100),
//				new Point3D(2400, 2200, 100), new Point3D(2400, 2100, 100), green,material);
//		Rectangle rec15 = new Rectangle(new Point3D(2500, 2100, 100), new Point3D(2500, 2000, 100),
//				new Point3D(2400, 2100, 100), new Point3D(2400, 2000, 100), red,material);
//		Rectangle rec16 = new Rectangle(new Point3D(2500, 2000, 100), new Point3D(2500, 1900, 100),
//				new Point3D(2400, 2000, 100), new Point3D(2400, 1900, 100), yelow,material);
//		Rectangle rec17 = new Rectangle(new Point3D(2500, 1900, 100), new Point3D(2500, 1800, 100),
//				new Point3D(2400, 1900, 100), new Point3D(2400, 1800, 100), blue,material);
//		Rectangle rec18 = new Rectangle(new Point3D(2500, 1800, 100), new Point3D(2500, 1700, 100),
//				new Point3D(2400, 1800, 100), new Point3D(2400, 1700, 100), green,material);
//		Rectangle rec19 = new Rectangle(new Point3D(2500, 1700, 100), new Point3D(2500, 1600, 100),
//				new Point3D(2400, 1700, 100), new Point3D(2400, 1600, 100), red,material);
//		Rectangle rec110 = new Rectangle(new Point3D(2500, 1600, 100), new Point3D(2500, 1500, 100),
//				new Point3D(2400, 1600, 100), new Point3D(2400, 1500, 100), yelow,material);
//		Rectangle rec111 = new Rectangle(new Point3D(2500, 1500, 100), new Point3D(2500, 1400, 100),
//				new Point3D(2400, 1500, 100), new Point3D(2400, 1400, 100), blue,material);
//		Rectangle rec112 = new Rectangle(new Point3D(2500, 1400, 100), new Point3D(2500, 1300, 100),
//				new Point3D(2400, 1400, 100), new Point3D(2400, 1300, 100), green,material);
//		Rectangle rec113 = new Rectangle(new Point3D(2500, 1300, 100), new Point3D(2500, 1200, 100),
//				new Point3D(2400, 1300, 100), new Point3D(2400, 1200, 100), red,material);
//		Rectangle rec114 = new Rectangle(new Point3D(2500, 1200, 100), new Point3D(2500, 1100, 100),
//				new Point3D(2400, 1200, 100), new Point3D(2400, 1100, 100), yelow,material);
//		Rectangle rec115 = new Rectangle(new Point3D(2500, 1100, 100), new Point3D(2500, 1000, 100),
//				new Point3D(2400, 1100, 100), new Point3D(2400, 1000, 100), blue,material);
//		Rectangle rec116 = new Rectangle(new Point3D(2500, 1000, 100), new Point3D(2500, 900, 100),
//				new Point3D(2400, 1000, 100), new Point3D(2400, 900, 100), green,material);
//		Rectangle rec117 = new Rectangle(new Point3D(2500, 900, 100), new Point3D(2500, 800, 100),
//				new Point3D(2400, 900, 100), new Point3D(2400, 800, 100), red,material);
//		Rectangle rec118 = new Rectangle(new Point3D(2500, 800, 100), new Point3D(2500, 700, 100),
//				new Point3D(2400, 800, 100), new Point3D(2400, 700, 100), yelow,material);
//		Rectangle rec119 = new Rectangle(new Point3D(2500, 700, 100), new Point3D(2500, 600, 100),
//				new Point3D(2400, 700, 100), new Point3D(2400, 600, 100), blue,material);
//		Rectangle rec120 = new Rectangle(new Point3D(2500, 600, 100), new Point3D(2500, 500, 100),
//				new Point3D(2400, 600, 100), new Point3D(2400, 500, 100), green,material);
//		Rectangle rec121 = new Rectangle(new Point3D(2500, 500, 100), new Point3D(2500, 400, 100),
//				new Point3D(2400, 500, 100), new Point3D(2400, 400, 100), red,material);
//		Rectangle rec122 = new Rectangle(new Point3D(2500, 400, 100), new Point3D(2500, 300, 100),
//				new Point3D(2400, 400, 100), new Point3D(2400, 300, 100), yelow,material);
//		Rectangle rec123 = new Rectangle(new Point3D(2500, 300, 100), new Point3D(2500, 200, 100),
//				new Point3D(2400, 300, 100), new Point3D(2400, 200, 100), blue,material);
//		Rectangle rec124 = new Rectangle(new Point3D(2500, 200, 100), new Point3D(2500, 100, 100),
//				new Point3D(2400, 200, 100), new Point3D(2400, 100, 100), green,material);
//		Rectangle rec125 = new Rectangle(new Point3D(2500, 100, 100), new Point3D(2500, 0, 100),
//				new Point3D(2400, 100, 100), new Point3D(2400, 0, 100), red,material);
//		Rectangle rec126 = new Rectangle(new Point3D(2500, 0, 100), new Point3D(2500, -100, 100),
//				new Point3D(2400, 0, 100), new Point3D(2400, -100, 100), yelow,material);
//		Rectangle rec127 = new Rectangle(new Point3D(2500, -100, 100), new Point3D(2500, -200, 100),
//				new Point3D(2400,-100, 100), new Point3D(2400, -200, 100), blue,material);
//		Rectangle rec128 = new Rectangle(new Point3D(2500, -200, 100), new Point3D(2500, -300, 100),
//				new Point3D(2400, -200, 100), new Point3D(2400, -300, 100), green,material);
//		Rectangle rec129 = new Rectangle(new Point3D(2500, -300, 100), new Point3D(2500, -400, 100),
//				new Point3D(2400, -300, 100), new Point3D(2400, -400, 100), red,material);
//		Rectangle rec130 = new Rectangle(new Point3D(2500, -400, 100), new Point3D(2500, -500, 100),
//				new Point3D(2400, -400, 100), new Point3D(2400, -500, 100), yelow,material);
//		Rectangle rec131 = new Rectangle(new Point3D(2500, -500, 100), new Point3D(2500, -600, 100),
//				new Point3D(2400, -500, 100), new Point3D(2400, -600, 100), blue,material);
//		Rectangle rec132 = new Rectangle(new Point3D(2500, -600, 100), new Point3D(2500, -700, 100),
//				new Point3D(2400, -600, 100), new Point3D(2400, -700, 100), green,material);
//		Rectangle rec133 = new Rectangle(new Point3D(2500, -700, 100), new Point3D(2500, -800, 100),
//				new Point3D(2400, -700, 100), new Point3D(2400, -800, 100), red,material);
//		Rectangle rec134 = new Rectangle(new Point3D(2500, -800, 100), new Point3D(2500, -900, 100),
//				new Point3D(2400, -800, 100), new Point3D(2400, -900, 100), yelow,material);
//		Rectangle rec135 = new Rectangle(new Point3D(2500, -900, 100), new Point3D(2500, -1000, 100),
//				new Point3D(2400, -900, 100), new Point3D(2400, -1000, 100), blue,material);
//		Rectangle rec136 = new Rectangle(new Point3D(2500, -1000, 100), new Point3D(2500, -1100, 100),
//				new Point3D(2400, -1000, 100), new Point3D(2400, -1100, 100), green,material);
//		Rectangle rec137 = new Rectangle(new Point3D(2500, -1100, 100), new Point3D(2500, -1200, 100),
//				new Point3D(2400, -1100, 100), new Point3D(2400, -1200, 100), red,material);
//		Rectangle rec138 = new Rectangle(new Point3D(2500, -1200, 100), new Point3D(2500, -1300, 100),
//				new Point3D(2400, -1200, 100), new Point3D(2400, -1300, 100), yelow,material);
//		Rectangle rec139 = new Rectangle(new Point3D(2500, -1300, 100), new Point3D(2500, -1400, 100),
//				new Point3D(2400, -1300, 100), new Point3D(2400, -1400, 100), blue,material);
//		Rectangle rec140 = new Rectangle(new Point3D(2500, -1400, 100), new Point3D(2500, -1500, 100),
//				new Point3D(2400, -1400, 100), new Point3D(2400, -1500, 100), green,material);
//		Rectangle rec141 = new Rectangle(new Point3D(2500, -1500, 100), new Point3D(2500, -1600, 100),
//				new Point3D(2400, -1500, 100), new Point3D(2400, -1600, 100), red,material);
//		Rectangle rec142 = new Rectangle(new Point3D(2500, -1600, 100), new Point3D(2500, -1700, 100),
//				new Point3D(2400, -1600, 100), new Point3D(2400, -1700, 100), yelow,material);
//		Rectangle rec143 = new Rectangle(new Point3D(2500, -1700, 100), new Point3D(2500, -1800, 100),
//				new Point3D(2400, -1700, 100), new Point3D(2400, -1800, 100), blue,material);
//		Rectangle rec144 = new Rectangle(new Point3D(2500, -1800, 100), new Point3D(2500, -1900, 100),
//				new Point3D(2400, -1800, 100), new Point3D(2400, -1900, 100), green,material);
//		Rectangle rec145 = new Rectangle(new Point3D(2500, -1900, 100), new Point3D(2500, -2000, 100),
//				new Point3D(2400, -1900, 100), new Point3D(2400, -2000, 100), red,material);
//		Rectangle rec146 = new Rectangle(new Point3D(2500, -2000, 100), new Point3D(2500, -2100, 100),
//				new Point3D(2400, -2000, 100), new Point3D(2400, -2100, 100), yelow,material);
//		Rectangle rec147 = new Rectangle(new Point3D(2500, -2100, 100), new Point3D(2500, -2200, 100),
//				new Point3D(2400, -2100, 100), new Point3D(2400, -2200, 100), blue,material);
//		Rectangle rec148 = new Rectangle(new Point3D(2500, -2200, 100), new Point3D(2500, -2300, 100),
//				new Point3D(2400, -2200, 100), new Point3D(2400, -2300, 100), green,material);
//		Rectangle rec149 = new Rectangle(new Point3D(2500, -2300, 100), new Point3D(2500, -2400, 100),
//				new Point3D(2400, -2300, 100), new Point3D(2400, -2400, 100), red,material);
//		Rectangle rec150 = new Rectangle(new Point3D(2500, -2400, 100), new Point3D(2500, -2500, 100),
//				new Point3D(2400, -2400, 100), new Point3D(2400, -2500, 100), yelow,material);
//		
//
//		
//		
//		Rectangle rec21 = new Rectangle(new Point3D(2400, 2500, 100), new Point3D(2400, 2400, 100),
//				new Point3D(2300, 2500, 100), new Point3D(2300, 2400, 100), yelow,material);
//		Rectangle rec22 = new Rectangle(new Point3D(2400, 2400, 100), new Point3D(2400, 2300, 100),
//				new Point3D(2300, 2400, 100), new Point3D(2300, 2300, 100), blue,material);
//		Rectangle rec23 = new Rectangle(new Point3D(2400, 2300, 100), new Point3D(2400, 2200, 100),
//				new Point3D(2300, 2300, 100), new Point3D(2300, 2200, 100), green,material);
//		Rectangle rec24 = new Rectangle(new Point3D(2400, 2200, 100), new Point3D(2400, 2100, 100),
//				new Point3D(2300, 2200, 100), new Point3D(2300, 2100, 100), red,material);
//		Rectangle rec25 = new Rectangle(new Point3D(2400, 2100, 100), new Point3D(2400, 2000, 100),
//				new Point3D(2300, 2100, 100), new Point3D(2300, 2000, 100), yelow,material);
//		Rectangle rec26 = new Rectangle(new Point3D(2400, 2000, 100), new Point3D(2400, 1900, 100),
//				new Point3D(2300, 2000, 100), new Point3D(2300, 1900, 100), blue,material);
//		Rectangle rec27 = new Rectangle(new Point3D(2400, 1900, 100), new Point3D(2400, 1800, 100),
//				new Point3D(2300, 1900, 100), new Point3D(2300, 1800, 100), green,material);
//		Rectangle rec28 = new Rectangle(new Point3D(2400, 1800, 100), new Point3D(2400, 1700, 100),
//				new Point3D(2300, 1800, 100), new Point3D(2300, 1700, 100), red,material);
//		Rectangle rec29 = new Rectangle(new Point3D(2400, 1700, 100), new Point3D(2400, 1600, 100),
//				new Point3D(2300, 1700, 100), new Point3D(2300, 1600, 100), yelow,material);
//		Rectangle rec210 = new Rectangle(new Point3D(2400, 1600, 100), new Point3D(2400, 1500, 100),
//				new Point3D(2300, 1600, 100), new Point3D(2300, 1500, 100), blue,material);
//		Rectangle rec211 = new Rectangle(new Point3D(2400, 1500, 100), new Point3D(2400, 1400, 100),
//				new Point3D(2300, 1500, 100), new Point3D(2300, 1400, 100), green,material);
//		Rectangle rec212 = new Rectangle(new Point3D(2400, 1400, 100), new Point3D(2400, 1300, 100),
//				new Point3D(2300, 1400, 100), new Point3D(2300, 1300, 100), red,material);
//		Rectangle rec213 = new Rectangle(new Point3D(2400, 1300, 100), new Point3D(2400, 1200, 100),
//				new Point3D(2300, 1300, 100), new Point3D(2300, 1200, 100), yelow,material);
//		Rectangle rec214 = new Rectangle(new Point3D(2400, 1200, 100), new Point3D(2400, 1100, 100),
//				new Point3D(2300, 1200, 100), new Point3D(2300, 1100, 100), blue,material);
//		Rectangle rec215 = new Rectangle(new Point3D(2400, 1100, 100), new Point3D(2400, 1000, 100),
//				new Point3D(2300, 1100, 100), new Point3D(2300, 1000, 100), green,material);
//		Rectangle rec216 = new Rectangle(new Point3D(2400, 1000, 100), new Point3D(2400, 900, 100),
//				new Point3D(2300, 1000, 100), new Point3D(2300, 900, 100), red,material);
//		Rectangle rec217 = new Rectangle(new Point3D(2400, 900, 100), new Point3D(2400, 800, 100),
//				new Point3D(2300, 900, 100), new Point3D(2300, 800, 100), yelow,material);
//		Rectangle rec218 = new Rectangle(new Point3D(2400, 800, 100), new Point3D(2400, 700, 100),
//				new Point3D(2300, 800, 100), new Point3D(2300, 700, 100), blue,material);
//		Rectangle rec219 = new Rectangle(new Point3D(2400, 700, 100), new Point3D(2400, 600, 100),
//				new Point3D(2300, 700, 100), new Point3D(2300, 600, 100), green,material);
//		Rectangle rec220 = new Rectangle(new Point3D(2400, 600, 100), new Point3D(2400, 500, 100),
//				new Point3D(2300, 600, 100), new Point3D(2300, 500, 100), red,material);
//		Rectangle rec221 = new Rectangle(new Point3D(2400, 500, 100), new Point3D(2400, 400, 100),
//				new Point3D(2300, 500, 100), new Point3D(2300, 400, 100), yelow,material);
//		Rectangle rec222 = new Rectangle(new Point3D(2400, 400, 100), new Point3D(2400, 300, 100),
//				new Point3D(2300, 400, 100), new Point3D(2300, 300, 100), blue,material);
//		Rectangle rec223 = new Rectangle(new Point3D(2400, 300, 100), new Point3D(2400, 200, 100),
//				new Point3D(2300, 300, 100), new Point3D(2300, 200, 100), green,material);
//		Rectangle rec224 = new Rectangle(new Point3D(2400, 200, 100), new Point3D(2400, 100, 100),
//				new Point3D(2300, 200, 100), new Point3D(2300, 100, 100), red,material);
//		Rectangle rec225 = new Rectangle(new Point3D(2400, 100, 100), new Point3D(2400, 0, 100),
//				new Point3D(2300, 100, 100), new Point3D(2300, 0, 100), yelow,material);
//		Rectangle rec226 = new Rectangle(new Point3D(2400, 0, 100), new Point3D(2400, -100, 100),
//				new Point3D(2300, 0, 100), new Point3D(2300, -100, 100), blue,material);
//		Rectangle rec227 = new Rectangle(new Point3D(2400, -100, 100), new Point3D(2400, -200, 100),
//				new Point3D(2300,-100, 100), new Point3D(2300, -200, 100), green,material);
//		Rectangle rec228 = new Rectangle(new Point3D(2400, -200, 100), new Point3D(2400, -300, 100),
//				new Point3D(2300, -200, 100), new Point3D(2300, -300, 100), red,material);
//		Rectangle rec229 = new Rectangle(new Point3D(2400, -300, 100), new Point3D(2400, -400, 100),
//				new Point3D(2300, -300, 100), new Point3D(2300, -400, 100), yelow,material);
//		Rectangle rec230 = new Rectangle(new Point3D(2400, -400, 100), new Point3D(2400, -500, 100),
//				new Point3D(2300, -400, 100), new Point3D(2300, -500, 100), blue,material);
//		Rectangle rec231 = new Rectangle(new Point3D(2400, -500, 100), new Point3D(2400, -600, 100),
//				new Point3D(2300, -500, 100), new Point3D(2300, -600, 100), green,material);
//		Rectangle rec232 = new Rectangle(new Point3D(2400, -600, 100), new Point3D(2400, -700, 100),
//				new Point3D(2300, -600, 100), new Point3D(2300, -700, 100), red,material);
//		Rectangle rec233 = new Rectangle(new Point3D(2400, -700, 100), new Point3D(2400, -800, 100),
//				new Point3D(2300, -700, 100), new Point3D(2300, -800, 100), yelow,material);
//		Rectangle rec234 = new Rectangle(new Point3D(2400, -800, 100), new Point3D(2400, -900, 100),
//				new Point3D(2300, -800, 100), new Point3D(2300, -900, 100), blue,material);
//		Rectangle rec235 = new Rectangle(new Point3D(2400, -900, 100), new Point3D(2400, -1000, 100),
//				new Point3D(2300, -900, 100), new Point3D(2300, -1000, 100), green,material);
//		Rectangle rec236 = new Rectangle(new Point3D(2400, -1000, 100), new Point3D(2400, -1100, 100),
//				new Point3D(2300, -1000, 100), new Point3D(2300, -1100, 100), red,material);
//		Rectangle rec237 = new Rectangle(new Point3D(2400, -1100, 100), new Point3D(2400, -1200, 100),
//				new Point3D(2300, -1100, 100), new Point3D(2300, -1200, 100), yelow,material);
//		Rectangle rec238 = new Rectangle(new Point3D(2400, -1200, 100), new Point3D(2400, -1300, 100),
//				new Point3D(2300, -1200, 100), new Point3D(2300, -1300, 100), blue,material);
//		Rectangle rec239 = new Rectangle(new Point3D(2400, -1300, 100), new Point3D(2400, -1400, 100),
//				new Point3D(2300, -1300, 100), new Point3D(2300, -1400, 100), green,material);
//		Rectangle rec240 = new Rectangle(new Point3D(2400, -1400, 100), new Point3D(2400, -1500, 100),
//				new Point3D(2300, -1400, 100), new Point3D(2300, -1500, 100), red,material);
//		Rectangle rec241 = new Rectangle(new Point3D(2400, -1500, 100), new Point3D(2400, -1600, 100),
//				new Point3D(2300, -1500, 100), new Point3D(2300, -1600, 100), yelow,material);
//		Rectangle rec242 = new Rectangle(new Point3D(2400, -1600, 100), new Point3D(2400, -1700, 100),
//				new Point3D(2300, -1600, 100), new Point3D(2300, -1700, 100), blue,material);
//		Rectangle rec243 = new Rectangle(new Point3D(2400, -1700, 100), new Point3D(2400, -1800, 100),
//				new Point3D(2300, -1700, 100), new Point3D(2300, -1800, 100), green,material);
//		Rectangle rec244 = new Rectangle(new Point3D(2400, -1800, 100), new Point3D(2400, -1900, 100),
//				new Point3D(2300, -1800, 100), new Point3D(2300, -1900, 100), red,material);
//		Rectangle rec245 = new Rectangle(new Point3D(2400, -1900, 100), new Point3D(2400, -2000, 100),
//				new Point3D(2300, -1900, 100), new Point3D(2300, -2000, 100), yelow,material);
//		Rectangle rec246 = new Rectangle(new Point3D(2400, -2000, 100), new Point3D(2400, -2100, 100),
//				new Point3D(2300, -2000, 100), new Point3D(2300, -2100, 100), blue,material);
//		Rectangle rec247 = new Rectangle(new Point3D(2400, -2100, 100), new Point3D(2400, -2200, 100),
//				new Point3D(2300, -2100, 100), new Point3D(2300, -2200, 100), green,material);
//		Rectangle rec248 = new Rectangle(new Point3D(2400, -2200, 100), new Point3D(2400, -2300, 100),
//				new Point3D(2300, -2200, 100), new Point3D(2300, -2300, 100), red,material);
//		Rectangle rec249 = new Rectangle(new Point3D(2400, -2300, 100), new Point3D(2400, -2400, 100),
//				new Point3D(2300, -2300, 100), new Point3D(2300, -2400, 100), yelow,material);
//		Rectangle rec250 = new Rectangle(new Point3D(2400, -2400, 100), new Point3D(2400, -2500, 100),
//				new Point3D(2300, -2400, 100), new Point3D(2300, -2500, 100), blue,material);
//		
//		
//		double x1 = 2300,x2 = 2200;
//		Rectangle rec21 = new Rectangle(new Point3D(x1, 2500, 100), new Point3D(x1, 2400, 100),
//				new Point3D(x2, 2500, 100), new Point3D(x2, 2400, 100), blue,material);
//		Rectangle rec22 = new Rectangle(new Point3D(x1, 2400, 100), new Point3D(x1, 2300, 100),
//				new Point3D(x2, 2400, 100), new Point3D(x2, 2300, 100), green,material);
//		Rectangle rec23 = new Rectangle(new Point3D(x1, 2300, 100), new Point3D(x1, 2200, 100),
//				new Point3D(x2, 2300, 100), new Point3D(x2, 2200, 100), red,material);
//		Rectangle rec24 = new Rectangle(new Point3D(x1, 2200, 100), new Point3D(x1, 2100, 100),
//				new Point3D(x2, 2200, 100), new Point3D(x2, 2100, 100), blue,material);
//		Rectangle rec25 = new Rectangle(new Point3D(x1, 2100, 100), new Point3D(x1, 2000, 100),
//				new Point3D(x2, 2100, 100), new Point3D(x2, 2000, 100), yelow,material);
//		Rectangle rec26 = new Rectangle(new Point3D(x1, 2000, 100), new Point3D(x1, 1900, 100),
//				new Point3D(x2, 2000, 100), new Point3D(x2, 1900, 100), red,material);
//		Rectangle rec27 = new Rectangle(new Point3D(x1, 1900, 100), new Point3D(x1, 1800, 100),
//				new Point3D(x2, 1900, 100), new Point3D(x2, 1800, 100), green,material);
//		Rectangle rec28 = new Rectangle(new Point3D(x1, 1800, 100), new Point3D(x1, 1700, 100),
//				new Point3D(x2, 1800, 100), new Point3D(x2, 1700, 100), blue,material);
//		Rectangle rec29 = new Rectangle(new Point3D(x1, 1700, 100), new Point3D(x1, 1600, 100),
//				new Point3D(x2, 1700, 100), new Point3D(x2, 1600, 100), yelow,material);
//		Rectangle rec210 = new Rectangle(new Point3D(x1, 1600, 100), new Point3D(x1, 1500, 100),
//				new Point3D(x2, 1600, 100), new Point3D(x2, 1500, 100), red,material);
//		Rectangle rec211 = new Rectangle(new Point3D(x1, 1500, 100), new Point3D(x1, 1400, 100),
//				new Point3D(x2, 1500, 100), new Point3D(x2, 1400, 100), green,material);
//		Rectangle rec212 = new Rectangle(new Point3D(x1, 1400, 100), new Point3D(x1, 1300, 100),
//				new Point3D(x2, 1400, 100), new Point3D(x2, 1300, 100), blue,material);
//		Rectangle rec213 = new Rectangle(new Point3D(x1, 1300, 100), new Point3D(x1, 1200, 100),
//				new Point3D(x2, 1300, 100), new Point3D(x2, 1200, 100), yelow,material);
//		Rectangle rec214 = new Rectangle(new Point3D(x1, 1200, 100), new Point3D(x1, 1100, 100),
//				new Point3D(x2, 1200, 100), new Point3D(x2, 1100, 100), red,material);
//		Rectangle rec215 = new Rectangle(new Point3D(x1, 1100, 100), new Point3D(x1, 1000, 100),
//				new Point3D(x2, 1100, 100), new Point3D(x2, 1000, 100), green,material);
//		Rectangle rec216 = new Rectangle(new Point3D(x1, 1000, 100), new Point3D(x1, 900, 100),
//				new Point3D(x2, 1000, 100), new Point3D(x2, 900, 100), blue,material);
//		Rectangle rec217 = new Rectangle(new Point3D(x1, 900, 100), new Point3D(x1, 800, 100),
//				new Point3D(x2, 900, 100), new Point3D(x2, 800, 100), yelow,material);
//		Rectangle rec218 = new Rectangle(new Point3D(x1, 800, 100), new Point3D(x1, 700, 100),
//				new Point3D(x2, 800, 100), new Point3D(x2, 700, 100), red,material);
//		Rectangle rec219 = new Rectangle(new Point3D(x1, 700, 100), new Point3D(x1, 600, 100),
//				new Point3D(x2, 700, 100), new Point3D(x2, 600, 100), green,material);
//		Rectangle rec220 = new Rectangle(new Point3D(x1, 600, 100), new Point3D(x1, 500, 100),
//				new Point3D(x2, 600, 100), new Point3D(x2, 500, 100), blue,material);
//		Rectangle rec221 = new Rectangle(new Point3D(x1, 500, 100), new Point3D(x1, 400, 100),
//				new Point3D(x2, 500, 100), new Point3D(x2, 400, 100), yelow,material);
//		Rectangle rec222 = new Rectangle(new Point3D(x1, 400, 100), new Point3D(x1, 300, 100),
//				new Point3D(x2, 400, 100), new Point3D(x2, 300, 100), red,material);
//		Rectangle rec223 = new Rectangle(new Point3D(x1, 300, 100), new Point3D(x1, 200, 100),
//				new Point3D(x2, 300, 100), new Point3D(x2, 200, 100), green,material);
//		Rectangle rec224 = new Rectangle(new Point3D(x1, 200, 100), new Point3D(x1, 100, 100),
//				new Point3D(x2, 200, 100), new Point3D(x2, 100, 100), blue,material);
//		Rectangle rec225 = new Rectangle(new Point3D(x1, 100, 100), new Point3D(x1, 0, 100),
//				new Point3D(x2, 100, 100), new Point3D(x2, 0, 100), yelow,material);
//		Rectangle rec226 = new Rectangle(new Point3D(x1, 0, 100), new Point3D(x1, -100, 100),
//				new Point3D(x2, 0, 100), new Point3D(x2, -100, 100), red,material);
//		Rectangle rec227 = new Rectangle(new Point3D(x1, -100, 100), new Point3D(x1, -200, 100),
//				new Point3D(x2,-100, 100), new Point3D(x2, -200, 100), green,material);
//		Rectangle rec228 = new Rectangle(new Point3D(x1, -200, 100), new Point3D(x1, -300, 100),
//				new Point3D(x2, -200, 100), new Point3D(x2, -300, 100), blue,material);
//		Rectangle rec229 = new Rectangle(new Point3D(x1, -300, 100), new Point3D(x1, -400, 100),
//				new Point3D(x2, -300, 100), new Point3D(x2, -400, 100), yelow,material);
//		Rectangle rec230 = new Rectangle(new Point3D(x1, -400, 100), new Point3D(x1, -500, 100),
//				new Point3D(x2, -400, 100), new Point3D(x2, -500, 100), red,material);
//		Rectangle rec231 = new Rectangle(new Point3D(x1, -500, 100), new Point3D(x1, -600, 100),
//				new Point3D(x2, -500, 100), new Point3D(x2, -600, 100), green,material);
//		Rectangle rec232 = new Rectangle(new Point3D(x1, -600, 100), new Point3D(x1, -700, 100),
//				new Point3D(x2, -600, 100), new Point3D(x2, -700, 100), blue,material);
//		Rectangle rec233 = new Rectangle(new Point3D(x1, -700, 100), new Point3D(x1, -800, 100),
//				new Point3D(x2, -700, 100), new Point3D(x2, -800, 100), yelow,material);
//		Rectangle rec234 = new Rectangle(new Point3D(x1, -800, 100), new Point3D(x1, -900, 100),
//				new Point3D(x2, -800, 100), new Point3D(x2, -900, 100), red,material);
//		Rectangle rec235 = new Rectangle(new Point3D(x1, -900, 100), new Point3D(x1, -1000, 100),
//				new Point3D(x2, -900, 100), new Point3D(x2, -1000, 100), green,material);
//		Rectangle rec236 = new Rectangle(new Point3D(x1, -1000, 100), new Point3D(x1, -1100, 100),
//				new Point3D(x2, -1000, 100), new Point3D(x2, -1100, 100), blue,material);
//		Rectangle rec237 = new Rectangle(new Point3D(x1, -1100, 100), new Point3D(x1, -1200, 100),
//				new Point3D(x2, -1100, 100), new Point3D(x2, -1200, 100), yelow,material);
//		Rectangle rec238 = new Rectangle(new Point3D(x1, -1200, 100), new Point3D(x1, -1300, 100),
//				new Point3D(x2, -1200, 100), new Point3D(x2, -1300, 100), red,material);
//		Rectangle rec239 = new Rectangle(new Point3D(x1, -1300, 100), new Point3D(x1, -1400, 100),
//				new Point3D(x2, -1300, 100), new Point3D(x2, -1400, 100), green,material);
//		Rectangle rec240 = new Rectangle(new Point3D(x1, -1400, 100), new Point3D(x1, -1500, 100),
//				new Point3D(x2, -1400, 100), new Point3D(x2, -1500, 100), blue,material);
//		Rectangle rec241 = new Rectangle(new Point3D(x1, -1500, 100), new Point3D(x1, -1600, 100),
//				new Point3D(x2, -1500, 100), new Point3D(x2, -1600, 100), yelow,material);
//		Rectangle rec242 = new Rectangle(new Point3D(x1, -1600, 100), new Point3D(x1, -1700, 100),
//				new Point3D(x2, -1600, 100), new Point3D(x2, -1700, 100), red,material);
//		Rectangle rec243 = new Rectangle(new Point3D(x1, -1700, 100), new Point3D(x1, -1800, 100),
//				new Point3D(x2, -1700, 100), new Point3D(x2, -1800, 100), green,material);
//		Rectangle rec244 = new Rectangle(new Point3D(x1, -1800, 100), new Point3D(x1, -1900, 100),
//				new Point3D(x2, -1800, 100), new Point3D(x2, -1900, 100), blue,material);
//		Rectangle rec245 = new Rectangle(new Point3D(x1, -1900, 100), new Point3D(x1, -2000, 100),
//				new Point3D(x2, -1900, 100), new Point3D(x2, -2000, 100), yelow,material);
//		Rectangle rec246 = new Rectangle(new Point3D(x1, -2000, 100), new Point3D(x1, -2100, 100),
//				new Point3D(x2, -2000, 100), new Point3D(x2, -2100, 100), red,material);
//		Rectangle rec247 = new Rectangle(new Point3D(x1, -2100, 100), new Point3D(x1, -2200, 100),
//				new Point3D(x2, -2100, 100), new Point3D(x2, -2200, 100), green,material);
//		Rectangle rec248 = new Rectangle(new Point3D(x1, -2200, 100), new Point3D(x1, -2300, 100),
//				new Point3D(x2, -2200, 100), new Point3D(x2, -2300, 100), blue,material);
//		Rectangle rec249 = new Rectangle(new Point3D(x1, -2300, 100), new Point3D(x1, -2400, 100),
//				new Point3D(x2, -2300, 100), new Point3D(x2, -2400, 100), yelow,material);
//		Rectangle rec250 = new Rectangle(new Point3D(x1, -2400, 100), new Point3D(x1, -2500, 100),
//				new Point3D(x2, -2400, 100), new Point3D(x2, -2500, 100), red,material);
//		Geometries g1 = new Geometries();
//		g1.addGeometry(rec11);
//		g1.addGeometry(rec12);
//		g1.addGeometry(rec13);
//		g1.addGeometry(rec14);
//		g1.addGeometry(rec15);
//		g1.addGeometry(rec16);
//		g1.addGeometry(rec17);
//		g1.addGeometry(rec18);
//		g1.addGeometry(rec19);
//		g1.addGeometry(rec110);
//		g1.addGeometry(rec111);
//		g1.addGeometry(rec112);
//		g1.addGeometry(rec113);
//		g1.addGeometry(rec114);
//		g1.addGeometry(rec115);
//		g1.addGeometry(rec116);
//		g1.addGeometry(rec117);
//		g1.addGeometry(rec118);
//		g1.addGeometry(rec119);
//		g1.addGeometry(rec120);
//		g1.addGeometry(rec121);
//		g1.addGeometry(rec122);
//		g1.addGeometry(rec123);
//		g1.addGeometry(rec124);
//		g1.addGeometry(rec125);
//		g1.addGeometry(rec126);
//		g1.addGeometry(rec127);
//		g1.addGeometry(rec128);
//		g1.addGeometry(rec129);
//		g1.addGeometry(rec130);
//		g1.addGeometry(rec131);
//		g1.addGeometry(rec132);
//		g1.addGeometry(rec133);
//		g1.addGeometry(rec134);
//		g1.addGeometry(rec135);
//		g1.addGeometry(rec136);
//		g1.addGeometry(rec137);
//		g1.addGeometry(rec138);
//		g1.addGeometry(rec139);
//		g1.addGeometry(rec140);
//		g1.addGeometry(rec141);
//		g1.addGeometry(rec142);
//		g1.addGeometry(rec143);
//		g1.addGeometry(rec144);
//		g1.addGeometry(rec145);
//		g1.addGeometry(rec146);
//		g1.addGeometry(rec147);
//		g1.addGeometry(rec148);
//		g1.addGeometry(rec149);
//		g1.addGeometry(rec150);
//		
//		
//		g1.addGeometry(rec21);
//		g1.addGeometry(rec22);
//		g1.addGeometry(rec23);
//		g1.addGeometry(rec24);
//		g1.addGeometry(rec25);
//		g1.addGeometry(rec26);
//		g1.addGeometry(rec27);
//		g1.addGeometry(rec28);
//		g1.addGeometry(rec29);
//		g1.addGeometry(rec210);
//		g1.addGeometry(rec211);
//		g1.addGeometry(rec212);
//		g1.addGeometry(rec213);
//		g1.addGeometry(rec214);
//		g1.addGeometry(rec215);
//		g1.addGeometry(rec216);
//		g1.addGeometry(rec217);
//		g1.addGeometry(rec218);
//		g1.addGeometry(rec219);
//		g1.addGeometry(rec220);
//		g1.addGeometry(rec221);
//		g1.addGeometry(rec222);
//		g1.addGeometry(rec223);
//		g1.addGeometry(rec224);
//		g1.addGeometry(rec225);
//		g1.addGeometry(rec226);
//		g1.addGeometry(rec227);
//		g1.addGeometry(rec228);
//		g1.addGeometry(rec229);
//		g1.addGeometry(rec230);
//		g1.addGeometry(rec231);
//		g1.addGeometry(rec232);
//		g1.addGeometry(rec233);
//		g1.addGeometry(rec234);
//		g1.addGeometry(rec235);
//		g1.addGeometry(rec236);
//		g1.addGeometry(rec237);
//		g1.addGeometry(rec238);
//		g1.addGeometry(rec239);
//		g1.addGeometry(rec240);
//		g1.addGeometry(rec241);
//		g1.addGeometry(rec242);
//		g1.addGeometry(rec243);
//		g1.addGeometry(rec244);
//		g1.addGeometry(rec245);
//		g1.addGeometry(rec246);
//		g1.addGeometry(rec247);
//		g1.addGeometry(rec248);
//		g1.addGeometry(rec249);
//		g1.addGeometry(rec250);
//		
//		
//		Scene scene = new Scene("Test BVH");
//		
//		scene.setGeometries(g1);
//		
//		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
//		scene.setDistance(10);
//		scene.setBackground(new Color(0, 0, 0));
//		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
//		
//		List<LightSource> lights = new ArrayList<LightSource>();
//		lights.add(new DirectionalLight(new Vector(0,0,1), new Color(50,50,50)));
//		scene.setLights(lights);
//		ImageWriter imageWriter = new ImageWriter("BVH", 500, 500, 500, 500);
//		Render testRender = new Render(scene, imageWriter);
//		testRender.renderImage();
//		testRender.writeToImage();
//	}

}
