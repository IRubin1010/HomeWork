/**
 * 
 */
package exercise0;

/**
 * @author itzik yeret
 *
 */
public class BasePlusCommissionEmployee extends CommissionEmployee {
	protected float baseSalary;

	/**
	 * @param firstName
	 * @param lastName
	 * @param id
	 * @param grossSales
	 * @param commision
	 * @param baseSalary
	 */
	public BasePlusCommissionEmployee(String firstName, String lastName, Integer id, float grossSales, float commision,
			float baseSalary) {
		super(firstName, lastName, id, grossSales, commision);
		if (baseSalary < 0)
			throw new IllegalArgumentException("negetive baseSalary");
		this.baseSalary = baseSalary;
	}

	/**
	 * empty constractor
	 */
	public BasePlusCommissionEmployee() {
		super();
		this.baseSalary = 0;
	}

	/**
	 * @return the baseSalary
	 */
	public float getBaseSalary() {
		return baseSalary;
	}

	/**
	 * @param baseSalary
	 *            the baseSalary to set
	 */
	public void setBaseSalary(float baseSalary) {
		if (baseSalary < 0)
			throw new IllegalArgumentException("negetive baseSalary");
		this.baseSalary = baseSalary;
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
		if (!(obj instanceof BasePlusCommissionEmployee))
			return false;
		BasePlusCommissionEmployee basePlusCommissionEmployee = (BasePlusCommissionEmployee) obj;
		return this.baseSalary == basePlusCommissionEmployee.baseSalary;
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return super.toString() + "\n" + "base salary: " + this.baseSalary;
	}

	/**
	 * override earnings
	 */
	@Override
	public float earnings() {
		return super.earnings() + this.baseSalary;
	}

}
