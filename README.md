# PrintXmlXpath
A utility to print out the Xpath of a item of interest within an XML document. The default behaviour is to print the location of elements that have a text node greater than 20 characters.

e.g. given the following xml

```xml
<bookshop>
  <book>
    <title>Microsoft Visual C# Step by Step</title>
  </book>
</bookshop>
```
The utility will print: 

```
C:\Downloads\1.xml
/bookshop[1]/book[1]/title[1]
Microsoft Visual C# Step by Step
```

The first line displays the full path and file name of the xml file, the second line displays the XPath to the element of interest and the last 
line is the text of the xml element.
