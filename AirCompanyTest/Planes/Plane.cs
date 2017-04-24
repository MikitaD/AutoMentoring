using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirCompanyTest
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    class Plane 
    {
        protected string aircraftID;
        protected string aircraftModel;
        protected int maxRangeKm;
        protected int payLoadKG;
        protected int crewCount;
        protected string aircraftType;
        //constructors
        public Plane()
        {
            Console.WriteLine("Parameterless parent constructor used");
        }
        public Plane(string pAircraftType, string pAircraftID, string pAircraftModel, int pMaxRangeKm,int pPayLoadKg, int pCrewCount)
        {
            //Console.WriteLine("Basic parent constructor used");
            aircraftType = pAircraftType;
            aircraftID = pAircraftID;
            aircraftModel = pAircraftModel;
            maxRangeKm = pMaxRangeKm;
            payLoadKG = pPayLoadKg;
            crewCount = pCrewCount;

        }
        //methods
        public virtual string GetPlaneInfo()
        {
            return
                "\nAircraft Type: " + aircraftType +
                "\nAircraft ID: " + aircraftID +
                "\nAircraft Model: " + aircraftModel +
                "\nMax Range: " + maxRangeKm +
                "\nMax Payload: " + payLoadKG +
                "\nCrew Count: " + crewCount;
        }
        public virtual string Export()
        {
            return aircraftType + "," + aircraftID+ "," + aircraftModel + "," + maxRangeKm + "," + payLoadKG + "," + crewCount;
        }
        public virtual int CountSeats()
        {
            return crewCount;
        }
        public string GetID ()
        {
            return aircraftID;
        }
        public int GetPayLoad()
        {
            return payLoadKG;
        }
        public int GetMaxRangeKm()
        {
            return maxRangeKm;
        }

    }
}
