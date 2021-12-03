using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public abstract class CensusAdapter
    {
       
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found");

            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid file type");
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, "Incorrect header in data");
            }
            return censusData;
        }
    }
}
