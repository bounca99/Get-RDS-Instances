using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Amazon.RDS;
using Amazon.RDS.Model;


namespace RDS
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonRDSClient rdsClient = new AmazonRDSClient();
            DescribeDBInstancesRequest myRequest = new DescribeDBInstancesRequest();
            DescribeDBInstancesResponse myResponse = rdsClient.DescribeDBInstances(myRequest);

            try
            {
                foreach (DBInstance dbinstance in myResponse.DBInstances)
                {
                    Console.WriteLine("Name: {0}, Engine: {1}, Version: {2}, Class: {3}, User: {4}",
                                        dbinstance.DBName, 
                                        dbinstance.Engine, 
                                        dbinstance.EngineVersion, 
                                        dbinstance.DBInstanceClass, dbinstance.MasterUsername
                                        );
                }
            }
            catch
            {
                Console.WriteLine("Error has Occurred.  Kindly contact your System Administrator.");
            }

            Console.ReadLine();
        }

        

    }
}
