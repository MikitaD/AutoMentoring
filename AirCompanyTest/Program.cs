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
            List<Plane> planes = null;
            int choice = 0;
            //company import from files options
            bool repeatInput = true;
            while (repeatInput == true)
            {
                menu.ShowStartupMenuOptions();
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    repeatInput = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Please try again. Input error occurred: '{0}'", e);
                    repeatInput = true;
                }
                if (!repeatInput == true)
                {
                try
                {
                    if (choice >= 1 && choice < 4)
                    {
                        switch (choice)
                        {
                            case 1:
                                {
                                    //company import from text file
                                    planes = Reader.ReadFile(path);
                                }
                                break;
                            case 2:
                                {
                                    //company import from bin file
                                    fileName = datFileName;
                                    path = System.IO.Path.Combine(folder, fileName);
                                    planes = Reader.ReadBinaryFileDeserialize(path);
                                }
                                break;
                            case 3:
                                {
                                    //company import from json file
                                    fileName = jsonFileName;
                                    path = System.IO.Path.Combine(folder, fileName);
                                    planes = Reader.ReadJsonFileDeserialize(path);
                                }
                                break;
                        }
                    }
                    else
                    {
                        throw (new MenyEntryOutOfRangeException("MenyEntryOutOfRangeException Generated: Please specify number from 1 to 3"));
                    }
                }
                catch (MenyEntryOutOfRangeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message.ToString());
                    repeatInput = true;
                }
                }
            }
            Console.Clear();
            AirCompany Company1 = new AirCompany("United Airlines", "US", planes);
            menu.ShowCompanyCreatedMessage();
            Console.WriteLine(Company1.GetBasicCompanyInfo());
            repeatInput = false;
            do {
            menu.ShowAirCompanyBasicOptions();
            try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    repeatInput = false;
                }
            catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Please try again. Input error occurred: '{0}'", e);
                    repeatInput = true;
                }
                if (!repeatInput == true)
                {
                    try
                    {
                        if (choice >= 1 && choice < 9)
                        {
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine(Company1.GetSummaryPayload());
                                        menu.ShowIfContinueChoise();
                                        ConsoleKeyInfo keyPressed;
                                        keyPressed = Console.ReadKey();
                                        if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                                        {
                                            repeatInput = true;
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            repeatInput = false;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine(Company1.GetSummarySeats());
                                        repeatInput = true;

                                    }
                                    break;
                                case 3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine(Company1.GetPlanesSortedByMaxRange());
                                        repeatInput = true;
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.Clear();
                                        menu.ShowFilterMenu();
                                        int rangeMin = Convert.ToInt32(Console.ReadLine());
                                        menu.ShowFilterMenu();
                                        int rangeMax = Convert.ToInt32(Console.ReadLine());
                                        string result = Company1.GetPlanesFiltered(rangeMin, rangeMax);
                                        if (result != null)
                                        {
                                            Console.WriteLine("Following planes matched:");
                                            Console.WriteLine(result);
                                        }
                                        else Console.WriteLine("No Planes was found");
                                        repeatInput = true;
                                    }
                                    break;
                                case 5:
                                    {
                                        Console.Clear();
                                        Company1.ExporPlanesDataToFile(folder);
                                        repeatInput = true;
                                    }
                                    break;
                                case 6:
                                    {
                                        Company1.Serialize(folder);
                                        repeatInput = true;
                                    }
                                    break;
                                case 7:
                                    {
                                        Company1.SerializeToJSON(folder);
                                        repeatInput = true;
                                    }
                                    break;
                                case 8:
                                    {
                                        DBInteraction DataBase = new DBInteraction();
                                        var dbConn = DataBase.Connect();
                                        int id = 5;
                                        string custID = "FURIB";
                                        menu.ShowDBOptions();
                                        choice = Convert.ToInt32(Console.ReadLine());
                                        switch (choice)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    DataBase.SelectTopProducts(dbConn);
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.Clear();
                                                    DataBase.InsertIntoRegions(dbConn, id);
                                                    DataBase.SelectRegions(dbConn);
                                                    DataBase.UpdateRegionByID(dbConn, id);
                                                    DataBase.SelectRegions(dbConn);
                                                    DataBase.DeleteRegionByID(dbConn, id);
                                                    DataBase.SelectRegions(dbConn);
                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.Clear();
                                                    DataBase.SelectCustomerOrdersUsingStoredProcedure(dbConn, custID);
                                                }
                                                break;
                                        }
                                        repeatInput = true;
                                    }
                                    break;
                                case 9:
                                    {
                                        repeatInput = false;
                                    }
                                    break;
                            }
                        } else
                        {
                            throw (new MenyEntryOutOfRangeException("MenyEntryOutOfRangeException Generated: Please specify number from 1 to 9"));
                        }
                    }
                     catch (MenyEntryOutOfRangeException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message.ToString());
                        repeatInput = true;
                    }
                }
            }
            while (repeatInput == true);
            Console.Read();
        }
    }
}
