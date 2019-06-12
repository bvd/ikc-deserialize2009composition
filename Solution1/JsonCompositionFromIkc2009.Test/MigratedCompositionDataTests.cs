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
    public class MigratedCompositionDataTests

    {
        [TestMethod]
        public void Schema_Should_DeserializeWithoutErrors()
        {
            var t = Translator;
            Assert.AreEqual("1", "1");
        }

        [TestMethod]
        public void Translator_Should_ContainCompositionEvents()
        {
            Assert.AreEqual(Translator.CompositionEvents.Count, 89);
            Assert.AreEqual(Translator.CompositionEvents.Where(x => x is IComposition).Count(), 89);
            Assert.AreEqual(Translator.CompositionEvents.Where(x => x is ClearCompositionEvent).Count(), 1);
            Assert.AreEqual(Translator.CompositionEvents.Where(x => x is CompositionCreated).Count(), 1);
        }

        [TestMethod]
        public void TranslatorFirstCompositionEvent_Should_ContainCompositionCreatedEvent()
        {

            var evt = Translator.CompositionEvents.ElementAt(1);
            var createdEvent = evt as CompositionCreated;

            Assert.IsNotNull(createdEvent);
            Assert.AreEqual(createdEvent.Id, "38118");
            Assert.AreEqual(createdEvent.Name, "Tour de France");
            Assert.AreEqual(createdEvent.Time, 1442769290);
            Assert.AreEqual(createdEvent.User, 132101);
            Assert.AreEqual(createdEvent.UserName, "ikc_anon");
            Assert.AreEqual(createdEvent.Environment, "52");
            Assert.AreEqual(createdEvent.Scroll, "17");
            Assert.AreEqual(createdEvent.Conf, "52-17");
        }

        [TestMethod]
        public void TranslatorCompositionEvents_Should_ContainCorrectData()
        {
            var evts = Translator.CompositionEvents.Where(e => e is EventAddedToTrack).Select(e => e as EventAddedToTrack).Where(x => x.Track == 4).Select(x => x);

            Assert.AreEqual(evts.Count(), 12);
            Assert.AreEqual(evts.ElementAt(7).Start, 4167451);
            Assert.AreEqual(evts.ElementAt(10).End, 5688899);
            Assert.AreEqual(evts.ElementAt(6).SourceId, 1528);
            Assert.AreEqual(evts.ElementAt(0).Offset, 0);
            Assert.AreEqual(evts.ElementAt(9).Index, 9);
            Assert.AreEqual(evts.ElementAt(9).Total, 516096);
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
