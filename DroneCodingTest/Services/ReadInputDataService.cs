using DroneCodingTest.Data;
using DroneCodingTest.Models;

namespace DroneCodingTest.Services
{
    public class ReadInputDataService
    {
        private StreamReader _inputFile { get; set; }

        private List<string> _fileInformation = new List<string>();

        private List<string> _packages = new List<string>();


        public List<string> ReadInputData()
        {
            var textFile = new DataTxtFile();

            // Read the file and parse the data
            using (var inputFile = new StreamReader(textFile.GetTxtFile()))
            {
                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    _fileInformation.Add(line);
                }
            }

            return _fileInformation;
        }

        public List<Drone> GetDronesOrded(List<string> fileInformation)
        {
            fileInformation = _fileInformation;
            var dronesInformation = _fileInformation.First();

            string[] dronesSplited = dronesInformation.Split(',');

            var dronesValuesInStringList = new List<Drone>();
            var dronesOrded = new List<Drone>();
            var dronesList = new List<Drone>();


            for (int i = 0; i <= dronesSplited.Length + 1; i++)
            {
                Console.WriteLine(dronesValuesInStringList);

                if ((i % 2 == 0) && (i != 0))
                {
                    string droneItem = dronesSplited[i - 2];
                    string droneMaxWeightString = dronesSplited[i - 1]
                        .Replace("[","")
                        .Replace("]","");

                    int droneMaxWeightItem = int.Parse(droneMaxWeightString);

                    dronesList.Add(new Drone(droneItem, droneMaxWeightItem));
                }
            }

            var dronesListOrded = dronesList.OrderByDescending(x => x.GetMaxWeight()).ToList();

            return dronesListOrded;
        }





        public List<Package> GetPackagesOrded()
        {
            List<string> packagesListString = new List<string>();
            var packagesList = new List<Package>();
            string[] packagesItemSplited = new[] { "" };



            for (int i = 1; i < _fileInformation.Count; i++)
            {
                var s = _fileInformation[i];
                _packages.Add(s);
            }



            for (int i = 0; i < _packages.Count; i++)
            {


                packagesItemSplited = _packages[i].Split(",");

                packagesListString.Add(new String(packagesItemSplited[0]));
                packagesListString.Add(new String(packagesItemSplited[1]));

            }

            for (int i = 0; i < packagesListString.Count + 1; i++)
            {
                if ((i % 2 == 0) && (i != 0))
                {
                    string namePackage = packagesListString[i - 2];
                    string packageWeightString = packagesListString[i - 1]
                        .Replace("[", "")
                        .Replace("]", "");

                    int packageWeight = int.Parse(packageWeightString)
                        ;
                    packagesList.Add(new Package(namePackage, packageWeight));

                }
            }

            var packagesListOrded = packagesList.OrderByDescending(x => x.GetPackageWeight()).ToList();

            return packagesListOrded;
        }
    }
}