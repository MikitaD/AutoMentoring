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
    class FileReader
    {
        public List<Plane> ReadFile(string path)
        {
            List<Plane> airCompanyImport = new List<Plane>();
            string[] separator = { "," };
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[0] == "Passenger")
                            airCompanyImport.Add(new PassengerPlane(result[0], result[1], result[2], Int32.Parse(result[3]), Int32.Parse(result[4]), Int32.Parse(result[5]), Int32.Parse(result[6]),
                                Int32.Parse(result[7]), Int32.Parse(result[8])));
                        else if (result[0] == "Cargo")
                        {
                            airCompanyImport.Add(new CargoPlane(result[0], result[1], result[2], Int32.Parse(result[3]), Int32.Parse(result[4]), Int32.Parse(result[5]), Int32.Parse(result[6]),
                                Int32.Parse(result[7]), Int32.Parse(result[8]), Int32.Parse(result[9])));
                        }
                        else
                        {
                            Console.WriteLine("Parsing error occured");
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Error: File does not exist");
            }
            return airCompanyImport;
        }
        public List<Plane> ReadBinaryFileDeserialize(string path)
        {
            List<Plane> airCompanyImport = new List<Plane>();
            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(path, FileMode.Open);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                //airCompanyImport.Add((Plane) 
                airCompanyImport =(List<Plane>) formatter.Deserialize(fs);
                Console.WriteLine("Serialization ok");
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            Console.WriteLine("abc");

            return airCompanyImport;
        }
            
    }

 }

