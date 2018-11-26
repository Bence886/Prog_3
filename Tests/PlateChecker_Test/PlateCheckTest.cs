using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using PlateChecker;
namespace PlateChecker_Test
{
    [TestFixture]
    public class PlateCheckTest
    {
        PlateCheck pc;

        [OneTimeSetUp]
        public void Setup()
        {
            pc = new PlateCheck();
        }

        [Test]
        public void NullInput_ThrowsException()
        {
            Assert.That(()=>pc.Check(null), Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("plate"));
        }

        [TestCase("AAA-000")]
        public void CorrectInputLength_NotThrowsException(string input)
        {
            Assert.That(() => pc.Check(input), Throws.Nothing);
        }

        [TestCase("012345678")]
        [TestCase("01")]
        public void IncorrectInputLength_ThrowsException(string input)
        {
            Assert.That(() => pc.Check(input), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void EmptyString_ThrowsException()
        {
            Assert.That(() => pc.Check(string.Empty), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase("AAA-000")]
        public void CorrectSeparaterLocationTest(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.True);
        }

        [TestCase("AA-A000")]
        [TestCase("AAA0-00")]
        public void IncorrectSeparaterLocationTest(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.False);
        }

        [TestCase("AAA-000")]
        public void CorrectLetterCheck(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.True);
        }


        [TestCase("0AA-000")]
        [TestCase("A0A-000")]
        [TestCase("AA0-000")]
        [TestCase("A%A-000")]
        public void IncorrectLetterCheck(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.False);
        }

        [TestCase("AAA-000")]
        public void CorrectNumberCheck(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.True);
        }


        [TestCase("AAA-A00")]
        [TestCase("AAA-0A0")]
        [TestCase("AAA-00A")]
        [TestCase("AAA-0%0")]
        public void IncorrectNumberCheck(string input)
        {
            bool check = pc.Check(input);

            Assert.That(check, Is.False);
        }
    }
}
