using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AirCompanyTest
{
    class MainMenu
    {
        public void ShowStartupMenuOptions()
        {
            Console.WriteLine("Welcome to AirCompany console application");
            Console.WriteLine("Press 1 to load data from .txt file");
            Console.WriteLine("Press 2 to load data from .dat file");
            Console.WriteLine("Press 3 to load data from .json file");
        }
        public void ShowCompanyCreatedMessage()
        {
            Console.WriteLine("Data is successfully loaded");
        }
        public void ShowAirCompanyBasicOptions()
        {
            Console.WriteLine("Press 1 to get summary payload");
            Console.WriteLine("Press 2 to get summary seats");
            Console.WriteLine("Press 3 to sort planes by max range");
            Console.WriteLine("Press 4 to filter planes by range");
            Console.WriteLine("Press 5 to export data to .txt file");
            Console.WriteLine("Press 6 to export data to binary .dat file");
            Console.WriteLine("Press 7 to export data to .json file");
            Console.WriteLine("Press 8 to forget about planes and work with Northwind DB");
            Console.WriteLine("Press 9 to exit");
        }
        public void ShowDBOptions()
        {
            Console.WriteLine("Press 1 to select top products");
            Console.WriteLine("Press 2 to run CRUD scenarion on Regions table");
            Console.WriteLine("Press 3 to use stored procedure");
            Console.WriteLine("Press 9 to exit");
        }
        public void ShowFilterMenu()
        {
            Console.WriteLine("Please specify range to filter planes");
        }
        public void ShowIfContinueChoise()
        {
            Console.WriteLine("Press 1 to go to back main menu, press any other key to continue");
        }
    }
}
