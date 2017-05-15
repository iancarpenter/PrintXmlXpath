using System;
using System.Text;
using System.Xml;
using System.IO;

namespace PrintXmlXpath
{
    public class Utils
    {
        /// <summary>
        /// for the supplied path return files that have a .xml extension
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] getFiles(string path)
        {
            string[] files = Directory.GetFiles(path, "*.xml");

            return files;
        }

        /// <summary>
        /// Answer provided by Jon Skeet 
        /// http://stackoverflow.com/a/241291/55640
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string FindXPath(XmlNode node)
        {
            StringBuilder builder = new StringBuilder();

            while (node != null)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute)node).OwnerElement;
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement)node);
                        builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        throw new ArgumentException("Only elements and attributes are supported");
                }
            }
            throw new ArgumentException("Node was not in a document");
        }

        /// <summary>
        /// http://stackoverflow.com/a/241291/55640
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int FindElementIndex(XmlElement element)
        {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument)
            {
                return 1;
            }
            XmlElement parent = (XmlElement)parentNode;
            int index = 1;
            foreach (XmlNode candidate in parent.ChildNodes)
            {
                if (candidate is XmlElement && candidate.Name == element.Name)
                {
                    if (candidate == element)
                    {
                        return index;
                    }
                    index++;
                }
            }
            throw new ArgumentException("Couldn't find element within parent");
        }
    }
}
