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
    public class EssentialEnvironmentParametersMigrationTests
    {
        [TestMethod]
        public void Schema_Should_DeserializeWithoutErrors()
        {
            var t = Translator;
            Assert.AreEqual("1", "1");
        }

        [TestMethod]
        public void TranslatorEnvironmentMusicTime_Should_HaveCorrectValues()
        {
            var m = Translator.EnvironmentEvents.Single(x => x is MeasureDefined) as MeasureDefined;
            Assert.AreEqual(4, m.Denominator);
            Assert.AreEqual(4, m.Numerator);
            var t = Translator.EnvironmentEvents.Single(x => x is TempoDefined) as TempoDefined;
            Assert.AreEqual(160, t.BpmTempo);
        }

        [TestMethod]
        public void TranslatedTrackMeasurements_Should_HaveCorrectValue()
        {
            var m = Translator.ProjectEvents.Single(x => x is TrackHeightConfigured) as TrackHeightConfigured;
            Assert.AreEqual(35, m.TrackHeight);
            var q = Translator.ProjectEvents.Single(x => x is QuantizeGridChange) as QuantizeGridChange;
            Assert.AreEqual(4, q.Denominator);
            Assert.AreEqual(4, q.Numerator);
        }

        [TestMethod]
        public void TranslatedNumTrack_Should_HaveTheCorrectValue()
        {
            var t = Translator.ProjectEvents.Single(x => x is NumberOfTracksConfigured) as NumberOfTracksConfigured;
            Assert.AreEqual(6, t.NumberOfTracks);
        }

        [TestMethod]
        public void Translator_Should_TranslateZoomFactorCorrectly()
        {
            var z = Translator.ProjectEvents.Single(x => x is ZoomFactorChange) as ZoomFactorChange;
            Assert.AreEqual(88, z.Denominator);
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
