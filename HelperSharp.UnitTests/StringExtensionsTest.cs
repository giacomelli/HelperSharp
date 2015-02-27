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
            Assert.AreEqual(1, "HelperSharp".CountWords());
            Assert.AreEqual(2, "HelperSharp is ".CountWords());
            Assert.AreEqual(3, "HelperSharp is a  ".CountWords());
            Assert.AreEqual(4, "HelperSharp is a Extension ".CountWords());
            Assert.AreEqual(5, "HelperSharp is a Extension Methods ".CountWords());
            Assert.AreEqual(6, "HelperSharp is a Extension Methods Collection".CountWords());
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

		#if !PCL
        [Test()]
        public void EscapeAccentsToHexTest()
        {
            Assert.AreEqual("Sistema de Informa%E7%F5es", "Sistema de Informações".EscapeAccentsToHex());
        }
		#endif

        [Test()]
        public void EscapeAccentsToHtmlEntitiesTest()
        {
            Assert.AreEqual("Sistema de Informa&#231;&#245;es", "Sistema de Informações".EscapeAccentsToHtmlEntities());
        }

        [Test()]
        public void GetWordFromIndexTest()
        {
            string source = "HelperSharp is a Extension Methods Collection";

            Assert.AreEqual("HelperSharp", source.GetWordFromIndex(0));
            Assert.AreEqual("HelperSharp", source.GetWordFromIndex(3));
            Assert.AreEqual("HelperSharp", source.GetWordFromIndex(5));

            Assert.AreEqual(" ", source.GetWordFromIndex(11));

            Assert.AreEqual("is", source.GetWordFromIndex(12));
            Assert.AreEqual("is", source.GetWordFromIndex(13));

            Assert.AreEqual(" ", source.GetWordFromIndex(14));

            Assert.AreEqual("a", source.GetWordFromIndex(15));

            Assert.AreEqual(" ", source.GetWordFromIndex(16));

            Assert.AreEqual("Extension", source.GetWordFromIndex(17));
            Assert.AreEqual("Extension", source.GetWordFromIndex(21));
            Assert.AreEqual("Extension", source.GetWordFromIndex(25));

            Assert.AreEqual(" ", source.GetWordFromIndex(26));

            Assert.AreEqual("Methods", source.GetWordFromIndex(27));
            Assert.AreEqual("Methods", source.GetWordFromIndex(30));
            Assert.AreEqual("Methods", source.GetWordFromIndex(33));

            Assert.AreEqual(" ", source.GetWordFromIndex(34));

            Assert.AreEqual("Collection", source.GetWordFromIndex(35));
            Assert.AreEqual("Collection", source.GetWordFromIndex(40));
            Assert.AreEqual("Collection", source.GetWordFromIndex(44));
        }

		#if !PCL
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
		#endif

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
            Assert.AreEqual(null, StringExtensions.InsertUnderscoreBeforeUppercase(null));
            Assert.AreEqual("", StringExtensions.InsertUnderscoreBeforeUppercase(""));
        }

        [Test()]
        public void InsertUnderscoreBeforeUpperCase_String_StringWithUpperCases()
        {
            Assert.AreEqual("One_Two_Three", StringExtensions.InsertUnderscoreBeforeUppercase("OneTwoThree"));
            Assert.AreEqual("One_Two_Three", StringExtensions.InsertUnderscoreBeforeUppercase("One_Two_Three"));
        }

        [Test()]
        public void With_SourceAndArgs_Formatted()
        {
            Assert.AreEqual("A1b2", "A{0}b{1}".With(1, 2));
        }

        [Test]
        public void Capitalize_AllUpperCase_Capitalized()
        {
            Assert.AreEqual("Teste da Souza Silva", "TESTE DA SOUZA SILVA".Capitalize());
            Assert.AreEqual("Teste Da Souza Silva", "TESTE DA SOUZA SILVA".Capitalize(2));
            Assert.AreEqual("teste da souza silva", "TESTE DA SOUZA SILVA".Capitalize(6));
        }

        [Test]
        public void Capitalize_AllLowerCase_Capitalized()
        {
            Assert.AreEqual("Teste da Souza Silva", "teste da souza silva".Capitalize());
            Assert.AreEqual("Id", "id".Capitalize(0));
        }

        [Test]
        public void Capitalize_DiffCases_Capitalized()
        {
            Assert.AreEqual("Teste da Souza Silva", "TesTe DA sOUZA sILva".Capitalize());
        }

        [Test]
        public void ContainsIgnoreCase_SubstringExists_True()
        {
            Assert.IsTrue("Teste da Souza Silva".ContainsIgnoreCase("TESTE"));
            Assert.IsTrue("Teste da Souza Silva".ContainsIgnoreCase("da souza"));
            Assert.IsTrue("Teste da Souza Silva".ContainsIgnoreCase("silva"));
        }

        [Test]
        public void ContainsIgnoreCase_SubstringDoesNotExists_False()
        {
            Assert.IsFalse("Teste da Souza Silva".ContainsIgnoreCase("tst"));
            Assert.IsFalse("Teste da Souza Silva".ContainsIgnoreCase("DAS"));
        }
    }
}