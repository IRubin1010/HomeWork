package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Geometries;
import geometries.Rectangle;
import geometries.Triangle;
import lights.AmbientLight;
import lights.DirectionalLight;
import lights.LightSource;
import primitives.Color;
import primitives.Material;
import primitives.Point3D;
import primitives.Vector;
import renderer.ImageWriter;
import renderer.Render;
import scene.Scene;

class notBVH {

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
	
	Geometries g = new Geometries();
	
	void RGB(double x,double y) {
	
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
	}
	
	void RYB(double x,double y) {
	
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

	}
	
	void RGBTriangle(double x,double y) {

	
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

	}
	
	void RYBTriangle(double x,double y) {

	
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


	}
	
	void fourOnFourRec(double x,double y) {
		
		RGBTriangle(x, y);
		RYBTriangle(x + 2 * c, y);
		RYBTriangle(x, y + 2 * c);
		RGBTriangle(x + 2 * c, y + 2 * c);
		
	}
	
	void eightOnEightRec(double x, double y) {
		
		fourOnFourRec(x, y);
		fourOnFourRec(x + 4 * c, y);
		fourOnFourRec(x, y + 4 * c);
		fourOnFourRec(x + 4 * c, y + 4 * c);
		
		
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
		
		//Geometries geometries = new Geometries();
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 6; j++) {
				eightOnEightRec(x + j * 8 * c, y  + i * 8 * c);
			}
		}
		scene.setGeometries(g);
		ImageWriter imageWriter = new ImageWriter("notBVH", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();
	}

}
