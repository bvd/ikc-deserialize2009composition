using JsonCompositionFromIkc2009.Events;
using JsonCompositionFromIkc2009.Events.Scroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JsonCompositionFromIkc2009.Test
{
    [TestClass]
    public class ScrollDataTest
    {
        [TestMethod]
        public void TranslatorEnvironment_Scroll_ShouldHaveCorrectNumberOfItems()
        {
            var t = Translator("6901.txt");
            Assert.AreEqual(10, t.ScrollEvents.Count);
        }

        [TestMethod]
        public void TranslatorEnvironment_Scroll_ShouldHaveCorrectItemsInCorrectOrder()
        {
            var t = Translator("6901.txt");
            var first = t.ScrollEvents.ElementAt(0) as ScrollItemAdded;
            var second = t.ScrollEvents.ElementAt(1) as ScrollItemAdded;
            var fifth = t.ScrollEvents.ElementAt(4) as ScrollItemAdded;
            var eighth = t.ScrollEvents.ElementAt(7) as ScrollItemAdded;
            var tenth = t.ScrollEvents.ElementAt(9) as ScrollItemAdded;
            Assert.AreEqual("27129", first.Id);
            Assert.AreEqual("6028", second.Id);
            Assert.AreEqual("29508", fifth.Id);
            Assert.AreEqual("6901", eighth.Id);
            Assert.AreEqual("5971", tenth.Id);
        }

        private IkcomponeerData2009ToEventsTranslator __translator;

        private IkcomponeerData2009ToEventsTranslator Translator(string sampleFile)
        {
            var t = new IkcomponeerData2009ToEventsTranslator();
            var r = DeserializedJson(sampleFile);
            try
            {
                t.Translate(r);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
            try
            {
                t.TranslateComposition(CompositionContent(r));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
            return t;
        }

        private Xml2CSharp.Composition __compositionContent;

        private Xml2CSharp.Composition CompositionContent(Rootobject r)
        {

            Xml2CSharp.Composition c;
            XmlSerializer serializer = new XmlSerializer(typeof(Xml2CSharp.Composition));
            StringReader reader = new StringReader(r.composition.content);

            c = string.IsNullOrEmpty(r.composition.content)
                ? new Xml2CSharp.Composition { Track = new System.Collections.Generic.List<Xml2CSharp.Track>() }
                : (Xml2CSharp.Composition)serializer.Deserialize(reader);

            reader.Close();

            return c;

        }

        private Rootobject __deserialized;

        private Rootobject DeserializedJson(string sampleFile)
        {

            Rootobject r;
            string filepath = "./sample/" + sampleFile;
            try
            {
                string text = System.IO.File.ReadAllText(filepath);
                r = JsonConvert.DeserializeObject<Rootobject>(text);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }

            return r;

        }
    }
}
