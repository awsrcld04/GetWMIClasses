using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace GetWMIClasses
{
    class GetWMIClasses
    {
        static void Main(string[] args)
        {
            ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
            scope.Connect();

            using (ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, new ObjectQuery("SELECT * FROM meta_class")))
            {
                searcher.Options.EnumerateDeep = false;
                using (ManagementObjectCollection results = searcher.Get())
                {
                    foreach (ManagementObject result in results)
                    {
                        Console.WriteLine(result.ClassPath);
                    };
                };
            };
        } 
    }
}
