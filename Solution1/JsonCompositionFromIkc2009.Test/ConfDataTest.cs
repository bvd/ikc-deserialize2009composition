using JsonCompositionFromIkc2009.Events;
using JsonCompositionFromIkc2009.Events.Config;
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
    public class ConfDataTest
    {
        [TestMethod]
        public void TranslatorEnvironment_Conf_ShouldContainTopLeftButtonText()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Single(x => x is ButtonTextConfigured && (x as ButtonTextConfigured).ButtonPosition == ButtonPosition.Left) as ButtonTextConfigured;
            Assert.AreEqual("MUZIEK LIJST", c.ButtonText);
        }

        [TestMethod]
        public void TranslatorEnvironment_Conf_ShouldContainTopLeftButtonEmptyText()
        {
            var t = Translator("56574.json");
            var c = t.ProjectEvents.Single(x => x is ButtonTextConfigured && (x as ButtonTextConfigured).ButtonPosition == ButtonPosition.Left) as ButtonTextConfigured;
            Assert.AreEqual("", c.ButtonText);
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
