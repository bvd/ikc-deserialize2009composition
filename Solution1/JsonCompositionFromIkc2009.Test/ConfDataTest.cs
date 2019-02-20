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
        public void TranslatorConf_ShouldContainTopLeftButtonText()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Single(x => x is ButtonTextConfigured && (x as ButtonTextConfigured).ButtonPosition == ButtonPosition.Left) as ButtonTextConfigured;
            Assert.AreEqual("MUZIEK LIJST", c.ButtonText);
        }

        [TestMethod]
        public void TranslatorConf_ShouldContainTopLeftButtonEmptyText()
        {
            var t = Translator("56574.json");
            var c = t.ProjectEvents.Single(x => x is ButtonTextConfigured && (x as ButtonTextConfigured).ButtonPosition == ButtonPosition.Left) as ButtonTextConfigured;
            Assert.AreEqual("", c.ButtonText);
        }

        [TestMethod]
        public void TranslatorConf_ButtonBehaviorConfiguredLeft_OpenSessionModule()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Single(x => x is ButtonBehaviorConfigured && (x as ButtonBehaviorConfigured).ButtonPosition == ButtonPosition.Left) as ButtonBehaviorConfigured;
            Assert.AreEqual(IkcNotification.OpenSessionModule, c.ButtonNote);
        }

        [TestMethod]
        public void TranslatorConf_ButtonBehaviorConfiguredLeft_PlayAudioTip()
        {
            var t = Translator("56574.json");
            var c = t.ProjectEvents.Single(x => x is ButtonBehaviorConfigured && (x as ButtonBehaviorConfigured).ButtonPosition == ButtonPosition.Left) as ButtonBehaviorConfigured;
            Assert.AreEqual(IkcNotification.PlayAudioTip, c.ButtonNote);
        }

        [TestMethod]
        public void TranslatorConf_ButtonBehaviorConfiguredLeft_PlayPause()
        {
            var t = Translator("33410.json");
            var c = t.ProjectEvents.Single(x => x is ButtonBehaviorConfigured && (x as ButtonBehaviorConfigured).ButtonPosition == ButtonPosition.Left) as ButtonBehaviorConfigured;
            Assert.AreEqual(IkcNotification.PlayPause, c.ButtonNote);
        }

        [TestMethod]
        public void Translator_Conf_ButtonModeConfiguredLeft_Button()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Single(x => x is ButtonModeConfigured && (x as ButtonModeConfigured).ButtonPosition == ButtonPosition.Left) as ButtonModeConfigured;
            Assert.AreEqual(ButtonMode.Button, c.ButtonMode);
        }

        [TestMethod]
        public void Translator_Conf_ButtonModeConfiguredLeft_Img()
        {
            var t = Translator("33410.json");
            var c = t.ProjectEvents.Single(x => x is ButtonModeConfigured && (x as ButtonModeConfigured).ButtonPosition == ButtonPosition.Left) as ButtonModeConfigured;
            Assert.AreEqual(ButtonMode.Img, c.ButtonMode);
        }

        [TestMethod]
        public void Translator_Conf_SaveButtonVisibility()
        {
            var t = Translator("15441.json");
            var c = t.ProjectEvents.Single(x => x is SaveButtonVisibilityConfigured) as SaveButtonVisibilityConfigured;
            Assert.IsTrue(c.Visible);
        }

        [TestMethod]
        public void Translator_Conf_SaveButtonVisibility_False()
        {
            var t = Translator("56692.json");
            var c = t.ProjectEvents.Single(x => x is SaveButtonVisibilityConfigured) as SaveButtonVisibilityConfigured;
            Assert.IsFalse(c.Visible);
        }

        [TestMethod]
        public void Translator_Conf_TemplateCompositionConfigured()
        {
            var t = Translator("56692.json");
            var c = t.ProjectEvents.Single(x => x is TemplateCompositionConfigured) as TemplateCompositionConfigured;
            Assert.AreEqual("6028", c.Id);
        }

        [TestMethod]
        public void Translator_Conf_LicenseTextConfigured()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Single(x => x is LicenseTextConfigured ) as LicenseTextConfigured;
            Assert.AreEqual("Gelicenseerd aan: <br/>Metropole Orkest<br/>", c.Text);
        }

        [TestMethod]
        public void Translator_Conf_MenuDisplayLeftHiddenNone()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Any(x => x is MenuDisplayHiddenLeft);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Translator_Conf_MenuDisplayRightHiddenNone()
        {
            var t = Translator("9944.json");
            var c = t.ProjectEvents.Any(x => x is MenuDisplayHiddenRight);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Translator_Conf_MenuDisplayLeftHidden()
        {
            var t = Translator("56692.json");
            var c = t.ProjectEvents.Any(x => x is MenuDisplayHiddenLeft);
            Assert.IsTrue(c);
        }

        [TestMethod]
        public void Translator_Conf_MenuDisplayRightHidden()
        {
            var t = Translator("43112.json");
            var c = t.ProjectEvents.Any(x => x is MenuDisplayHiddenRight);
            Assert.IsTrue(c);
        }


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
