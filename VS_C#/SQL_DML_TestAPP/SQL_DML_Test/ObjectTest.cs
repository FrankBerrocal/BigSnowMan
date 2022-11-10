using System;


namespace SQL_DML_Test 
{
	public class ObjectTest
	{
        string dataSource = "localhost, 1440";
        string userId = "sa";
        string password = "myPassw0rd";
        string initialCatalog = "master";

        static void Main(string[] args)
        {
            try
            {
                BuilderObject builder = new BuilderObject(dataSource, userId, password, initialCatalog);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
}

