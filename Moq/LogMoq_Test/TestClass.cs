using LogMocker;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMoq_Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            Mock<ILogger> mockedLog = new Mock<ILogger>();
            mockedLog.Setup(o => o.WriteLog(It.IsAny<LogLevel>(), It.IsAny<string>()));
            SomeLogic l = new SomeLogic(mockedLog.Object);

            l.ComplicatedLogic("TestText");

            mockedLog.Verify(o => o.WriteLog(LogLevel.Debug, "Processing: TestText"), Times.Once);
            mockedLog.Verify(o => o.WriteLog(It.IsAny<LogLevel>(), It.IsAny<string>()), Times.Exactly(3));
            mockedLog.Verify(o => o.WriteLog(LogLevel.Exception, It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void NullLogTest()
        {
            Mock<ILogger> mockedLog = new Mock<ILogger>();
            mockedLog.Setup(o => o.WriteLog(It.IsAny<LogLevel>(), It.IsAny<string>()));
            SomeLogic l = new SomeLogic(mockedLog.Object);

            l.ComplicatedLogic(null);

            mockedLog.Verify(o => o.WriteLog(LogLevel.Exception, It.IsAny<string>()), Times.Once);
        }
    }
}
