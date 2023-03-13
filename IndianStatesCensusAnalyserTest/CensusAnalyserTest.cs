using IndianStatesCensusAnalyserProblem.DTO;
using IndianStatesCensusAnalyserProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static IndianStatesCensusAnalyserProblem.CensusAnalyser;

namespace IndianStatesCensusAnalyserTest
{
    [TestClass]
    public class CensusAnalyserTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusfilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSV\IndianStateCensusData.csv";
        static string wrongIndianStateCensusfileType = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCensusData.txt";
        static string delimiterIndianCensusfilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianCensusfilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongHeaderIndianStateCensusData.csv";

        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodefilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodefileType = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCode.txt";
        static string wrongIndianStateCodefilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSV\IndianStateCode.csv";
        static string delimiterIndianCodefilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndianStateCode.csv";
        static string wrongHeaderIndianCodefilePath = @"C:\Users\venky\source\Repos2\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongHeaderIndianStateCode.csv";


        IndianStatesCensusAnalyserProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyserProblem.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// TC1.1
        [TestMethod]
        public void GivenStateCensusCSVFileShouldReturnRecords()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        // TC1.2
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.exType);
        }

        [TestMethod]
        // TC1.3
        public void GivenStateCensusDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.exType);
        }

        // TC1.4
        [TestMethod]
        public void GivenStateCensusDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.exType);
        }
        //TC1.5
        [TestMethod]
        public void GivenStateCensusDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.exType);
        }

        // TC2.1
        [TestMethod]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodefilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        // TC2.2
        [TestMethod]
        public void GivenWrongStateCodeCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.exType);
        }

        // TC2.3
        [TestMethod]
        public void GivenStateCodeDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodefileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.exType);
        }

        // TC2.4
        [TestMethod]
        public void GivenStateCodeDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var stateCodeException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.exType);
        }

        // TC2.5
        [TestMethod]
        public void GivenStateCodeDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var statecodeException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, statecodeException.exType);
        }
    }
}