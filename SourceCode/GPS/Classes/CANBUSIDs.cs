using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AgOpenGPS
{
    public class CANBUSIDs
    {
        public List<CANBUSVehicleInfo> VehicleData { get; set; }

        public List<CANBUSVehicleInfo> FilteredVehicleData { get; set; }

        public CANBUSIDs(string filePath)
        {
            VehicleData = ReadCSV(filePath);
        }

        public List<CANBUSVehicleInfo> ReadCSV(string filePath)
        {
            var vehicleList = new List<CANBUSVehicleInfo>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string headerLine = sr.ReadLine(); // Skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        if (values.Length == 8)
                        {
                            var vehicleInfo = new CANBUSVehicleInfo
                            {
                                Brand = values[0],
                                Model = values[1],
                                Label = values[2],
                                CANBUS = values[3],
                                FilterID = values[4],
                                Byte = int.Parse(values[5]),
                                OnStateAnd = int.Parse(values[6]),
                                Operation = values[7]
                            };
                            vehicleList.Add(vehicleInfo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            return vehicleList;
        }
        public void FilterByBrand(string brand)
        {
            if (brand != "X") {
                FilteredVehicleData = VehicleData.Where(v => v.Brand == brand).ToList();
            }
        }
    }

    public class CANBUSVehicleInfo
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Label { get; set; }
        public string CANBUS { get; set; }
        public string FilterID { get; set; }
        public int Byte { get; set; }
        public int OnStateAnd { get; set; }
        public string Operation { get; set; }
    }
}