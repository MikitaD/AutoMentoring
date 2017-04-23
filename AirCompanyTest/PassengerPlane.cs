using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompanyTest
{
    [Serializable]
    class PassengerPlane : Plane 
    {
        protected int firstClassSeatsCount;
        protected int secondClassSeatsCount;
        protected int stewardCrewCount;

        public PassengerPlane()
        {
            Console.WriteLine("Parameterless child constructor used");
        }

        public PassengerPlane(string pAircraftType, string pAircraftID, string pAircraftModel,int pMaxRangeKm,int pPayLoadKg,int pCrewCount,
            int pFirstClassSeatsCount, int pSecondClassSeatsCount, int pStewardCrewCount) : base (pAircraftType, pAircraftID, pAircraftModel, pMaxRangeKm, pPayLoadKg, pCrewCount)
        {
            //Console.WriteLine("Child passenger Plane constructor");
            firstClassSeatsCount = pFirstClassSeatsCount;
            secondClassSeatsCount = pSecondClassSeatsCount;
            stewardCrewCount = pStewardCrewCount;
        }
        public override string ToString()
        {
                return base.ToString() + "\nFirst Class Seats Count: " + firstClassSeatsCount +
                    "\nSecond Class Seats Count: " + secondClassSeatsCount +
                    "\nSteward Crew Count: " + stewardCrewCount;
        }
        public override int CountSeats()
        {
            int totalSeats = stewardCrewCount + firstClassSeatsCount + secondClassSeatsCount + crewCount;
            return totalSeats;
        }
        public override string Export()
        {
            return base.Export() + "," + firstClassSeatsCount +","+ secondClassSeatsCount+","+ stewardCrewCount;
        }
    }

}
