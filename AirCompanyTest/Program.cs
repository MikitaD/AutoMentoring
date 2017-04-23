using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompanyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //directory of files to import/export
            string path = @"c:\AirCompanyFolder";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            //import file name
            string fileName = "plh14zho.ini.txt";
            path = System.IO.Path.Combine(path, fileName);
            //List<Plane> planes = new List<Plane>();
            // planes.Add(Plane1);
            // planes.Add(Plane2);
            // planes.Add(Plane3);
            //planes.Add(Plane4); 
            FileReader Reader = new FileReader();
            List<Plane> planes = Reader.ReadFile(path);
            AirCompany Company1 = new AirCompany("United Airlines", "US", planes);
           // Company1.AddPlane(Plane1);
          //  Company1.AddPlane(Plane2);
          //  Company1.AddPlane(Plane3);
          //  Company1.AddPlane(Plane4);
            Console.WriteLine(Company1.GetBasicCompanyInfo());
            //  Console.WriteLine(Company1.GetSummaryPayload());
            //  Console.WriteLine(Company1.GetSummarySeats());
            //  Console.WriteLine(Company1.GetPlanesSortedByMaxRange());

            Console.WriteLine(path);
            //File.WriteAllText(path, Company1.GetBasicCompanyInfo());
            fileName = "3.dat";
            path = @"c:\AirCompanyFolder";
            path = System.IO.Path.Combine(path, fileName);
            Company1.Serialize(path);
            planes = Reader.ReadBinaryFileDeserialize(path);
            AirCompany Company2 = new AirCompany("PanAmerican Airlines", "US", planes);
            Console.WriteLine(Company2.GetBasicCompanyInfo());
            Console.WriteLine(Company2.GetPlanesSortedByMaxRange()); 
            Console.Read();
        }
    }
}
