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
    class CargoPlane:Plane
    {
        protected double cargoMaxLengthMeters;
        protected double cargoMaxWidthMeters;
        protected double cargoMaxHeightMeters;
        protected int standardContainersToCarryCount;
        public CargoPlane(string pAircraftType, string pAircraftID, string pAircraftModel, int pMaxRangeKm, int pPayLoadKg, int pCrewCount,
            double pCargoMaxLengthMeters, double pCargoMaxWidthMeters, double pCargoMaxHeightMeters, int pStandardContainersToCarryCount) : base(pAircraftType, pAircraftID, pAircraftModel, pMaxRangeKm, pPayLoadKg, pCrewCount)
        {
            //Console.WriteLine("Child cargo Plane constructor");
            cargoMaxLengthMeters = pCargoMaxLengthMeters;
            cargoMaxWidthMeters = pCargoMaxWidthMeters;
            cargoMaxHeightMeters = pCargoMaxHeightMeters;
            standardContainersToCarryCount = pStandardContainersToCarryCount;
        }
        public override string GetPlaneInfo()
        {
            return base.GetPlaneInfo() + "\nCargo Max Length Meters: " + cargoMaxLengthMeters +
                "\nCargo Max Width Meters: " + cargoMaxWidthMeters +
                "\nCargo Max Height Meters: " + cargoMaxHeightMeters +
                "\nStandard Containers To Carry: " + standardContainersToCarryCount;
        }
        public override string Export()
        {
            return base.Export() + "," + cargoMaxLengthMeters + "," + cargoMaxWidthMeters + "," + cargoMaxHeightMeters+","+ standardContainersToCarryCount;
        }
    }

}
