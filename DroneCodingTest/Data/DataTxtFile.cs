using System;
namespace DroneCodingTest.Data
{
    public class DataTxtFile
    {
        private string _filePath { get; set; }

        public string GetTxtFile()
        {
            _filePath = @"C:\Users\marle\source\repos\DroneCodingTest\DroneCodingTest\bin\Debug\net6.0\Input.txt";
            return _filePath;
        }
    }
}
