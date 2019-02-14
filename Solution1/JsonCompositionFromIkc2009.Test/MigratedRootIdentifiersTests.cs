using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using JsonCompositionFromIkc2009.Events;
using JsonCompositionFromIkc2009.Events.Composition;
using JsonCompositionFromIkc2009.Events.Config;
using JsonCompositionFromIkc2009.Events.MusicEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JsonCompositionFromIkc2009.Test
{
    [TestClass]
    public class MigratedRootIdentifiersTests
    {
        [TestMethod]
        public void Schema_Should_DeserializeWithoutErrors()
        {
            var t = Translator;
            Assert.AreEqual("1", "1");
        }

        [TestMethod]
        public void Translator_Should_HaveCorrectCompositionIdentifier()
        {
            Assert.AreEqual(DeserializedJson.composition.id, 38118);
        }

        [TestMethod]
        public void Translator_Should_HaveCorrectScrollIdentifier()
        {
            Assert.AreEqual(DeserializedJson.scrollitems_identifier, "17");
        }

        [TestMethod]
        public void Translator_Should_HaveCorrectEnvironmentIdentifier()
        {
            Assert.AreEqual(DeserializedJson.environment_identifier, "52");
        }

        [TestMethod]
        public void Translator_Should_HaveCorrectConfIdentifier()
        {
            Assert.AreEqual(DeserializedJson.conf_identifier, "52-17");
        }
        
        private IkcomponeerData2009ToEventsTranslator __translator;

        private IkcomponeerData2009ToEventsTranslator Translator
        {
            get
            {
                if(__translator == null)
                {
                    __translator = new IkcomponeerData2009ToEventsTranslator();
                    __translator.Translate(DeserializedJson);
                    __translator.TranslateComposition(CompositionContent);
                }
                return __translator;
            }
        }

        private Xml2CSharp.Composition __compositionContent;

        private Xml2CSharp.Composition CompositionContent
        {
            get
            {
                if(__compositionContent == null)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Xml2CSharp.Composition));
                    StringReader reader = new StringReader(DeserializedJson.composition.content);
                    __compositionContent = (Xml2CSharp.Composition)serializer.Deserialize(reader);
                    reader.Close();
                }
                return __compositionContent;
            }
        }

        private Rootobject __deserialized;

        private Rootobject DeserializedJson
        {
            get {
                if (__deserialized == null)
                {

                    string filepath = "./sample/rawdata.txt";
                    string text = System.IO.File.ReadAllText(filepath);

                    __deserialized = JsonConvert.DeserializeObject<Rootobject>(text);
                }
                return __deserialized;
            }
            
        }
    }
}
