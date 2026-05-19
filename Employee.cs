using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails
{
    class Employee
    {
        public int Id { get; set; }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aas;Integrated Security=True");

        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Age { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }

        private const string SelectQuery = "Select * from Emp_details";
        private const string InsertQuery = "Insert Into Emp_details(EmpId, EmpName, EmpAge, EmpContact, EmpGender) Values (@EmpId, @EmpName, @EmpAge, @EmpContact, @EmpGender)";
        private const string UpdateQuery = "Update Emp_details set EmpName=@EmpName, EmpAge=@EmpAge, EmpContact=@EmpContact, EmpGender=@EmpGender where EmpId=@EmpId";
        private const string DeleteQuery = "Delete from Emp_details where EmpId=@EmpId";

        public DataTable GetEmployees()
        {
            var datatable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(Con.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(SelectQuery, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                        {
                            adapter.Fill(datatable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading employee details: " + ex.Message);
            }
            return datatable;
        }

        public bool InsertEmployee(Employee employee)
        {
            int rows = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Con.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(InsertQuery, con))
                    {
                        com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                        com.Parameters.AddWithValue("@EmpName", employee.EmpName);
                        com.Parameters.AddWithValue("@EmpAge", employee.Age);
                        com.Parameters.AddWithValue("@EmpContact", employee.ContactNo);
                        com.Parameters.AddWithValue("@EmpGender", employee.Gender);
                        rows = com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error inserting employee: " + ex.Message);
            }
            return rows > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            int rows = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Con.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@EmpName", employee.EmpName);
                        com.Parameters.AddWithValue("@EmpAge", employee.Age);
                        com.Parameters.AddWithValue("@EmpContact", employee.ContactNo);
                        com.Parameters.AddWithValue("@EmpGender", employee.Gender);
                        com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                        rows = com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error updating employee: " + ex.Message);
            }
            return rows > 0;
        }

        public bool DeleteEmployee(Employee employee)
        {
            int rows = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Con.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                        rows = com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error deleting employee: " + ex.Message);
            }
            return rows > 0;
        }
    }
}