using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using JsonCompositionFromIkc2009.Events;
using JsonCompositionFromIkc2009.Events.Composition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JsonCompositionFromIkc2009.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Deserialization()
        {
            string filepath = "./sample/rawdata.txt";
            string text = System.IO.File.ReadAllText(filepath);

            var deserialized = JsonConvert.DeserializeObject<Rootobject>(text);

            XmlSerializer serializer = new XmlSerializer(typeof(Xml2CSharp.Composition));
            StringReader reader = new StringReader(deserialized.composition.content);
            var compositionContent = (Xml2CSharp.Composition)serializer.Deserialize(reader);
            reader.Close();

            Assert.AreEqual("helloa", "helloa");
        }

        [TestMethod]
        public void CompositionTranslation()
        {
            string filepath = "./sample/rawdata.txt";
            string text = System.IO.File.ReadAllText(filepath);

            var deserialized = JsonConvert.DeserializeObject<Rootobject>(text);

            XmlSerializer serializer = new XmlSerializer(typeof(Xml2CSharp.Composition));
            StringReader reader = new StringReader(deserialized.composition.content);
            var compositionContent = (Xml2CSharp.Composition)serializer.Deserialize(reader);
            reader.Close();

            var translator = new IkcomponeerData2009ToEventsTranslator();
            translator.Translate(deserialized);
            translator.TranslateComposition(compositionContent);

            Assert.AreEqual(translator.CompositionEvents.Count, 89);
            Assert.AreEqual(translator.CompositionEvents.Where(x => x is IComposition).Count(), 89);
            Assert.AreEqual(translator.CompositionEvents.Where(x => x is ClearCompositionEvent).Count(), 1);
            Assert.AreEqual(translator.CompositionEvents.Where(x => x is CompositionCreated).Count(), 1);
        }
    }
}
