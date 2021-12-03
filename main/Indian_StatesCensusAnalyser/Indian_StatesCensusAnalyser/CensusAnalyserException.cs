using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER, INCORRECT_DELIMITER, NO_SUCH_COUNTRY
        }

        public ExceptionType exceptionType;

        
        public CensusAnalyserException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
