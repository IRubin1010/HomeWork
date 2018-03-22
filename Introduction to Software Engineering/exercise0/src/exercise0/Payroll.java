/**
 * 
 */
package exercise0;

/**
 * @author itzik yeret 206244485
 * @mail yeret82088@gmail.com
 *
 */
public class Payroll {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			Employee[] employeeArray = new Employee[3];
			employeeArray[0] = new HourlyEmployee("itzik", "yeret", 1234, 10, 30);
			employeeArray[1] = new CommissionEmployee("meir", "shimon", 9876, 1000, 5);
			employeeArray[2] = new BasePlusCommissionEmployee("yudit", "yeret", 4567, 2000, 3, 100);
			for (Employee employee : employeeArray) {
				double salary = (double) employee.earnings();
				if (employee instanceof BasePlusCommissionEmployee) {
					salary += salary * 0.1;
				}
				System.out.println(employee + "\n" + "week salary: " + salary + "\n");

			}

		} catch (IllegalArgumentException e) {
			System.out.println("ERROR!! " + e.getMessage());
		}

	}

}
