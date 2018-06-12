package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;

import elements.Camera;
import geometries.Geometries;
import geometries.Rectangle;
import geometries.Sphere;
import lights.AmbientLight;
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

	@Test
	void BVHtest() {
		Geometries g1 = new Geometries();
		Geometries g2 = new Geometries();
		Geometries g3 = new Geometries();
		Geometries g4 = new Geometries();
		Geometries g5 = new Geometries();
		Geometries g6 = new Geometries();
		Scene scene = new Scene("Test BVH");
		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.setDistance(100);
		scene.setBackground(new Color(0, 0, 0));
		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
		Sphere sphere1 = new Sphere(new Point3D(70, 70, 80), 30, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere11 = new Sphere(new Point3D(70, 70, 80), 20, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Sphere sphere2 = new Sphere(new Point3D(-70, -70, 80), 30, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere22 = new Sphere(new Point3D(-70, -70, 80), 20, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Sphere sphere3 = new Sphere(new Point3D(70, -70, 80), 30, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere33 = new Sphere(new Point3D(70, -70, 80), 20, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Sphere sphere4 = new Sphere(new Point3D(-70, 70, 80), 30, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere44 = new Sphere(new Point3D(-70, 70, 80), 20, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Sphere sphere5 = new Sphere(new Point3D(0, 0, 80), 30, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere55 = new Sphere(new Point3D(0, 0, 80), 20, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Rectangle rectangle = new Rectangle(new Point3D(300, 300, 150), new Point3D(300, -300, 150),
				new Point3D(-300, 300, 150), new Point3D(-300, -300, 150), new Color(0, 0, 0),
				new Material(2000, 500, 10, 0, 0));
		g1.addGeometry(rectangle);
		g1.addGeometry(g2);
		g1.addGeometry(g3);
		g1.addGeometry(g4);
		g1.addGeometry(g5);
		g1.addGeometry(g6);
		g2.addGeometry(sphere1);
		g2.addGeometry(sphere11);
		g3.addGeometry(sphere2);
		g3.addGeometry(sphere22);
		g4.addGeometry(sphere3);
		g4.addGeometry(sphere33);
		g5.addGeometry(sphere4);
		g5.addGeometry(sphere44);
		g6.addGeometry(sphere5);
		g6.addGeometry(sphere55);
		scene.setGeometries(g1);
		List<LightSource> lights = new ArrayList<LightSource>();
		lights.add(new SpotLight(new Vector(-35, -35, 100), new Point3D(15, 15, -10), 10, 0, new Color(241, 60, 151))); // 151
		scene.setLights(lights);
		ImageWriter imageWriter = new ImageWriter("BVH test", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();
	}

}
