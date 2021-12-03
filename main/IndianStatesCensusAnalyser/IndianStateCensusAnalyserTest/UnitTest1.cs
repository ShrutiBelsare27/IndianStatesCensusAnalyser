using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\User\Desktop\Assignment\IndianCensusAnalyzer\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\User\Desktop\Assignment\IndianCensusAnalyzer\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongIndianStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\User\Desktop\Assignment\IndianCensusAnalyzer\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongIndianStateCensusFileType.txt";
        static string delimiterIndianCensusData = @"C:\Users\User\Desktop\Assignment\IndianCensusAnalyzer\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianStateCensusData = @"C:\Users\User\Desktop\Assignment\IndianCensusAnalyzer\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTest\CSVFiles\WrongHeaderIndianStateCensusData.csv";

        

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
       

        
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            
        }

       
        /// Test Case 1.1 Given the indian census data file when reader should return census data count.
        
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

    
        /// Test Case 1.2 Given the indian census data file when incorrect then return File not found exception.
   
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.exceptionType);
        }

      
        /// Test Case 1.3 Given the indian census data csv file when correct but type incoorect then return invalid file type exception.
        
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.exceptionType);
        }

        /// Test Case 1.4 Given the indian census data csv file when correct but delimiter incoorect then return incorrect delimiter exception.
       
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.exceptionType);
        }

      
        /// Test Case 1.5 Given the indian census data csv file when correct but header incoorect then return incorrect delimiter exception.
        
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.exceptionType);
        }

      
       
    }
}