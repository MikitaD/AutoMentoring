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
    class AirCompany
    {
        //properties
        protected string companyName;
        protected string countryCode;
        protected List<Plane> planes;

        //constructors
        public AirCompany(string pCompanyName, string pCountryCode)
        {
            companyName = pCompanyName;
            countryCode = pCountryCode;
            Console.WriteLine("Company is created without list");
        }
        public AirCompany(string pCompanyName, string pCountryCode, List<Plane> pPlanes)
        {
            companyName = pCompanyName;
            countryCode = pCountryCode;
            planes = pPlanes;
            Console.WriteLine("Company is created with list");
        }

        //methods
        public string GetCompanyName()
        {
            return companyName;
        }
        public string GetCountryCode()
        {
            return countryCode;
        }
        public List<Plane> GetPlanes()
        {
            return planes;
        }

        public string GetBasicCompanyInfo()
        {
            //return planes.Count;
            return "\nCompany Name: " + companyName +
             "\nCountry Code: " + countryCode +
            "\nPlanes Count: " + planes.Count;
        }

        public void AddPlane(Plane planeX)
        {
            //return planes.Count;
            if (planes == null)
            {
                List<Plane> pPlanes = new List<Plane>();
                pPlanes.Add(planeX);
                planes = pPlanes;
            }
            else
            {
                planes.Add(planeX);
            }
            //return "\nFollowing plane was added: "+ planeX.GetID();
        }

        public string GetSummaryPayload()
        {
            int payloadSumKg = 0;
            foreach (Plane plane in planes)
            {
                payloadSumKg += plane.GetPayLoad();
            }
            return "\nSummary Payload " + payloadSumKg;
        }

        public string GetSummarySeats()
        {
            int summarySeatsCount = 0;
            foreach (Plane plane in planes)
            {
                summarySeatsCount += plane.CountSeats();
            }
            return "\nSummary Seats Count " + summarySeatsCount;
        }

        public string GetPlanesSortedByMaxRange()
        {
            planes.Sort((x, y) => -1 * x.GetMaxRangeKm().CompareTo(y.GetMaxRangeKm()));
            foreach (Plane plane in planes)
            {
                Console.WriteLine(plane.GetPlaneInfo());
            }
            return null;
        }

        public string GetPlanesFiltered(int minRange, int maxRange)
        {
            string resultString = null;
            var queryPlanes = from Plane in planes
                              where Plane.GetMaxRangeKm() >= minRange
                              && Plane.GetMaxRangeKm() <= maxRange
                              select Plane;
            foreach (Plane plane in queryPlanes)
            {
                resultString += "\n"+ plane.GetPlaneInfo();
            }
            return resultString;
        }
        public void ExporPlanesDataToFile(string folder)
        {
            string fileName = "ExportPlaneDataText_" + DateTime.Now.ToString("yyyyMMddHHmmssfff")+".txt";
            string path = System.IO.Path.Combine(folder, fileName);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            foreach (Plane plane in planes)
            {
                file.WriteLine(plane.Export());
            }
            Console.WriteLine("File was successfully exported to" + path);
            file.Close();
        }
        public void Serialize(string folder)
        {
            string fileName = "ExportPlaneDataBinary_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string path = System.IO.Path.Combine(folder, fileName);
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, planes);
                Console.WriteLine("Binary file was successfully exported to" + path);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public void SerializeToJSON(string folder)
        {
            string fileName = "ExportPlaneDataJSON_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string path = System.IO.Path.Combine(folder, fileName);
            TextWriter writer = new StreamWriter(path);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            try
            {
                    string jsonString = JsonConvert.SerializeObject(planes,settings);
                    Console.WriteLine("Binary file was successfully exported to" + path);
                //writer.Write(jsonString);

            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
