package unittests;

import static org.junit.jupiter.api.Assertions.*;

import java.awt.Color;

import org.junit.jupiter.api.Test;

import renderer.*;

class ImageWriterTests {

	ImageWriter imageWriter = new ImageWriter("test", 500,500,500,500);
	Color white = new Color(255, 255, 255);
	
	@Test
	void testCreatePicture() {
		try {
			for (int i = 0; i < imageWriter.getNy()-1; i++) {
				for (int j = 0; j < imageWriter.getNx()-1; j++) {
					if((i+1) % 50 == 0 || (j+1) % 50 == 0) {
						imageWriter.writePixel(j, i,white);
					}
				}
			}
			imageWriter.writeToimage();
		} catch (Exception e) {
			fail("fail");
		}
	}

}
