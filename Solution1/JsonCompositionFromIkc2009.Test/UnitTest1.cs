using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JsonCompositionFromIkc2009.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filepath = "./sample/rawdata.txt";
            string text = System.IO.File.ReadAllText(filepath);

            var deserialized = JsonConvert.DeserializeObject<Rootobject>(text);

            XmlSerializer serializer = new XmlSerializer(typeof(Xml2CSharp.Composition));
            StringReader reader = new StringReader(deserialized.composition.content);
            var compositionContent = (Xml2CSharp.Composition)serializer.Deserialize(reader);
            reader.Close();

            Assert.AreEqual("hello", "hello");
        }
    }
}
