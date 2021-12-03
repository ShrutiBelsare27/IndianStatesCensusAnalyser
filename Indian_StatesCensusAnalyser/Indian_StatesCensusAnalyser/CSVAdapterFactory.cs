using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, "No such country");
            }
        }
    }
}
