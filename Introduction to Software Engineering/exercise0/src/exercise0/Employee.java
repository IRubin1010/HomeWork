/**
 * 
 */
package exercise0;

/**
 * @author itzik yeret
 *
 */
public abstract class Employee {
	protected String firstName;
	protected String lastName;
	protected int id;

	/**
	 * @param firstNAme
	 * @param lastName
	 * @param id
	 */
	public Employee(String firstName, String lastName, int id) {
		if (id < 0)
			throw new IllegalArgumentException("negative id");
		this.firstName = firstName;
		this.lastName = lastName;
		this.id = id;
	}

	/**
	 * empty constractor
	 */
	public Employee() {
		this.firstName = "plony";
		this.lastName = "almony";
		this.id = 0;
	}

	/**
	 * @return the firstName
	 */
	public String getFirstName() {
		return firstName;
	}

	/**
	 * @param firstName
	 *            the firstName to set
	 */
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	/**
	 * @return the lastName
	 */
	public String getLastName() {
		return lastName;
	}

	/**
	 * @param lastName
	 *            the lastName to set
	 */
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	/**
	 * @return the id
	 */
	public int getId() {
		return id;
	}

	/**
	 * @param id
	 *            the id to set
	 */
	public void setId(int id) {
		if (id < 0)
			throw new IllegalArgumentException("negetiv id");
		this.id = id;
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
		if (!(obj instanceof Employee))
			return false;
		Employee employee = (Employee) obj;
		return this.firstName == employee.firstName && this.lastName == employee.lastName && this.id == employee.id;
	}

	/**
	 * override toString
	 */
	@Override
	public String toString() {
		return "first name: " + this.firstName + "\n" + "last name: " + this.lastName + "\n" + "id: " + this.id;
	}

	public abstract float earnings();

}
