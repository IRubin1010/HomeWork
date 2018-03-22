/**
 * 
 */
package exercise0;

/**
 * @author itzik yeret
 *
 */
public class CommissionEmployee extends Employee {

	protected float grossSales;
	protected float commision;

	/**
	 * @param firstName
	 * @param lastName
	 * @param id
	 * @param grossSales
	 * @param commision
	 */
	public CommissionEmployee(String firstName, String lastName, Integer id, float grossSales, float commision) {
		super(firstName, lastName, id);
		if (grossSales < 0)
			throw new IllegalArgumentException("negetive grossSales");
		if (commision < 0)
			throw new IllegalArgumentException("negetive commision");
		this.grossSales = grossSales;
		this.commision = commision;
	}

	/**
	 * empty constractor
	 */
	public CommissionEmployee() {
		super();
		this.grossSales = 0;
		this.commision = 0;
	}

	/**
	 * @return the grossSales
	 */
	public float getGrossSales() {
		return grossSales;
	}

	/**
	 * @param grossSales
	 *            the grossSales to set
	 */
	public void setGrossSales(float grossSales) {
		if (grossSales < 0)
			throw new IllegalArgumentException("negetive grossSales");
		this.grossSales = grossSales;
	}

	/**
	 * @return the commision
	 */
	public float getCommision() {
		return commision;
	}

	/**
	 * @param commision
	 *            the commision to set
	 */
	public void setCommision(float commision) {
		if (commision < 0)
			throw new IllegalArgumentException("negetive commision");
		this.commision = commision;
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
		if (!(obj instanceof CommissionEmployee))
			return false;
		CommissionEmployee commissionEmployee = (CommissionEmployee) obj;
		return this.grossSales == commissionEmployee.grossSales && this.commision == commissionEmployee.commision;
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return super.toString() + "\n" + "gross sales: " + this.grossSales + "\n" + "commission: " + this.commision;
	}

	/**
	 * override earnings
	 */
	@Override
	public float earnings() {
		return (commision / 100) * grossSales;
	}

}
