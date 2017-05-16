using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using PrintXmlXpath;

namespace PrintXmlXpathTests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void getFilesTest()
        {
            // arrange
            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml(@"<bookshop>
                            <book>
                              <title>Microsoft Visual C# Step by Step</title>
                            </book>
                          </bookshop>");

            const string savedFileName = "a.xml";

            doc.Save(savedFileName);

            // act
            Utils utils = new Utils();

            string[] files = utils.getFiles(Environment.CurrentDirectory);

            string file = files[0];

            string loadedFileName = file.Substring(file.IndexOf(savedFileName), 5);

            // assert
            Assert.AreEqual(loadedFileName, savedFileName, "File not found");

            // teardown
            File.Delete(savedFileName);
        }
    }
}
