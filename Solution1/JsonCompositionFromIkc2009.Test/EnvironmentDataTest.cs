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
    public class EnvironmentDataTest
    {

        private string Sample = "6901.txt";

        [TestMethod]
        public void TranslatorEnvironment_Should_HaveCorrectValues()
        {
            var t = Translator("6901.txt");
            var m = t.EnvironmentEvents.Single(x => x is MusicSetCreated) as MusicSetCreated;
            Assert.AreEqual(m.id, "21");
            Assert.AreEqual(m.background, "http://ikcomponeer.nl/data/clients/3/none");
            Assert.AreEqual(m.description, "Componeren is klanken maken.<br/>Kies twee, drie of alle instrumenten en maak je eigen klank!<br/>\nMaak vervolgens een muziekstuk met een begin, midden en einde.");
            Assert.AreEqual(m.name, "Mozart Blaaskwintet");
            Assert.AreEqual(m.type, "template");
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldHaveCorrectId()
        {
            var t = Translator("9944.json");
            MusicPartCreated musicPartCreated63 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "63") as MusicPartCreated;
            Assert.AreEqual("Strijkers", musicPartCreated63.name);
            MusicPartCreated musicPartCreated64 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "64") as MusicPartCreated;
            Assert.AreEqual("Blazers", musicPartCreated64.name);
            MusicPartCreated musicPartCreated65 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "65") as MusicPartCreated;
            Assert.AreEqual("Piano", musicPartCreated65.name);
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldHaveCorrectMarginZero()
        {
            var t = Translator("9944.json");
            MusicPartCreated musicPartCreated63 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "63") as MusicPartCreated;
            Assert.AreEqual(0, musicPartCreated63.marginX);
            Assert.AreEqual(0, musicPartCreated63.marginY);
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldHaveCorrectMargin_WhenNumberIsPositive()
        {
            var t = Translator("6033.json");
            MusicPartCreated musicPartCreated29 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "29") as MusicPartCreated;
            Assert.AreEqual(2, musicPartCreated29.marginX);
            Assert.AreEqual(2, musicPartCreated29.marginY);
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldHaveCorrectName()
        {
            var t = Translator("9944.json");
            MusicPartCreated musicPartCreated63 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "63") as MusicPartCreated;
            Assert.AreEqual("Strijkers", musicPartCreated63.name);
            MusicPartCreated musicPartCreated64 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "64") as MusicPartCreated;
            Assert.AreEqual("Blazers", musicPartCreated64.name);
            MusicPartCreated musicPartCreated65 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "65") as MusicPartCreated;
            Assert.AreEqual("Piano", musicPartCreated65.name);
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldHaveCorrectWidth()
        {
            var t = Translator("9944.json");
            MusicPartCreated musicPartCreated63 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "63") as MusicPartCreated;
            Assert.AreEqual(320, musicPartCreated63.width);
        }

        [TestMethod]
        public void TranslatorEnvironment_Parts_ShouldBeCreatedInTheRightOrder()
        {
            var t = Translator("9944.json");
            MusicPartCreated musicPartCreated63 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "63") as MusicPartCreated;
            MusicPartCreated musicPartCreated64 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "64") as MusicPartCreated;
            MusicPartCreated musicPartCreated65 = t.EnvironmentEvents.Single(x => x is MusicPartCreated && (x as MusicPartCreated).id == "65") as MusicPartCreated;

            var indexOf63 = t.EnvironmentEvents.IndexOf(musicPartCreated63);
            var indexOf64 = t.EnvironmentEvents.IndexOf(musicPartCreated64);
            var indexOf65 = t.EnvironmentEvents.IndexOf(musicPartCreated65);

            Assert.IsTrue(indexOf64 > indexOf65);
            Assert.IsTrue(indexOf63 > indexOf64);
        }

        [TestMethod]
        public void TranslatorEnvironment_Part_ShouldMaintainEmptyStringAsName()
        {
            var t = Translator("56574.json");
            MusicPartCreated musicPartCreated = t.EnvironmentEvents.Single(x => x is MusicPartCreated) as MusicPartCreated;
            Assert.AreEqual("", musicPartCreated.name);
        }
        
        [TestMethod]
        public void TranslatorEnvironment_Clip_ShouldHaveCorrectData()
        {
            var t = Translator("9944.json");
            var clip = t.EnvironmentEvents.Single(x => x is MusicClipCreated && (x as MusicClipCreated).id == "1016") as MusicClipCreated;
            Assert.AreEqual("2521strijkers", clip.name);
            Assert.AreEqual("E5", clip.tag);
            Assert.AreEqual(0, clip.entrypoint);
            Assert.AreEqual(7164, clip.exitpoint);
            Assert.AreEqual("1016", clip.id);
            Assert.AreEqual("images/clip_icons/iconen-viool.svg", clip.icon);
            Assert.IsNull(clip.ficon);
            Assert.IsNull(clip.ficonroll);
            Assert.AreEqual("#91000D", clip.color);
            Assert.IsNull(clip.iconAdjustWidth);
            Assert.IsNull(clip.iconAdjustHeight);
        }

        [TestMethod]
        public void TranslatorEnvironment_Clip_ShouldMaintainPosition()
        {
            var t = Translator("9944.json");
            var clip1039 = t.EnvironmentEvents.Single(x => x is MusicClipCreated && (x as MusicClipCreated).id == "1039") as MusicClipCreated;
            var clip1038 = t.EnvironmentEvents.Single(x => x is MusicClipCreated && (x as MusicClipCreated).id == "1038") as MusicClipCreated;
            var clip1037 = t.EnvironmentEvents.Single(x => x is MusicClipCreated && (x as MusicClipCreated).id == "1037") as MusicClipCreated;
            var clip1039index = t.EnvironmentEvents.IndexOf(clip1039);//16
            var clip1038index = t.EnvironmentEvents.IndexOf(clip1038);//2
            var clip1037index = t.EnvironmentEvents.IndexOf(clip1037);//23
            Assert.IsTrue(clip1039index > clip1038index);
            Assert.IsTrue(clip1037index > clip1039index);
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
