using System;
using System.Data;
using System.Data.SqlClient;

namespace Microsoft.AdoNet.DataSetDemo
{
    class DataSetExample
    {
        static void Main()
        {
            string connectionString = GetConnectionString();
            ConnectToData(connectionString);
        }

        private static void ConnectToData(string connectionString)
        {
            //Create a SqlConnection to the Training database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlDataAdapter for the Suppliers table.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // A table mapping names the DataTable.
                adapter.TableMappings.Add("Table", "Employee");

                // Open the connection.
                connection.Open();
                Console.WriteLine("The SqlConnection is open.");

                // Create a SqlCommand to retrieve Employee data.
                SqlCommand command = new SqlCommand("Select EmpID, EmpName from Employee;", connection);
                command.CommandType = CommandType.Text;

                // Set the SqlDataAdapter's SelectCommand.
                adapter.SelectCommand = command;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("Employee");
                adapter.Fill(dataSet);

                // Create a second Adapter and Command to get the Project_Assignment table, a child table of Employee.
                SqlDataAdapter Project_AssignmentAdapter = new SqlDataAdapter();
                Project_AssignmentAdapter.TableMappings.Add("Table", "Project_Assignment");

                SqlCommand Project_AssignmentCommand = new SqlCommand("Select ProjID, EmpID from Project_Assignment;", connection);
                Project_AssignmentAdapter.SelectCommand = Project_AssignmentCommand;

                // Fill the DataSet.
                Project_AssignmentAdapter.Fill(dataSet);

		// Read Data Tables from Data Set
		ReadFromDataTablesInDataSet(dataSet);

                // Create a DataRelation to link the two tables
                // based on the EmpID.

		/*var keys = new DataColumn[1];
		keys[0] = dataSet.Tables["Employee"].Columns["EmpID"];
		dataSet.Tables["Employee"].PrimaryKey = keys;

                DataColumn parentColumn = dataSet.Tables["Employee"].Columns["EmpID"];
                DataColumn childColumn = dataSet.Tables["Project_Assignment"].Columns["EmpID"];
                DataRelation relation = new System.Data.DataRelation("EmployeeProject_Assignment", parentColumn, childColumn);
                dataSet.Relations.Add(relation);
                Console.WriteLine("\n The {0} DataRelation has been created.", relation.RelationName);


		*/AdapterUpdate(connectionString);
	
                // Close the connection.
                connection.Close();
                Console.WriteLine("\n\n The SqlConnection is closed.");

            }
        }

	static private void ReadFromDataTablesInDataSet(DataSet ds)
	{
	  // Read single row
	  Console.WriteLine("\n\n Reading a specific row");
	  DataRow drTemp = ds.Tables[0].Rows[0];
	  Console.WriteLine(drTemp["EmpID"] + "  " + drTemp["EmpName"]);

	  // Read all rows
	  Console.WriteLine("\n\n Reading all rows of Employee");
	  DataTable dt = ds.Tables[0];
	  foreach (DataRow dr in dt.Rows)
	  {
	    Console.WriteLine(dr["EmpID"] + "  " + dr["EmpName"]);
	  }

	  Console.WriteLine("\n\n Reading all rows of Project_Assignment");
	  dt = ds.Tables[1];
	  foreach (DataRow dr in dt.Rows)
	  {
	    Console.WriteLine(dr["EmpID"] + "  " + dr["ProjID"]);
	  }

	}

private static void AdapterUpdate(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlDataAdapter dataAdpater = new SqlDataAdapter("Select EmpID, EmpName, PassPortNo from Employee", connection);

        dataAdpater.UpdateCommand = new SqlCommand("Update Employee Set PassportNo = @PassportNo Where EmpID = @EmpID", connection);

        dataAdpater.UpdateCommand.Parameters.Add("@PassportNo", SqlDbType.NVarChar, 15, "PassportNo");

        SqlParameter parameter = dataAdpater.UpdateCommand.Parameters.Add("@EmpID", SqlDbType.Int, 10, "EmpID");
        parameter.SourceColumn = "EmpID";
        parameter.SourceVersion = DataRowVersion.Original;

        DataTable EmployeeTable = new DataTable();
        dataAdpater.Fill(EmployeeTable);

	// creating Primary Key for the Table EmployeeTable
	var keys = new DataColumn[1];
	keys[0] = EmployeeTable.Columns["EmpID"];
	EmployeeTable.PrimaryKey = keys;

        //DataRow EmployeeRow = EmployeeTable.Rows[0]; // this for the first row only
	
	// make this search dynamic
	object searchEmpID = new object();
	searchEmpID = 106;
	DataRow EmployeeRow = EmployeeTable.Rows.Find(searchEmpID);
        EmployeeRow["PassportNo"] = "JT73663KKS87";

        dataAdpater.Update(EmployeeTable);

        Console.WriteLine("\n\nRows after update.");
        foreach (DataRow row in EmployeeTable.Rows)
        {
            {
                Console.WriteLine("{0}: {1}, {2}", row[0], row[1], row["PassportNo"]);
            }
        }
    }
}
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, you can retrieve it from a configuration file.
            //return "Data Source=(local);Initial Catalog=Training; Integrated Security=SSPI";
	    return "Data Source=LPCD-JTNP4B3;Initial Catalog=Training;User ID=sa;Password=Espire123";

        }
    }
}