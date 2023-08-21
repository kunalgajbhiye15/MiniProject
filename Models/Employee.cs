using System.Data;
using MySql.Data.MySqlClient;

namespace ModelBinding.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        static string Db = @"server=localhost;userid=root;password=Kunal@1996;database=Dotnet";
        public static List<Employee> GetAllEmployee()
        {
            List<Employee> lstEmp = new List<Employee>();

            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees ";

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Employee obj = new Employee();

                    obj.EmpNo = dr.GetInt32("EmpNo");
                    obj.Name = dr.GetString("Name");
                    obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");

                    lstEmp.Add(obj);

                }

                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return lstEmp;
        }

        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee employee = new Employee();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    employee.EmpNo = EmpNo;
                    employee.Name = dr.GetString("Name");
                    employee.Basic = dr.GetDecimal("Basic");
                    employee.DeptNo = dr.GetInt32("DeptNo");

                }
                else
                {
                    //if not found
                    employee = null;
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return employee;
        }

        public static void InsertEmployee(Employee obj)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

       public static void UpdateEmployee(Employee obj)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "Insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmd.CommandText = "UPDATE Employees SET Name = @Name, Basic = @Basic, DeptNo = @DeptNo WHERE EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
                Console.WriteLine("Update successful");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

       public static void Delete(int empNo)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", empNo);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Delete successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }



    }
}
