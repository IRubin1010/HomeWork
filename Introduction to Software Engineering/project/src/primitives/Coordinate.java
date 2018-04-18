package primitives;

/**
 * @author itzik yeret 206244485 yeret82088@gmail.com
 * @author meir shimon 305625295 nthr120@gmail.com
 */

public class Coordinate {

	private double _coord;
	
	public static final Coordinate zeroCoordinate = new Coordinate(0);
	
	/***************** Constructors **********************/ 
	
	public Coordinate(double coord) {
		_coord = (getExp(coord) < ACCURACY) ? 0.0 : coord;
	}

	public Coordinate(Coordinate other) {
		if(other == null) throw new IllegalArgumentException("param can't be null");
		_coord = other._coord;
	}
	
	/***************** Getter ****************************/
	
	public double getValue() {
		return _coord;
	}

	/***************** Administration  *******************/
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Coordinate))
			return false;
		Coordinate other = (Coordinate) obj;
		return (_subtract(other._coord) == 0.0);
	}

	@Override
	public String toString() {
		if (_coord % 1 == 0)
			return "" + (int) _coord;
		else {
			return "" + _coord;
		}
	}
	
	/***************** Operations ************************/ 
	
	public Coordinate subtract(Coordinate other) {
		return new Coordinate(_subtract(other._coord));
	}

	public Coordinate add(Coordinate other) {
		return new Coordinate(_add(other._coord));
	}

	public Coordinate scale(double num) {
		return new Coordinate(_scale(num));
	}

	public Coordinate multiply(Coordinate other) {
		return new Coordinate(_scale(other._coord));
	}
	
	public Coordinate divide(double num) {
		return new Coordinate(_divide(num));
	}

	public Coordinate coordinateDivide(Coordinate other) {
		return new Coordinate(_divide(other._coord));
	}
	
	/***************** helpers ************************/ 
	
	// It is binary, equivalent to ~1/1,000,000 in decimal (6 digits)
		private static final int ACCURACY = -20;
	
	// double store format: seee eeee eeee (1.)mmmm � mmmm
		// 1 bit sign, 11 bits exponent, 53 bits (52 stored) normalized mantissa
	private int getExp(double num) {
			return (int) ((Double.doubleToRawLongBits(num) >> 52) & 0x7FFL) - 1023;
	}
		
	private double _subtract(double other) {
		int otherExp = getExp(other);
		int thisExp = getExp(_coord);
		// if other is too small relatively to our coordinate return the original
		// coordinate

		if (otherExp - thisExp < ACCURACY)
			return _coord;
		// if our coordinate is too small relatively to other return negative of other
		if (thisExp - otherExp < ACCURACY)
			return -other;
		double result = _coord - other;
		int resultExp = getExp(result);
		// if the result is relatively small - tell that it is zero
		return resultExp - thisExp < ACCURACY ? 0.0 : result;
	}

	private double _add(double other) {
		int otherExp = getExp(_coord);
		int thisExp = getExp(_coord);
		// if other is too small relatively to our coordinate return the original
		// coordinate
		if (otherExp - thisExp < ACCURACY)
			return _coord;
		// if our coordinate is too small relatively to other return other
		if (thisExp - otherExp < ACCURACY)
			return other;
		double result = _coord + other;
		int resultExp = getExp(result);
		// if the result is relatively small - tell that it is zero
		return resultExp - thisExp < ACCURACY ? 0.0 : result;
	}

	private double _scale(double num) {
		int deltaExp = getExp(num - 1);
		return deltaExp < ACCURACY ? _coord : _coord * num;
	}
	
	private double _divide(double num) {
		if(num == 0) throw new IllegalArgumentException("error! can't divide with 0");
		int deltaExp = getExp(num - 1);
		return deltaExp < ACCURACY ? _coord : _coord / num;
	}
	
}
