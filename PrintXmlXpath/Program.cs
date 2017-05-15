using System;
using System.Xml;

namespace PrintXmlXpath
{
    /// <summary>
    /// Utility to print out the XPath location of interest
    /// Default use case is to find elements that have a text node that exceeds
    /// 20 characters.
    /// Requires one command line parameter; the path to look for the xml document(s)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {            
            const string theXpath = "//*/text()[string-length() > 20]/..";

            Utils utils = new Utils();

            string[] files = utils.getFiles(args[0]);

            foreach (string file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlNode node = doc.SelectSingleNode(theXpath);

                // found something so print out the filename, xpath 
                // and text 
                if(node != null)
                {
                    Console.WriteLine(file);
                    Console.WriteLine(utils.FindXPath(node));
                    Console.WriteLine(node.InnerText);
                    Console.WriteLine();
                }                

            }
            Console.Read();
        }               
    }
}