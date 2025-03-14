using Moq;
 
namespace PredictionEngine.Tests;
 
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
 
    [TestCase("ping pon", "pon")]
    public void Should_Call_Monogram(string input,string lastWord)
    {
        var mock = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);
        var result=predictionEngine.predict(input);
        mock.Verify(p => p.predictUsingMonogram(lastWord), Times.Once());
    }
 
    
    [TestCase("ping pon ", "pon")]
    public void Should_Call_Bigram(string input, string lastWord)
    {
        var mock = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);
        var result = predictionEngine.predict(input);
        mock.Verify(p => p.predictUsingBigram(lastWord), Times.Once());
    }
}
 
