using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;

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
            planes.Sort((x, y) => x.GetMaxRangeKm().CompareTo(y.GetMaxRangeKm()));
            foreach (Plane plane in planes)
            {
                Console.WriteLine(plane.ToString());
            }
            return null;
        }

        public string GetPlanesFiltered()
        {
            var queryPlanes = from Plane in planes
                              where Plane.GetMaxRangeKm() > 9000
                              select Plane;
            foreach (Plane plane in planes)
            {
                Console.WriteLine(plane.ToString());
            }
            return null;
        }

        public void ExportAircompanyDataToFile(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            foreach (Plane plane in planes)
            {
                file.WriteLine(plane.ToString());
            }
            file.Close();
        }

        public void ExporPlanesDataToFile(string path)
        {            
        System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            foreach (Plane plane in planes)
            {
                file.WriteLine(plane.Export());
            }
            file.Close();
        }
        //public void ExporPlanesDataToBinaryFile(string path)
        //{
        //    BinaryWriter writer = new BinaryWriter(new FileStream(path, FileMode.Create));
        //        foreach (Plane plane in planes)
        //    {
        //            writer.Write(plane.Export());
        //    }
        //    writer.Close();
        //}
        public void Serialize(string path)
        {
            // In this case, use a file stream.
            FileStream fs = new FileStream(path, FileMode.Create);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                //foreach (Plane plane in planes)
                //{
                //    formatter.Serialize(fs, plane);
                //}
                formatter.Serialize(fs, planes);
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
    }
}
