using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HelperSharp.UnitTests
{
    [TestFixture()]
    public class StringExtensionsTest
    {
        [Test()]
        public void CountWordTest()
        {
            Assert.AreEqual(0, "".CountWords());
            Assert.AreEqual(0, " ".CountWords());
            Assert.AreEqual(1, "NTrick".CountWords());
            Assert.AreEqual(2, "NTrick is ".CountWords());
            Assert.AreEqual(3, "NTrick is a  ".CountWords());
            Assert.AreEqual(4, "NTrick is a Extension ".CountWords());
            Assert.AreEqual(5, "NTrick is a Extension Methods ".CountWords());
            Assert.AreEqual(6,  "NTrick is a Extension Methods Collection".CountWords());
        }

        [Test()]
        public void EndsWithPunctuationTest()
        {
            Assert.IsFalse("".EndsWithPunctuation());
            Assert.IsFalse(" ".EndsWithPunctuation());
            Assert.IsFalse(".N.T.r.i.c.k.s".EndsWithPunctuation());
            Assert.IsTrue("HelperSharp.".EndsWithPunctuation());
            Assert.IsTrue("HelperSharp!".EndsWithPunctuation());
            Assert.IsTrue("HelperSharp?".EndsWithPunctuation());
            Assert.IsTrue("HelperSharp;".EndsWithPunctuation());
            Assert.IsTrue("HelperSharp,".EndsWithPunctuation());
        }

        [Test()]
        public void EscapeAccentsToHexTest()
        {
            Assert.AreEqual("Sistema de Informa%E7%F5es", "Sistema de Informações".EscapeAccentsToHex());
        }

        [Test()]
        public void EscapeAccentsToHtmlEntitiesTest()
        {
            Assert.AreEqual("Sistema de Informa&#231;&#245;es", "Sistema de Informações".EscapeAccentsToHtmlEntities());
        }

        [Test()]
        public void GetWordFromIndexTest()
        {
            string source = "NTrick is a Extension Methods Collection";

            Assert.AreEqual("NTrick", source.GetWordFromIndex(0));
            Assert.AreEqual("NTrick", source.GetWordFromIndex(3));
            Assert.AreEqual("NTrick", source.GetWordFromIndex(5));

            Assert.AreEqual(" ", source.GetWordFromIndex(6));

            Assert.AreEqual("is", source.GetWordFromIndex(7));
            Assert.AreEqual("is", source.GetWordFromIndex(8));

            Assert.AreEqual(" ", source.GetWordFromIndex(9));

            Assert.AreEqual("a", source.GetWordFromIndex(10));

            Assert.AreEqual(" ", source.GetWordFromIndex(11));

            Assert.AreEqual("Extension", source.GetWordFromIndex(12));
            Assert.AreEqual("Extension", source.GetWordFromIndex(16));
            Assert.AreEqual("Extension", source.GetWordFromIndex(20));

            Assert.AreEqual(" ", source.GetWordFromIndex(21));

            Assert.AreEqual("Methods", source.GetWordFromIndex(22));
            Assert.AreEqual("Methods", source.GetWordFromIndex(25));
            Assert.AreEqual("Methods", source.GetWordFromIndex(28));

            Assert.AreEqual(" ", source.GetWordFromIndex(29));

            Assert.AreEqual("Collection", source.GetWordFromIndex(30));
            Assert.AreEqual("Collection", source.GetWordFromIndex(35));
            Assert.AreEqual("Collection", source.GetWordFromIndex(39));
        }

        [Test()]
        public void HasAccentTest()
        {
            Assert.IsFalse("Sistema de Informacoes".HasAccent());
            Assert.IsTrue("Sistema de Informações".HasAccent());
            Assert.IsFalse("a".HasAccent());
            Assert.IsTrue("á".HasAccent());
            Assert.IsTrue("aaÁ".HasAccent());
            Assert.IsTrue("é".HasAccent());
            Assert.IsTrue("â".HasAccent());
            Assert.IsTrue("à".HasAccent());
        }

        [Test()]
        public void RemoveAccentsTest()
        {
			Assert.AreEqual("aaaaaeeeeiiooooouuuuncAAAAAEEEEIIOOOOOUUUUNC", "áàãâäéèêëíìóòõôöúùûüñçÁÀÃÂÄÉÈÊËÍÌÓÒÕÔÖÚÙÛÜÑÇ".RemoveAccents());
            Assert.AreEqual("Ideia ou ideia?", "Idéia ou ideia?".RemoveAccents());
            Assert.AreEqual("Para ou para?", "Pára ou para?".RemoveAccents());
        }

        [Test()]
        public void RemoveFromBordersTest()
        {
            Assert.AreEqual(" meio ", "Borda meio Borda".RemoveFromBorders("borda"));
            Assert.AreEqual("Borda meio Borda", "Borda meio Borda".RemoveFromBorders("meio"));

            Assert.AreEqual(" meio ", "2 meio 1".RemoveFromBorders('1', '2'));
            Assert.AreEqual("2 meio 1", "2 meio 1".RemoveFromBorders('m', 'o'));
        }

        [Test()]
        public void RemoveNonAlphanumericTest()
        {
			Assert.AreEqual("1234567890qwertyuiopasdfghjklzxcvbnmáéíóú", "`1234567890-=qwertyuiop[]\\asdfghjkl;\'zxcvbnm,./áéíóú".RemoveNonAlphanumeric());
        }

        [Test()]
        public void RemoveNonNumericTest()
        {
            Assert.AreEqual("1234567890", "`1234567890-=qwertyuiop[]\\asdfghjkl;\'zxcvbnm,./".RemoveNonNumeric());
        }

        [Test()]
        public void RemovePunctuationsTest()
        {
            Assert.AreEqual("`1234567890-=qwertyuiop\\asdfghjklzxcvbnm/", "`1234567890-=q!wer?tyuiop,[]\\asdfghjkl;\'zxcvbnm,./".RemovePunctuations());
        }

		[Test()]
		public void InsertUnderscoreBeforeUpperCase_NullOrEmpty_ReturnsInput()
		{
			Assert.AreEqual(null, StringExtensions.InsertUnderscoreBeforeUpperCase(null));
			Assert.AreEqual("", StringExtensions.InsertUnderscoreBeforeUpperCase(""));
		}

		[Test()]
		public void InsertUnderscoreBeforeUpperCase_String_StringWithUpperCases()
		{
			Assert.AreEqual("One_Two_Three", StringExtensions.InsertUnderscoreBeforeUpperCase("OneTwoThree"));
			Assert.AreEqual("One_Two_Three", StringExtensions.InsertUnderscoreBeforeUpperCase("One_Two_Three"));
		}

		[Test()]
		public void With_SourceAndArgs_Formatted()
		{
			Assert.AreEqual ("A1b2", "A{0}b{1}".With (1, 2));
		}
    }
}