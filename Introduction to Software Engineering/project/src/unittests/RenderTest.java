package unittests;

import java.util.ArrayList;
import java.util.List;

//import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

import geometries.*;
import primitives.*;
import lights.AmbientLight;
import elements.Camera;
import lights.DirectionalLight;
import lights.LightSource;
import lights.PointLight;
import lights.SpotLight;
import scene.Scene;
//import java.awt.Color;
import renderer.*;

public class RenderTest {

	// @Test
	// public void aviImage(){
	// Scene scene = new Scene("Avi scene");
	// scene.set_camera(new Camera( new Vector(0, -1, 0), new Vector(0, 0, 1),new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(135,206,250));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
	// new Point3D( 75, 0, 149),
	// new Point3D( 75, -50, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
	// new Point3D( 75, -50, 149),
	// new Point3D(-150, -50, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
	// new Point3D( 50, -200, 149),
	// new Point3D( 50, -150, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, -200, 149),
	// new Point3D( 50, -150, 149),
	// new Point3D(-150, -150, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 0, -200, 149),
	// new Point3D( 50, -200, 149),
	// new Point3D( 50, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 0, -200, 149),
	// new Point3D( 50, 0, 149),
	// new Point3D( 0, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
	// new Point3D(-200, -200, 149),
	// new Point3D(-200, -100, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-250, -200, 149),
	// new Point3D(-250, -100, 149),
	// new Point3D(-200, -100, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
	// new Point3D( 150, -200, 149),
	// new Point3D( 350, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 100, -200, 149),
	// new Point3D( 300, 0, 149),
	// new Point3D( 350, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
	// new Point3D( 325, -200, 149),
	// new Point3D( 325, -125, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 275, -200, 149),
	// new Point3D( 275, -125, 149),
	// new Point3D( 325, -125, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
	// new Point3D( 325, -125, 149),
	// new Point3D( 275, -75, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 275, -125, 149),
	// new Point3D( 275, -75, 149),
	// new Point3D( 250, -100, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
	// new Point3D( 150, -100, 149),
	// new Point3D( 150, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 100, -100, 149),
	// new Point3D( 100, 0, 149),
	// new Point3D( 150, 0, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
	// new Point3D( 100, -100, 149),
	// new Point3D( 150, -100, 149), new Color(255,255,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 150, -150, 149),
	// new Point3D( 150, -100, 149),
	// new Point3D( 175, -125, 149), new Color(255,255,255)));
	//
	// ImageWriter imageWriter = new ImageWriter("AVI", 500, 500, 500, 500);
	// Render render = new Render( scene,imageWriter);
	//
	// render.renderImage();
	// //render.printGrid(50);
	// render.writeToImage();
	// }
	//
	// @Test
	// public void basicRendering(){
	// Scene scene = new Scene("Test scene");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0, 0, 0));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	// geometries.addGeometry(new Sphere(new Point3D(0, 0, 150), 66, new
	// Color(90,70,130)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
	// new Point3D( 0, 150, 149),
	// new Point3D( 150, 150, 149), new Color(255,0,0)));
	//
	// geometries.addGeometry(new Triangle(new Point3D( 150, 0, 149),
	// new Point3D( 0, -150, 149),
	// new Point3D( 150,-150, 149), new Color(0,255,0)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
	// new Point3D( 0, 150, 149),
	// new Point3D(-150, 150, 149), new Color(0,0,255)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, 0, 149),
	// new Point3D( 0, -150, 149),
	// new Point3D(-150, -150, 149), new Color(20,20,20)));
	//
	// ImageWriter imageWriter = new ImageWriter("test0", 500, 500, 500, 500);
	// Render render = new Render(scene, imageWriter);
	//
	// render.renderImage();
	// render.printGrid(50);
	// render.writeToImage();
	// }
	// @Test
	// public void house(){
	// Scene scene = new Scene("Test scene");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(255, 255, 255));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	//
	// geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
	// new Point3D( 0, 375, 149),
	// new Point3D(-150, 375, 149), new Color(140,17,17), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
	// new Point3D( 0, 525, 149),
	// new Point3D(0, 225, 149), new Color(140,17,17), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(-150, 225, 149),
	// new Point3D( 0, 225, 149),
	// new Point3D(-75, 150, 149), new Color(255,0,0), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(-10, 187.5, 149),
	// new Point3D( -10, 215, 149),
	// new Point3D(-37.5, 187.5, 149), new Color(255,0,0), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(0, 375, 149),
	// new Point3D( 75, 375, 149),
	// new Point3D(37.5, 337.5, 149), new Color(0,255,0), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(37.5, 375, 149),
	// new Point3D( 112.5, 375, 149),
	// new Point3D(75, 337.5, 149), new Color(0,255,0), new Material(2,3,4)));
	//
	// geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
	// new Point3D( 375, -150, 149),
	// new Point3D(375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
	// new Point3D( 0, -375, 149),
	// new Point3D(375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
	// new Point3D( -375, -150, 149),
	// new Point3D(-375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
	// geometries.addGeometry(new Triangle(new Point3D(0, -150, 149),
	// new Point3D( 0, -375, 149),
	// new Point3D(-375, -375, 149), new Color(75,124,212), new Material(2,3,4)));
	//
	// geometries.addGeometry(new Sphere(new Point3D(-20, 184, 150), 5, new
	// Color(165,165,165), new Material(2,3,4)));
	// geometries.addGeometry(new Sphere(new Point3D(-20, 177, 150), 5, new
	// Color(165,165,165), new Material(2,3,4)));
	// geometries.addGeometry(new Sphere(new Point3D(-17, 170, 150), 5, new
	// Color(165,165,165), new Material(2,3,4)));
	//
	// geometries.addGeometry(new Sphere(new Point3D(-380, -380, 140), 50, new
	// Color(230,230,0), new Material(2,3,4)));
	//
	//
	//
	// ImageWriter imageWriter = new ImageWriter("house", 500, 500, 500, 500);
	// Render render = new Render(scene, imageWriter);
	//
	// render.renderImage();
	// render.printGrid(50);
	// render.writeToImage();

	//
	// try {
	// Triangle t1 = new Triangle(new Point3D(100, 0, -49), new Point3D(0, 100,
	// -49), new Point3D(100, 100, -49),
	// new Color(150, 0, 0));
	// Triangle t2 = new Triangle(new Point3D(-100, 0, -49), new Point3D(0, 100,
	// -49),
	// new Point3D(-100, 100, -49), new Color(0, 150, 0));
	// Triangle t3 = new Triangle(new Point3D(100, 0, -49), new Point3D(0, -100,
	// -49),
	// new Point3D(100, -100, -49), new Color(0,0,150));
	// Triangle t4 = new Triangle(new Point3D(-100, 0, -49), new Point3D(0, -100,
	// -49),
	// new Point3D(-100, -100, -49), new Color(255,255,255));
	// Sphere s = new Sphere( new Point3D(0, 0, -50),40, new Color(0,250,250));
	// Scene testScene = new Scene("testScene");
	// testScene.set_background(new Color(75, 127, 190));
	// testScene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0,
	// -1),Point3D.ZERO));
	// testScene.set_distance(50);
	// Geometries geometries = new Geometries();
	// testScene.set_geometries(geometries);
	// geometries.addGeometry(t1);
	// geometries.addGeometry(t2);
	// geometries.addGeometry(t3);
	// geometries.addGeometry(t4);
	// geometries.addGeometry(s);
	// ImageWriter testImageWriter = new ImageWriter("4TrianglesAndSphere", 500,
	// 500, 500, 500);
	// Render testRender = new Render(testScene, testImageWriter);
	// testRender.renderImage();
	// testRender.printGrid(50);
	// testRender.writeToImage();
	// } catch (Exception e) {
	// fail(e.getMessage());
	// }

	// }

	// @Test
	// public void pointLightTest() {
	// Scene scene = new Scene("Test light");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// scene.set_lights(lights);
	// Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6,
	// 151),new Material(0.9,0.8,1000));
	// geometries.addGeometry(sphere);
	// lights.add(new PointLight(new Point3D(5,5,0), 0,0, new Color(255,255,255)));
	// //lights.add(new SpotLight(new Vector(-1,37,33) ,new Point3D(0,0,0), 0,0, new
	// Color(255,255,255)));
	// ImageWriter imageWriter = new ImageWriter("Point light test1", 500, 500, 500,
	// 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// //testRender.printGrid(50);
	// testRender.writeToImage();
	// //15, 7, 242
	// //255, 222, 10
	//
	//// Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6,
	// 151),new Material(0.9,0.8, 5));
	//// geometries.addGeometry(sphere);
	//// //lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new
	// Color(255,255,255)));
	// }
	//
	// @Test
	// public void spotLightTest() {
	// Scene scene = new Scene("Test light");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// scene.set_lights(lights);
	// Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6,
	// 151),new Material(0.9,0.8,1000));
	// geometries.addGeometry(sphere);
	// //lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new
	// Color(255,255,255)));
	// lights.add(new SpotLight(new Vector(-1,37,33) ,new Point3D(0,0,0), 0,0, new
	// Color(255,255,255)));
	// ImageWriter imageWriter = new ImageWriter("spot light test", 500, 500, 500,
	// 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// //testRender.printGrid(50);
	// testRender.writeToImage();
	// //15, 7, 242
	// //255, 222, 10
	//
	//// Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6,
	// 151),new Material(0.9,0.8, 5));
	//// geometries.addGeometry(sphere);
	//// //lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new
	// Color(255,255,255)));
	// }
	//
	// @Test
	// public void spotLightTest2() {
	// Scene scene = new Scene("Test light");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// scene.set_lights(lights);
	// Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6,
	// 151),new Material(0.9,0.8,100));
	// geometries.addGeometry(sphere);
	// //lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new
	// Color(255,255,255)));
	// lights.add(new SpotLight(new Vector(-50,0,80) ,new Point3D(50,0,0), 0,0, new
	// Color(255,255,255)));
	// ImageWriter imageWriter = new ImageWriter("spot light test222", 500, 500,
	// 500, 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// //testRender.printGrid(50);
	// testRender.writeToImage();
	// //15, 7, 242
	// //255, 222, 10
	//
	//// Sphere sphere = new Sphere( new Point3D(0, 0, 50),40, new Color(241, 6,
	// 151),new Material(0.9,0.8, 5));
	//// geometries.addGeometry(sphere);
	//// //lights.add(new PointLight(new Point3D(5,5,-20), 0,0, new
	// Color(255,255,255)));
	// }
	//
	// @Test
	// void test2() {
	//
	// Sphere sphere = new Sphere(new Point3D(0,0,-250),100, new Color(50,0,0),new
	// Material(500, 0.5, 100));
	// Camera camera = new Camera(new Vector(0,-1,0), new
	// Vector(0,0,-1),Point3D.ZERO);
	// Scene scene = new Scene("test2");
	// SpotLight spot = new SpotLight(new Vector(-70,0,-250).normalize(),new
	// Point3D(70,0,0), 2,0.01, new Color(100,100,100));
	// Geometries geometries = new Geometries();
	// scene.set_geometries(geometries);
	// geometries.addGeometry(sphere);
	// scene.set_ambientlight(new AmbientLight(new Color(130,130,130),0.1));
	// List<LightSource> lights = new ArrayList<LightSource>();
	// scene.set_lights(lights);
	// lights.add(spot);
	// scene.set_background(new Color(0,0,0));
	// scene.set_distance(149);
	// scene.set_camera(camera);
	//
	// ImageWriter imageWriter = new ImageWriter("test222",250,250,250,250);
	// Render render = new Render(scene, imageWriter);
	// render.renderImage();
	// render.writeToImage();
	// }
	//
	// @Test
	// public void shadowTest() {
	// Scene scene = new Scene("Test shadow");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// Geometries geometries = new Geometries();
	// Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6,
	// 151),new Material(0.9,0.8,300, 0, 0));
	// Triangle triangle1 = new Triangle(new Point3D(-250,-250,120),new
	// Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new
	// Material(0.9,0.8, 100, 0, 0));
	// Triangle triangle2 = new Triangle(new Point3D(250,250,120),new
	// Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new
	// Material(0.9,0.8, 100, 0, 0));
	// geometries.addGeometry(sphere);
	// geometries.addGeometry(triangle1);
	// geometries.addGeometry(triangle2);
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new SpotLight(new Vector(-25,0,80) ,new Point3D(25,0,0), 0,0, new
	// Color(255,255,255)));
	// scene.set_lights(lights);
	// ImageWriter imageWriter = new ImageWriter("shadow test", 500, 500, 500, 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// testRender.writeToImage();
	//
	// }
	//
	// @Test
	// public void shadowTes1t() {
	// Scene scene = new Scene("Test shadow1");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// Geometries geometries = new Geometries();
	// Sphere sphere = new Sphere( new Point3D(0, 0, 80),60, new Color(241, 6,
	// 151),new Material(0.5,0.5,300, 0, 0));
	// Sphere sphere1 = new Sphere( new Point3D( 0,10, 15),5, new Color(5, 55,
	// 255),new Material(0.35,10,500, 0, 0));
	// Triangle triangle1 = new Triangle(new Point3D(-250,-250,120),new
	// Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new
	// Material(0.9, 0.8, 100, 0, 0));
	// Triangle triangle2 = new Triangle(new Point3D(250,250,120),new
	// Point3D(-250,250,120),new Point3D(250,-250,120),new Color(0,0,0),new
	// Material(0.9, 0.8, 100, 0, 0));
	// //Triangle triangle3 = new Triangle(new Point3D(5,7,15),new
	// Point3D(0,0,15),new Point3D(5,-7,15),new Color(252, 252, 75),new
	// Material(0.9, 0.8, 100));
	// geometries.addGeometry(sphere);
	// geometries.addGeometry(sphere1);
	// geometries.addGeometry(triangle1);
	// geometries.addGeometry(triangle2);
	// //geometries.addGeometry(triangle3);
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new SpotLight(new Vector(-25,-25,80) ,new Point3D(25,25,0), 0,0,
	// new Color(255,255,255)));
	// lights.add(new SpotLight(new Vector(0,0,1) ,new Point3D(0,5,-10), 0,0, new
	// Color(255,255,255)));
	// scene.set_lights(lights);
	// ImageWriter imageWriter = new ImageWriter("shadow test1", 500, 500, 500,
	// 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// testRender.writeToImage();
	//
	// }
	//
	// @Test
	// public void squareTest() {
	// Scene scene = new Scene("Test square");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// Geometries geometries = new Geometries();
	// Rectangle rectangle = new Rectangle(new Point3D(-250,-250,120),new
	// Point3D(-250,250,120),new Point3D(250,-250,120),new Point3D(250,250,120),new
	// Color(0,0,0),new Material(0.9, 0.8, 100, 0, 0));
	// geometries.addGeometry(rectangle);
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new SpotLight(new Vector(-25,-25,80) ,new Point3D(25,25,0), 0,0,
	// new Color(255,255,255)));
	// lights.add(new SpotLight(new Vector(0,0,1) ,new Point3D(0,5,-10), 0,0, new
	// Color(255,255,255)));
	// scene.set_lights(lights);
	// ImageWriter imageWriter = new ImageWriter("square test", 500, 500, 500, 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// testRender.writeToImage();
	//
	// }
	//
	// @Test
	// public void square1Test() {
	// Scene scene = new Scene("Test square1");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0, 153, 255));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// Geometries geometries = new Geometries();
	// Triangle triangle1 = new Triangle(new Point3D(-20,-25,60),new
	// Point3D(30,-25,60),new Point3D(12,-60,65),new Color(255, 0, 0),new
	// Material(0.15,0.15, 100, 0, 0));
	// Triangle triangle2 = new Triangle(new Point3D(30,-25,60),new
	// Point3D(50,-50,70),new Point3D(12,-60,65),new Color(255, 0, 0),new
	// Material(0.15,0.15, 100, 0, 0));
	// Triangle triangle3 = new Triangle(new Point3D(50,-50,70),new
	// Point3D(0,-50,70),new Point3D(12,-60,65),new Color(255, 0, 0),new
	// Material(0.15,0.15, 100, 0, 0));
	// Triangle triangle4 = new Triangle(new Point3D(0,-50,70),new
	// Point3D(-20,-25,60),new Point3D(12,-60,65),new Color(255, 0, 0),new
	// Material(0.15,0.15, 100, 0, 0));
	// geometries.addGeometry(triangle1);
	// geometries.addGeometry(triangle2);
	// geometries.addGeometry(triangle3);
	// geometries.addGeometry(triangle4);
	// Rectangle rectangle = new Rectangle(new Point3D(-800,-250,300),new
	// Point3D(-250,250,0),new Point3D(800,-250,300),new Point3D(250,250,0),new
	// Color(77, 26, 0),new Material(0.2, 0.2, 100, 0, 0));
	// Rectangle rectangle1 = new Rectangle(new Point3D(-20,-25,60),new
	// Point3D(-20,25,60),new Point3D(30,-25,60),new Point3D(30,25,60),new Color(0,
	// 153, 51),new Material(0.4, 0.4, 100, 0, 0));
	// Rectangle rectangle2 = new Rectangle(new Point3D(0,-50,70),new
	// Point3D(0,0,70),new Point3D(50,-50,70),new Point3D(50,0,70),new Color(255, 0,
	// 0),new Material(0.4, 0.4, 100, 0, 0));
	// Rectangle rectangle3= new Rectangle(new Point3D(30,-25,60),new
	// Point3D(30,25,60),new Point3D(50,-50,70),new Point3D(50,0,70),new Color(0,
	// 102, 34),new Material(0.4,0.4, 100, 0, 0));
	// Rectangle rectangle4= new Rectangle(new Point3D(-20,-25,60),new
	// Point3D(0,-50,70),new Point3D(-20,25,600),new Point3D(0,0,70),new Color(204,
	// 204, 0),new Material(0.4, 0.4, 100, 0, 0));
	// geometries.addGeometry(rectangle);
	// geometries.addGeometry(rectangle1);
	// geometries.addGeometry(rectangle2);
	// geometries.addGeometry(rectangle3);
	// geometries.addGeometry(rectangle4);
	// geometries.addGeometry(new Sphere(new Point3D(440, -440, 140), 50, new
	// Color(230,230,0), new Material(0,0,4, 0, 0)));
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new PointLight(new Point3D(50, -50, -10), 0,0, new Color(255, 255,
	// 100)));
	// scene.set_lights(lights);
	// ImageWriter imageWriter = new ImageWriter("square test1234", 500, 500, 500,
	// 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// testRender.writeToImage();
	//
	// }
	//
	// @Test
	// public void planeTest() {
	// Scene scene = new Scene("Test plane");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(100);
	// scene.set_background(new Color(0,0,0));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// Geometries geometries = new Geometries();
	// Plane plane = new Plane(new Point3D(0,200,0), new Vector(0, 1, 0), new
	// Color(200,30,30),new Material(500, 10, 10000, 0, 0));
	// //Square square = new Square(new Point3D(-250,-250,120),new
	// Point3D(250,250,120),new Point3D(-250,250,120),new Point3D(250,-250,120),new
	// Color(0,0,0),new Material(0.9, 0.8, 100));
	// geometries.addGeometry(plane);
	// scene.set_geometries(geometries);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new SpotLight(new Vector(0,201,0) ,new Point3D(0,-50,300), 1,0.01,
	// new Color(255,255,255)));
	// //lights.add(new SpotLight(new Vector(0,0,1) ,new Point3D(0,5,-10), 0,0, new
	// Color(255,255,255)));
	// scene.set_lights(lights);
	// ImageWriter imageWriter = new ImageWriter("plane test", 500, 500, 500, 500);
	// Render testRender = new Render(scene, imageWriter);
	// testRender.renderImage();
	// testRender.writeToImage();
	//
	// }

	@Test
	public void reflectTest() {
		Scene scene = new Scene("Test reflect");
		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.setDistance(100);
		scene.setBackground(new Color(0, 0, 0));
		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
		Geometries geometries = new Geometries();
		Sphere sphere = new Sphere(new Point3D(0, 0, 80), 60, new Color(0, 19, 86),
				new Material(400, 500, 18, 0.7, 0.12));
		Sphere sphere1 = new Sphere(new Point3D(0, 0, 80), 40, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Rectangle rectangle = new Rectangle(new Point3D(300, 300, 150), new Point3D(300, -300, 150),
				new Point3D(-300, 300, 150), new Color(0, 0, 0), new Material(2000, 500, 10, 1, 1));
		geometries.addGeometry(sphere);
		geometries.addGeometry(sphere1);
		geometries.addGeometry(rectangle);
		scene.setGeometries(geometries);
		List<LightSource> lights = new ArrayList<LightSource>();
		lights.add(new SpotLight(new Vector(-35, -35, 100), new Point3D(15, 15, -10), 10, 0, new Color(241, 60, 151)));																									// 151
		scene.setLights(lights);
		ImageWriter imageWriter = new ImageWriter("reflect test", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();
	}

	@Test
	public void reflectTest1() {
		Scene scene = new Scene("Test reflect1");
		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new Point3D(0, 0, 0)));
		scene.setDistance(100);
		scene.setBackground(new Color(0, 0, 0));
		scene.setAmbientLight(new AmbientLight(new Color(50, 50, 50), 0.5));
		Geometries geometries = new Geometries();
		Sphere sphere = new Sphere(new Point3D(80, 80, 80), 60, new Color(0, 19, 86), new Material(400, 500, 18, 0, 1));
		Sphere sphere1 = new Sphere(new Point3D(80, 80, 80), 40, new Color(247, 59, 165),
				new Material(300, 700, 18, 0.8, 0.2));
		Triangle triangle = new Triangle(new Point3D(500, 500, 200), new Point3D(500, -500, 200),
				new Point3D(-500, 500, 200), new Color(0, 0, 0), new Material(1000, 500, 10, 1, 1));
		Triangle triangle1 = new Triangle(new Point3D(-60, -60, 30), new Point3D(500, -500, 200),
				new Point3D(-500, 500, 200), new Color(0, 0, 0), new Material(1000, 500, 10, 1, 1));
		geometries.addGeometry(sphere);
		geometries.addGeometry(sphere1);
		geometries.addGeometry(triangle);
		geometries.addGeometry(triangle1);
		scene.setGeometries(geometries);
		List<LightSource> lights = new ArrayList<LightSource>();
		lights.add(new SpotLight(new Vector(-35, -35, 100), new Point3D(15, 15, -10), 10, 0, new Color(241, 60, 151)));// 241,
																														// 60,
																														// 151
		scene.setLights(lights);
		ImageWriter imageWriter = new ImageWriter("reflect test123", 500, 500, 500, 500);
		Render testRender = new Render(scene, imageWriter);
		testRender.renderImage();
		testRender.writeToImage();

	}

	@Test
	void testReflect() {
		Scene scene = new Scene("Test");
		scene.setAmbientLight(new AmbientLight(new Color(0, 0, 0), 2));
		scene.setBackground(new Color(0, 0, 0));
		scene.setCamera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, -1), new Point3D(0, 0, 0)));
		scene.setDistance(200);
		Geometries geometries = new Geometries();
		Plane p = new Plane(new Point3D(0, 1, -50), new Vector(0, -1, 0), new Color(40, 40, 62),
				new Material(100, 10, 100, 0.9, 0));
		geometries.addGeometry(p);

		List<LightSource> lights = new ArrayList<LightSource>();
		SpotLight spot = new SpotLight(new Vector(0, -1, 0), new Point3D(0, 0, -200), 0.2, 0, new Color(100, 100, 100));
		lights.add(spot);
		scene.setGeometries(geometries);
		Sphere sphere = new Sphere(new Point3D(0, -100, -200), 45, new Color(23, 23, 46),
				new Material(30, 0.2, 100, 0, 0));
		geometries.addGeometry(sphere);
		PointLight pointL = new PointLight(new Point3D(-70, -150, -180), 0.1, 0.01, new Color(150, 0, 0));
		lights.add(pointL);
		scene.setLights(lights);
		ImageWriter imageWriter = new ImageWriter("Test_reflected", 500, 500, 500, 500);
		Render render = new Render(scene, imageWriter);
		render.renderImage();
		render.writeToImage();

	}

	// @Test
	// public void recursiveTest3(){
	// Scene scene = new Scene("recTest");
	// scene.set_camera(new Camera(new Vector(0, -1, 0), new Vector(0, 0, 1), new
	// Point3D(0, 0, 0)));
	// scene.set_distance(300);
	//
	// Sphere sphere = new Sphere( new Point3D(0, 0, 1000),300,new Color(0, 0,
	// 100),new Material(0, 0, 20, 0, 0.5));
	// //sphere.setShininess(20);
	// //sphere.setEmmission(new Color(0, 0, 100));
	// //sphere.setKt(0.5);
	// //scene.addGeometry(sphere);
	//
	// Sphere sphere2 = new Sphere( new Point3D(0, 0, 1000),150,new Color(100, 20,
	// 20),new Material(0, 0, 20, 0, 0));
	//// sphere2.setShininess(20);
	//// sphere2.setEmmission(new Color(100, 20, 20));
	//// sphere2.setKt(0);
	// //scene.addGeometry(sphere2);
	//
	// Triangle triangle = new Triangle(new Point3D( 2000, -1000, 1500),
	// new Point3D( -1000, 2000, 1500),
	// new Point3D( 700, 700, 375), new Color(20, 20, 20),new Material(0, 0, 0, 1,
	// 0) );
	//
	// Triangle triangle2 = new Triangle(new Point3D( 2000, -1000, 1500),
	// new Point3D( -1000, 2000, 1500),
	// new Point3D( -1000, -1000, 1500), new Color(20, 20, 20),new Material(0, 0, 0,
	// 0.5, 0));
	//
	//// triangle.setEmmission(new Color(20, 20, 20));
	//// triangle2.setEmmission(new Color(20, 20, 20));
	//// triangle.setKr(1);
	//// triangle2.setKr(0.5);
	//// scene.addGeometry(triangle);
	//// scene.addGeometry(triangle2);
	// Geometries geometries = new Geometries();
	// geometries.addGeometry(sphere);
	// geometries.addGeometry(sphere2);
	// geometries.addGeometry(triangle);
	// geometries.addGeometry(triangle2);
	// List<LightSource> lights = new ArrayList<LightSource>();
	// lights.add(new SpotLight(new Vector(-2, -2, -3), new Point3D(200, 200, -150),
	// 0.00001, 0.000005,new Color(255, 100, 100)));
	// scene.set_geometries(geometries);
	// scene.set_lights(lights);
	// scene.set_background(new Color(0,0,0));
	// scene.set_ambientlight(new AmbientLight(new Color(50, 50, 50), 0.5));
	// ImageWriter imageWriter = new ImageWriter("Recursive Test 3", 500, 500, 500,
	// 500);
	//
	// Render render = new Render( scene,imageWriter);
	//
	// render.renderImage();
	// render.writeToImage();
	//
	// }
	
	@Test
	void BVHtest() {
		Geometries g1 = new Geometries();
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
				new Point3D(-300, 300, 150), new Color(0, 0, 0),
				new Material(2000, 500, 10, 0, 0));
		g1.addGeometry(rectangle);
		g1.addGeometry(sphere1);
		g1.addGeometry(sphere11);
		g1.addGeometry(sphere2);
		g1.addGeometry(sphere22);
		g1.addGeometry(sphere3);
		g1.addGeometry(sphere33);
		g1.addGeometry(sphere4);
		g1.addGeometry(sphere44);
		g1.addGeometry(sphere5);
		g1.addGeometry(sphere55);
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