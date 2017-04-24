using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompanyTest
{
    using System.Configuration;
    class Program
    {   
        static void Main(string[] args)
        {
            //directory of files to import/export
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string folderName = "Data";
            string folder = System.IO.Path.Combine(projectFolder, folderName);
            //import file name
            string fileName = "plh14zho.ini.txt";
            string datFileName = "BinaryFileAirCompany.dat";
            string jsonFileName = "ExportPlaneDataJSON_20170423173942468";
            string path = System.IO.Path.Combine(folder, fileName);
            MainMenu menu = new MainMenu();
            FileReader Reader = new FileReader();
            //company import from files options
            menu.ShowStartupMenuOptions();
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        //company import from text file
                        List<Plane> planes = Reader.ReadFile(path);
                        AirCompany Company1 = new AirCompany("United Airlines", "US", planes);
                        menu.ShowCompanyCreatedMessage();
                        Console.WriteLine(Company1.GetBasicCompanyInfo());
                        menu.ShowAirCompanyBasicOptions();
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    Console.WriteLine(Company1.GetSummaryPayload());
                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine(Company1.GetSummarySeats());
                                }
                                break;
                            case 3:
                                {
                                    Console.WriteLine(Company1.GetPlanesSortedByMaxRange());
                                }
                                break;
                            case 4:
                                {
                                    menu.ShowFilterMenu();
                                    int range = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(Company1.GetPlanesFiltered(range));
                                }
                                break;
                        }
                        Company1.ExporPlanesDataToFile(folder);
                    }
                    break;
                case 2:
                    {
                        //company import from bin file
                        fileName = datFileName;
                        path = System.IO.Path.Combine(folder, fileName);
                        List<Plane> planes = Reader.ReadBinaryFileDeserialize(path);
                        AirCompany Company1 = new AirCompany("PanAmerican Airlines", "US", planes);
                        Console.WriteLine(Company1.GetBasicCompanyInfo());
                        menu.ShowAirCompanyBasicOptions();
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    Console.WriteLine(Company1.GetSummaryPayload());
                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine(Company1.GetSummarySeats());
                                }
                                break;
                            case 3:
                                {
                                    Console.WriteLine(Company1.GetPlanesSortedByMaxRange());
                                }
                                break;
                            case 4:
                                {
                                    menu.ShowFilterMenu();
                                    int range = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(Company1.GetPlanesFiltered(range));
                                }
                                break;
                        }
                        Company1.ExporPlanesDataToFile(folder);
                        Company1.Serialize(folder);

                    }
                    break;
                case 3:
                    {
                        //company import from json file
                        fileName = jsonFileName;
                        path = System.IO.Path.Combine(folder, fileName);
                        List<Plane> planes = Reader.ReadJsonFileDeserialize(path);
                        AirCompany Company1 = new AirCompany("Lufthansa", "GE", planes);
                        Console.WriteLine(Company1.GetBasicCompanyInfo());
                        Console.WriteLine(Company1.GetPlanesSortedByMaxRange());
                        Company1.SerializeToJSON(folder);
                    }
                    break;
            }
            choice = Convert.ToInt32(Console.ReadLine());
            //database part
            DBInteraction DataBase = new DBInteraction();
            var dbConn = DataBase.Connect();
            DataBase.SelectTopProducts(dbConn);
            int id = 5;
            string custID = "FURIB";
            DataBase.InsertIntoRegions(dbConn,id);
            DataBase.SelectRegions(dbConn);
            DataBase.UpdateRegionByID(dbConn,id);
            DataBase.SelectRegions(dbConn);
            DataBase.DeleteRegionByID(dbConn,id);
            DataBase.SelectRegions(dbConn);
            DataBase.SelectCustomerOrdersUsingStoredProcedure(dbConn, custID);
            Console.Read();
        }
    }
}
