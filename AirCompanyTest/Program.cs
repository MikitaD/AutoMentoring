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
            string folder = @"c:\AirCompanyFolder";
            if (Directory.Exists(folder) == false)
            {
                Directory.CreateDirectory(folder);
            }
            //import file name
            string fileName = "plh14zho.ini.txt";
            string datFileName = "BinaryFileAirCompany.dat";
            string jsonFileName = "ExportPlaneDataJSON_20170423173942468";
            string path = System.IO.Path.Combine(folder, fileName);
            Console.WriteLine(path);
            //company import from text file
            FileReader Reader = new FileReader();
            List<Plane> planes = Reader.ReadFile(path);
            AirCompany Company1 = new AirCompany("United Airlines", "US", planes);
            Console.WriteLine(Company1.GetBasicCompanyInfo());
            //  Console.WriteLine(Company1.GetSummaryPayload());
            //  Console.WriteLine(Company1.GetSummarySeats());
            //  Console.WriteLine(Company1.GetPlanesSortedByMaxRange());
            Company1.ExporPlanesDataToFile(folder);
            //company import from bin file
            fileName = datFileName;
            path = System.IO.Path.Combine(folder, fileName);
            planes = Reader.ReadBinaryFileDeserialize(path);
            AirCompany Company2 = new AirCompany("PanAmerican Airlines", "US", planes);
            Console.WriteLine(Company2.GetBasicCompanyInfo());
            Company2.Serialize(folder);
            Company2.SerializeToJSON(folder);
            fileName = jsonFileName;
            path = System.IO.Path.Combine(folder, fileName);
            planes = Reader.ReadJsonFileDeserialize(path);
            AirCompany Company3 = new AirCompany("Lufthansa", "GE", planes);
            Console.WriteLine(Company3.GetBasicCompanyInfo());
            Console.WriteLine(Company3.GetPlanesSortedByMaxRange());
            Console.Read();
        }
    }
}
