using NUnit.Framework;

namespace TemplateEngine.Tests
{
    public class Tests
    {
        private TemplateEngine templateEngine;

        [SetUp]
        public void Setup()
        {
            templateEngine = new TemplateEngine();
        }

        [TestCase("Pavi", "Hello Pavi")]
        [TestCase("Healthineer", "Hello Healthineer")]
        
        public void ShouldWorkForOneVar(string value, string expected)
        {
            templateEngine.SetTemplate("Hello {name}");
            templateEngine.SetVariable("name", value);
            string result = templateEngine.Evaluate();

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Pavi", "N", "Hello Pavi N")]
        [TestCase("Healthineer's", "Employee", "Hello Healthineer's Employee")]
        public void ShouldWorkForTwoVars(string firstValue, string secondValue, string expected)
        {
            templateEngine.SetTemplate("Hello {firstname} {lastname}");
            templateEngine.SetVariable("firstname", firstValue);
            templateEngine.SetVariable("lastname", secondValue);
            string result = templateEngine.Evaluate();

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("A", "B", "C", "Hello A B C")]
        [TestCase("X", "Y", "Z", "Hello X Y Z")]
        [TestCase("One", "Two", "Three", "Hello One Two Three")]
        public void ShouldWorkForMultipleVars(string var1, string var2, string var3, string expected)
        {
            templateEngine.SetTemplate("Hello {var1} {var2} {var3}");
            templateEngine.SetVariable("var1", var1);
            templateEngine.SetVariable("var2", var2);
            templateEngine.SetVariable("var3", var3);
            string result = templateEngine.Evaluate();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
