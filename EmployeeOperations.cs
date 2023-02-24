using Microsoft.Data.SqlClient;

namespace Mini_project.Models
{
    public class EmployeeOperations : EmployeeOperationsInterface
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mini_pro;Integrated Security=True");
        public int createNewEmployee(Employee emp)
        {
            int c = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "insert into Employee(eid, ename, email, epass, phone, designation)" +
                                    " values(@eid, @ename, @email, @epass, @phone, @designation)";

                cmd.CommandType = System.Data.CommandType.Text;

                SqlParameter p1 = new SqlParameter("@eid", System.Data.SqlDbType.Int);
                p1.Value = emp.eid;
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@ename", System.Data.SqlDbType.VarChar, 50);
                p2.Value = emp.ename;
                cmd.Parameters.Add(p2);

                SqlParameter p3 = new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100);
                p3.Value = emp.email;
                cmd.Parameters.Add(p3);

                SqlParameter p4 = new SqlParameter("@epass", System.Data.SqlDbType.VarChar,50);
                p4.Value = emp.epass;
                cmd.Parameters.Add(p4);

                SqlParameter p5 = new SqlParameter("@phone", System.Data.SqlDbType.Int);
                p5.Value = emp.phone;
                cmd.Parameters.Add(p5);

                SqlParameter p6 = new SqlParameter("@designation", System.Data.SqlDbType.VarChar, 100);
                p6.Value = emp.designation;
                cmd.Parameters.Add(p6);

                con.Open();

                c = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                c = -1;
                Console.WriteLine("Exeception Occured {0}", ex.Source);

            }
            finally
            {
                con.Close();
            }
            return c;
        }

        public List<Employee> readAllEmployee()
        {
            List<Employee> lis = new List<Employee>();

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "select * from Employee";

                cmd.CommandType = System.Data.CommandType.Text;

                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Employee emp = new Employee();

                    emp.eid = Convert.ToInt32(rd["eid"]);
                    emp.ename = Convert.ToString(rd["ename"]);
                    emp.email = Convert.ToString(rd["email"]);
                    emp.epass = Convert.ToString(rd["epass"]);
                    emp.phone = Convert.ToInt32(rd["phone"]);
                    emp.designation = Convert.ToString(rd["designation"]);

                    lis.Add(emp);

                }
            }
            catch(Exception ex)
            {
                lis = null;
                Console.WriteLine("Exception occured {0}", ex.Source);
            }
            finally
            {
                con.Close();
            }
            return lis;
        }

        public int updateEmployee(int id)
        {
            int c = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "update Employee " +
                                  " set  ename= @ename, email= @email, epass= @epass, phone= @phone, designation=@designation" +
                                  " where eid = @empid";

                cmd.CommandType = System.Data.CommandType.Text;

                Employee emp = new Employee();

                /*SqlParameter p1 = new SqlParameter("@eid", System.Data.SqlDbType.Int);
                p1.Value = emp.eid;
                cmd.Parameters.Add(p1);*/

                SqlParameter p2 = new SqlParameter("@ename", System.Data.SqlDbType.VarChar, 50);
                p2.Value = emp.ename;
                cmd.Parameters.Add(p2);

                SqlParameter p3 = new SqlParameter("@email", System.Data.SqlDbType.VarChar, 100);
                p3.Value = emp.email;
                cmd.Parameters.Add(p3);

                SqlParameter p4 = new SqlParameter("@epass", System.Data.SqlDbType.VarChar, 50);
                p4.Value = emp.epass;
                cmd.Parameters.Add(p4);

                SqlParameter p5 = new SqlParameter("@phone", System.Data.SqlDbType.Int);
                p5.Value = emp.phone;
                cmd.Parameters.Add(p5);

                SqlParameter p6 = new SqlParameter("@designation", System.Data.SqlDbType.VarChar, 100);
                p6.Value = emp.designation;
                cmd.Parameters.Add(p6);

                SqlParameter p7 = new SqlParameter("@empid", System.Data.SqlDbType.Int);
                p7.Value = id;
                cmd.Parameters.Add(p7);

                con.Open();

                c = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                c = -1;
                Console.WriteLine("Exception occcured {0}", ex.Source);
            }
            finally
            {
                con.Close();
            }
            return c;
        }

        public int deleteEmployee(int id)
        {
            int c = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "delete from Employee where eid = @eid";

                cmd.CommandType = System.Data.CommandType.Text;

                SqlParameter p1 = new SqlParameter("@eid", System.Data.SqlDbType.Int);
                p1.Value = id;
                cmd.Parameters.Add(p1);

                con.Open();

                c = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                c = -1;
                Console.WriteLine("Exception occured {0}", ex.Source);
            }
            finally
            {
                con.Close();
            }
            return c;
            
        }

        public Employee FindEmployee(int e)
        {
            Employee emp = new Employee();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "select * from Employee where eid=@Empid";

            SqlParameter p1 = new SqlParameter("@Empid", System.Data.SqlDbType.Int);
            p1.Value = e;
            cmd.Parameters.Add(p1);

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    emp.eid = Convert.ToInt32(rd["eid"]);
                    emp.ename = Convert.ToString(rd["ename"]);
                    emp.email = Convert.ToString(rd["email"]);
                    emp.epass = Convert.ToString(rd["epass"]);
                    emp.phone = Convert.ToInt32(rd["phone"]);
                    emp.designation = Convert.ToString(rd["designation"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured");
            }
            finally
            {
                con.Close();
            }

            return emp;

        }
    }
}
