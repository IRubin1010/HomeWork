/**
 * 
 */
package exercise0;

/**
 * @author itzik yeret
 *
 */
public class HourlyEmployee extends Employee {

	protected float hours;
	protected float wage;

	/**
	 * @param firstName
	 * @param lastName
	 * @param id
	 * @param hours
	 * @param wage
	 */
	public HourlyEmployee(String firstName, String lastName, Integer id, float hours, float wage) {
		super(firstName, lastName, id);
		if (hours < 0)
			throw new IllegalArgumentException("negetive hours");
		if (wage < 0)
			throw new IllegalArgumentException("negetive wage");
		this.hours = hours;
		this.wage = wage;
	}

	/**
	 * empty constractor
	 */
	public HourlyEmployee() {
		super();
		this.hours = 0;
		this.wage = 0;
	}

	/**
	 * @return the hours
	 */
	public float getHours() {
		return hours;
	}

	/**
	 * @param hours
	 *            the hours to set
	 */
	public void setHours(float hours) {
		if (hours < 0)
			throw new IllegalArgumentException("negetive hours");
		this.hours = hours;
	}

	/**
	 * @return the wage
	 */
	public float getWage() {
		return wage;
	}

	/**
	 * @param wage
	 *            the wage to set
	 */
	public void setWage(float wage) {
		if (wage < 0)
			throw new IllegalArgumentException("negetive wage");
		this.wage = wage;
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return super.toString() + "\n" + "hours: " + this.hours + "\n" + "wage: " + this.wage;
	}

	/**
	 * override equals
	 */
	@Override
	public boolean equals(Object obj) {
		if (obj == null)
			return false;
		if (obj == this)
			return true;
		if (!super.equals(obj))
			return false;
		if (!(obj instanceof HourlyEmployee))
			return false;
		HourlyEmployee hourlyEmployee = (HourlyEmployee) obj;
		return this.hours == hourlyEmployee.hours && this.wage == hourlyEmployee.wage;
	}

	/**
	 * override earnings
	 */
	@Override
	public float earnings() {
		return this.hours * this.wage;
	}

}
