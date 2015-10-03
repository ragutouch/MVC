using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<EmployeeC1> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

                List<EmployeeC1> employees = new List<EmployeeC1>();
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeC1 employee = new EmployeeC1();
                        employee.employeeId = Convert.ToInt32(rdr["employeeId"]);
                        employee.name = rdr["name"].ToString();
                        employee.city = rdr["city"].ToString();
                        employee.DateOfBirth = Convert.ToDateTime(rdr["dateOfBirth"]);

                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }

        public void AddEmployee(EmployeeC1 employee)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            List<EmployeeC1> employees = new List<EmployeeC1>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter paramName = new MySqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.name;
                cmd.Parameters.Add(paramName);

                MySqlParameter paramCity = new MySqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.city;
                cmd.Parameters.Add(paramCity);

                MySqlParameter paramDateOfBirth = new MySqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                MySqlParameter paramDepartmentID = new MySqlParameter();
                paramDepartmentID.ParameterName = "@departmentID";
                paramDepartmentID.Value = "1";
                cmd.Parameters.Add(paramDepartmentID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public void SaveEmployee(EmployeeC1 employee)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            List<EmployeeC1> employees = new List<EmployeeC1>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                MySqlParameter paramId = new MySqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = employee.employeeId;
                cmd.Parameters.Add(paramId);

                MySqlParameter paramName = new MySqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.name;
                cmd.Parameters.Add(paramName);

                MySqlParameter paramCity = new MySqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.city;
                cmd.Parameters.Add(paramCity);

                MySqlParameter paramDateOfBirth = new MySqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                //MySqlParameter paramDepartmentID = new MySqlParameter();
                //paramDepartmentID.ParameterName = "@departmentID";
                //paramDepartmentID.Value = "1";
                //cmd.Parameters.Add(paramDepartmentID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter paramId = new MySqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
