using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

/*

namespace BigSnowManUI
{
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {


                //Question 1
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "myPassw0rd";      // update me
                builder.InitialCatalog = "master";



                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    String sql = "USE AP;";

                    //question 2
                    using (System.Data.SqlClient.SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("selection of AP DB.");
                    }

                    StringBuilder sb = new StringBuilder();

                    //Connection Test
                    //Get information from Vendors via Select

                    Console.WriteLine("\n\nSelect all from Vendors table, press any key to continue...");

                    sb.Append("SELECT VendorID, VendorName, VendorCity FROM Vendors;");
                    sql = sb.ToString();


                    Console.ReadKey(true);
                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                Console.WriteLine("{0}\t {1}\t\t\t\t {2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));


                                while (reader.Read())
                                {
                                    Console.WriteLine("{0}\t\t {1}\t\t\t\t {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                }
                            }
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }


                    //Question 3
                    //Get information from Invoice via Select using a parameter
                    sb.Clear();
                    Console.WriteLine("\n\nSelect all from Invoice table, press any key to continue...");
                    Console.ReadKey(true);


                    int invoiceTotal = 2000;

                    //GO is used in SQL Server tools, not a T-SQL instruction.
                    sb.Append("USE AP;\n");

                    sb.Append("SELECT InvoiceID, VendorID, InvoiceNumber, InvoiceTotal  FROM Invoices\n");
                    sb.Append("     WHERE InvoiceTotal > @pricePoint\n");
                    sb.Append("     ORDER BY invoiceTotal DESC;");
                    sql = sb.ToString();

                    Console.WriteLine(sql);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("@pricePoint", invoiceTotal);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                Console.WriteLine("{0}\t {1}\t {2}\t {3}", reader.GetName(0), reader.GetName(1), reader.GetName(2),
                                        reader.GetName(3));
                                while (reader.Read())
                                {

                                    Console.WriteLine("{0}\t\t {1}\t\t {2} \t\t {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), ((int)reader.GetDecimal(3)));
                                }

                            }

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }


                    //Question 4a:  INSERT
                    //Update Terms table via INSERT (ExecuteNonQuery).

                    Console.WriteLine("\n\nUpdate Terms table via Insert; press any key to continue...");
                    Console.ReadKey(true);

                    sb.Clear();
                    //GO is used in SQL Server tools, not a T-SQL instruction.
                    sb.Append("USE AP;\n");

                    sb.Append("INSERT INTO Terms ( TermsDescription, TermsDueDays) VALUES\n");
                    sb.Append("     ('Net due 120 days', 120),\n");
                    sb.Append("     ('Net due 150 days', 150),\n");
                    sb.Append("     ('Net due 180 days', 180),\n");
                    sb.Append("     ('Net due 210 days', 210);\n");

                    sql = sb.ToString();

                    Console.WriteLine(sql);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {


                            command.ExecuteNonQuery();
                            Console.WriteLine("Records inserted");

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                    //Question 4b:  UPDATE
                    //Update Terms table via UPDATE (ExecuteNonQuery).

                    Console.WriteLine("\n\nUpdate Terms table via Update; press any key to continue...");
                    Console.ReadKey(true);

                    sb.Clear();
                    //GO is used in SQL Server tools, not a T-SQL instruction.
                    sb.Append("USE AP;\n");

                    int newValue = 121;
                    int oldValue = 120;

                    sb.Append("UPDATE TERMS SET TermsDueDays = @newValue\n");
                    sb.Append("     WHERE TermsDueDays = @oldValue;\n");


                    sql = sb.ToString();

                    Console.WriteLine(sql);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("@newValue", newValue);
                            command.Parameters.AddWithValue("@oldValue", oldValue);

                            command.ExecuteNonQuery();
                            Console.WriteLine("Record updated");

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }


                    //Question 4C:  DELETE
                    //Update Terms table via DELETE (ExecuteNonQuery).

                    Console.WriteLine("\n\nUpdate Terms table via DELETE; press any key to continue...");
                    Console.ReadKey(true);

                    sb.Clear();
                    //GO is used in SQL Server tools, not a T-SQL instruction.
                    sb.Append("USE AP;\n");


                    int delValue = 121;

                    sb.Append("DELETE FROM Terms\n");
                    sb.Append("     WHERE TermsDueDays = @delValue\n");
                    sb.Append("     OR TermsDueDays = 150\n");
                    sb.Append("     OR TermsDueDays = 180\n");
                    sb.Append("     OR TermsDueDays = 210;\n");


                    sql = sb.ToString();

                    Console.WriteLine(sql);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("@delValue", delValue);


                            command.ExecuteNonQuery();
                            Console.WriteLine("Records deleted");

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }



                    //Question 5: ExecuteScalar
                    //Update Terms table via DELETE (ExecuteNonQuery).

                    Console.WriteLine("\n\nReturn singular escalar value; press any key to continue...");
                    Console.ReadKey(true);

                    sb.Clear();
                    //GO is used in SQL Server tools, not a T-SQL instruction.
                    sb.Append("USE AP;\n");




                    sb.Append("SELECT SUM(InvoiceTotal)\n");
                    sb.Append("     FROM Invoices;\n");



                    sql = sb.ToString();

                    Console.WriteLine(sql);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {



                            object invoiceTotalSum = command.ExecuteScalar();
                            Int32 invoiceTotalCapital = System.Convert.ToInt32(invoiceTotalSum);
                            command.ExecuteNonQuery();
                            Console.WriteLine("Total revenue in invoices: $" + invoiceTotalCapital);

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }


            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}

*/
