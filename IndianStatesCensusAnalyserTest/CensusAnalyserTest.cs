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

        IndianStatesCensusAnalyserProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyserProblem.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// TC1.1
        [Test]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        // TC1.2
        [Test]
        public void GivenWrongStateCensusCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.exType);
        }
        // TC1.3
        [Test]
        public void GivenStateCensusDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.exType);
        }

        // TC1.4

        [Test]
        public void GivenStateCensusDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.exType);
        }
        //TC1.5
        [Test]
        public void GivenStateCensusDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var censusException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.exType);
        }
    }
}