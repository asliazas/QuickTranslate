using NUnit.Framework;
using QuickTranslate.Data.Repositories;

namespace QuickTranslate.Data.Tests
{
    [TestFixture]
    public class GoogleTranslateRepositoryTests
    {
        [Test]
        public void Should_get_translation()
        {
            // Arrange
            var googleTranslateRepository = new GoogleTranslateRepository();
            var to = "lt";
            var originalText = "The quick brown fox jumps over the lazy dog";

            // Act
            var translation = googleTranslateRepository.Translate(originalText, to);

            // Assert
            Assert.AreEqual(translation.From, "en");
            Assert.AreEqual(translation.To, to);
            Assert.AreEqual(translation.OriginalText, originalText);
            Assert.AreEqual(translation.TranslatedText, "Greita ruda lapė peršoka per tingų šunį");
        }
    }
}
