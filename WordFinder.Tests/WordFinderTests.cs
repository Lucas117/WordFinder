using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WordFinder.Validation;

namespace Tests
{
    [TestFixture]
    public class WordFinderTests
    {
        private IWordFinderValidations wordFinderValidations;

        [SetUp]
        public void SetUp()
        {
            this.wordFinderValidations = new WordFinderValidations();
        }

        [Test]
        public void TestExistsWordVerticalyInMatrix()
        {
            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("HILL");

            var result = wordFinder.Find(streamWords);

            Assert.True(result.Contains("HILL"));
        }

        [Test]
        public void TestExistsWordHorizontalyInMatrix()
        {
            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAGAAH",
                "AHILLAAH",
                "BBFARAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("HILL");

            var result = wordFinder.Find(streamWords);

            Assert.True(result.Contains("HILL"));
        }

        [Test]
        public void TestNotExistsWordInMatrix()
        {
            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("TEST");

            var result = wordFinder.Find(streamWords);

            Assert.False(result.Contains("TEST"));
            Assert.True(result.Count() == 0);
        }

        [Test]
        public void TestExistsWordInMatrixAndMostRepeated()
        {
            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("HILL");
            streamWords.Add("HILL");
            streamWords.Add("FATA");

            var result = wordFinder.Find(streamWords);

            Assert.True(result.Contains("HILL"));
            Assert.True(result.First().Contains("HILL"));
        }

        [Test]
        public void TestExistsWordInMatrixAndNotMostRepeated()
        {
            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("HILL");
            streamWords.Add("HILL");
            streamWords.Add("FATA");

            var result = wordFinder.Find(streamWords);

            Assert.True(result.Contains("FATA"));
            Assert.False(result.First().Contains("FATA"));
        }

        [Test]
        public void TestTop10ExistsWordsInMatrixAndMostRepeated()
        {
            IEnumerable<string> matrix = new List<string>
            {   "ANAAALUK",
                "CAFATAEY",
                "MAFAHAZL",
                "EAFAIAEO",
                "ACALLAAH",
                "BBFALAAA",
                "AAFTIAAL",
                "AAMASSAO"
            };
            wordFinderValidations.ValidateMatrix(matrix);
            WordFinder.WordFinder wordFinder = new WordFinder.WordFinder(matrix);

            IList<string> streamWords = new List<string>();
            streamWords.Add("HILL");
            streamWords.Add("HILL");
            streamWords.Add("HILL");
            streamWords.Add("HILL");
            streamWords.Add("ANA");
            streamWords.Add("ANA");
            streamWords.Add("EZE");
            streamWords.Add("EZE");
            streamWords.Add("MASS");
            streamWords.Add("MASS");
            streamWords.Add("LUK");
            streamWords.Add("LUK");
            streamWords.Add("KYLO");
            streamWords.Add("KYLO");
            streamWords.Add("HALO");
            streamWords.Add("HALO");
            streamWords.Add("HALO");
            streamWords.Add("SSAO");
            streamWords.Add("SSAO");
            streamWords.Add("ACME");
            streamWords.Add("ACME");
            streamWords.Add("CALL");
            streamWords.Add("CALL");
            streamWords.Add("ABA");

            var result = wordFinder.Find(streamWords);
            
            List<string> list = new List<string>();
            list.Add("HILL");
            list.Add("ANA");
            list.Add("EZE");
            list.Add("MASS");
            list.Add("LUK");
            list.Add("KYLO");
            list.Add("HALO");
            list.Add("SSAO");
            list.Add("ACME");
            list.Add("CALL");

            Assert.True(result.First().Contains("HILL"));
            Assert.True(result.All(wordResult => list.Contains(wordResult)));
            Assert.False(result.Contains("ABA"));
        }

        [Test]
        public void TestMatrixExceedMaxSize()
        {
            IEnumerable<string> matrix = new List<string>
            {   "CKEPQSZNCQOGILVEMRAEXUQVQNCOPMJZQIILEBQOXUQVQNCOPMJZQIILEBQOXUQVQNCOPMJZQIILEBQO",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            Assert.Throws<Exception>(() => wordFinderValidations.ValidateMatrix(matrix));
           
        }

        [Test]
        public void TestMatrixHasDifferntRowsSize()
        {
            IEnumerable<string> matrix = new List<string>
            {   "CKEPQSZNCQO",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };
            Assert.Throws<Exception>(() => wordFinderValidations.ValidateMatrix(matrix));

        }
    }
}