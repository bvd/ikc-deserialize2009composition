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
        public void TranslatorConf_ShouldContainTopRightButtonEmptyText()
        {
            var t = Translator("15441.json");
            var c = t.ProjectEvents.Single(x => x is ButtonTextConfigured && (x as ButtonTextConfigured).ButtonPosition == ButtonPosition.Right) as ButtonTextConfigured;
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
        public void TranslatorConf_ButtonBehaviorConfiguredRight_ClearComposition()
        {
            var t = Translator("15441.json");
            var c = t.ProjectEvents.Single(x => x is ButtonBehaviorConfigured && (x as ButtonBehaviorConfigured).ButtonPosition == ButtonPosition.Right) as ButtonBehaviorConfigured;
            Assert.AreEqual(IkcNotification.ClearComposition, c.ButtonNote);
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
        public void Translator_Conf_ButtonModeConfiguredRight_Img()
        {
            var t = Translator("15441.json");
            var c = t.ProjectEvents.Single(x => x is ButtonModeConfigured && (x as ButtonModeConfigured).ButtonPosition == ButtonPosition.Right) as ButtonModeConfigured;
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

        [TestMethod]
        public void Translator_Conf_SloganConfigured_None()
        {
            var t = Translator("33410.json");
            var c = t.ProjectEvents.Any(x => x is SloganConfigured);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Translator_Conf_SloganConfigured()
        {
            var t = Translator("16749.json");
            var c = t.ProjectEvents.Single(x => x is SloganConfigured) as SloganConfigured;
            var txt = "Je gaat je eigen nummer maken. Kies een beat en sleep de blokjes naar boven.<br/>Klaar? Klik op verder om door te gaan met je eigen nummer!";
            Assert.AreEqual(txt, c.Value);
        }

        [TestMethod]
        public void Translator_Conf_hideScroll_None()
        {
            var t = Translator("6033.json");
            var c = t.ProjectEvents.Any(x => x is ScrollHiddenConfigured);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Translator_Conf_hideScroll()
        {
            var t = Translator("56692.json");
            var c = t.ProjectEvents.Single(x => x is ScrollHiddenConfigured);
        }

        [TestMethod]
        public void Translator_Conf_LoggerButtonsHidden_None()
        {
            var t = Translator("6033.json");
            var c = t.ProjectEvents.Any(x => x is LoggerButtonsHidden);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void Translator_Conf_LoggerButtonsHidden()
        {
            var t = Translator("56692.json");
            var c = t.ProjectEvents.Single(x => x is LoggerButtonsHidden);
        }

        [TestMethod]
        public void Translator_Conf_HideSubparts()
        {
            var t = Translator("16749.json");
            var e = t.ProjectEvents.Single(x => x is SubpartsHidden) as SubpartsHidden;
            Assert.AreEqual("78,79,80,82", e.SubPartsCommaSeparated);
        }

        [TestMethod]
        public void Translator_Conf_ButtonClassConfigured_Left_KarolaRondje()
        {
            var t = Translator("15683.json");
            var e = t.ProjectEvents.Single(x => x is ButtonClassConfigured && (x as ButtonClassConfigured).ButtonPosition == ButtonPosition.Left) as ButtonClassConfigured;
            Assert.AreEqual(ButtonClass.KarolaRondje, e.ButtonClass);
        }

        [TestMethod]
        public void Translator_Conf_ButtonClassConfigured_Right_KarolaRondje()
        {
            var t = Translator("33410.json");
            var e = t.ProjectEvents.Single(x => x is ButtonClassConfigured && (x as ButtonClassConfigured).ButtonPosition == ButtonPosition.Right) as ButtonClassConfigured;
            Assert.AreEqual(ButtonClass.KarolaRondje, e.ButtonClass);
        }

        [TestMethod]
        public void Translator_Conf_AudioTipsConfigured()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is AudioTipsConfigured) as AudioTipsConfigured;
            Assert.AreEqual("1.MP3,2.MP3,3.MP3,4.MP3", e.AudioTipsCommaSeperated);
        }

        [TestMethod]
        public void Translator_Conf_PreviewPlayButtonModeConfigured()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is PreviewPlayButtonModeConfigured) as PreviewPlayButtonModeConfigured;
            Assert.AreEqual(PreviewPlayButtonMode.UpDown, e.Value);
        }

        [TestMethod]
        public void Translator_Conf_CompositionPlayButtonModeConfigured()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is CompositionPlayButtonModeConfigured) as CompositionPlayButtonModeConfigured;
            Assert.AreEqual(CompositionPlayButtonMode.UpDown, e.Value);
        }

        [TestMethod]
        public void Translator_Conf_TracksCentered()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is TracksCentered) as TracksCentered;
        }

        [TestMethod]
        public void Translator_Conf_HelpBalloonsTurnedOff()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is HelpBalloonsTurnedOff) as HelpBalloonsTurnedOff;
        }

        [TestMethod]
        public void Translator_Conf_ClipButtonsTurnedOff()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is ClipButtonsTurnedOff) as ClipButtonsTurnedOff;
        }

        [TestMethod]
        public void Translator_Conf_ButtonImgConfiguredRight()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is ButtonImgConfigured && (x as ButtonImgConfigured).Posistion == ButtonPosition.Right) as ButtonImgConfigured;
            Assert.AreEqual("images/buttonimg/knoprechtsikdroom.jpg", e.Img);
        }

        [TestMethod]
        public void Translator_Conf_ButtonImgConfiguredLeft()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is ButtonImgConfigured && (x as ButtonImgConfigured).Posistion == ButtonPosition.Left) as ButtonImgConfigured;
            Assert.AreEqual("images/buttonimg/knoplinksikdroom.jpg", e.Img);
        }

        [TestMethod]
        public void Translator_Conf_TracksBackgroundConfigured()
        {
            var t = Translator("15441.json");
            var e = t.ProjectEvents.Single(x => x is TracksBackgroundConfigured) as TracksBackgroundConfigured;
            Assert.AreEqual("images/tracks/toolbarikdroom.jpg", e.BackgroundImage);
        }

        [TestMethod]
        public void Translator_Conf_TracksColorsConfigured()
        {
            var t = Translator("15683.json");
            var e = t.ProjectEvents.Where(x => x is TrackColorDefined);
            var first = e.ElementAt(0) as TrackColorDefined;
            var second = e.ElementAt(1) as TrackColorDefined;
            Assert.AreEqual("#E5FFE5", first.Value);
            Assert.AreEqual("#D0D0D0", second.Value);
        }

        [TestMethod]
        public void Translator_Conf_NumberOfTracksConfigured()
        {
            var t = Translator("15683.json");
            var e = t.ProjectEvents.Where(x => x is NumberOfTracksConfigured);
            var first = e.ElementAt(0) as NumberOfTracksConfigured;
            var second = e.ElementAt(1) as NumberOfTracksConfigured;
            Assert.AreEqual(2, first.NumberOfTracks);
            Assert.AreEqual(3, second.NumberOfTracks);
        }

        [TestMethod]
        public void Translator_Conf_TrackHeightConfigured()
        {
            var t = Translator("15683.json");
            var e = t.ProjectEvents.Where(x => x is TrackHeightConfigured);
            var first = e.ElementAt(0) as TrackHeightConfigured;
            var second = e.ElementAt(1) as TrackHeightConfigured;
            Assert.AreEqual(105, first.TrackHeight);
            Assert.AreEqual(70, second.TrackHeight);
        }

        [TestMethod]
        public void Translator_Conf_TrackDrawingTypeConfigured()
        {
                var t = Translator("33410.json");
                var e = t.ProjectEvents.Single(x => x is TrackDrawingTypeConfigured) as TrackDrawingTypeConfigured;
                Assert.AreEqual(TrackDrawingType.Hidden, e.TrackDrawingType);
        }

        [TestMethod]
        public void Translator_Conf_PlayHeadTypeConfigured()
        {
            var t = Translator("56574.json");
            var e = t.ProjectEvents.Single(x => x is PlayHeadTypeConfigured) as PlayHeadTypeConfigured;
            Assert.AreEqual(PlayHeadType.Hidden, e.PlayHeadType);
        }

        [TestMethod]
        public void Translator_Conf_GridDrawingTypeConfigured()
        {
            var t = Translator("56574.json");
            var e = t.ProjectEvents.Single(x => x is GridDrawingTypeConfigured) as GridDrawingTypeConfigured;
            Assert.AreEqual(GridDrawingType.NoBorders, e.GridDrawingType);
        }

        [TestMethod]
        public void Translator_Conf_BackgroundImageConfigured()
        {
            var t = Translator("56574.json");
            var e = t.ProjectEvents.Single(x => x is BackgroundImageConfigured) as BackgroundImageConfigured;
            Assert.AreEqual("images/bgimg/zzzzzgeel.jpg", e.BackgroundImage);
        }

        [TestMethod]
        public void Translator_Conf_TrackBackgroundHidden()
        {
            var t = Translator("56574.json");
            t.ProjectEvents.Single(x => x is TrackBackgroundHidden);
        }

        [TestMethod]
        public void Translator_Conf_TopMarginForSubpartsConfigured()
        {
            var t = Translator("56574.json");
            var e = t.ProjectEvents.Single(x => x is TopMarginForSubpartsConfigured) as TopMarginForSubpartsConfigured;
            Assert.AreEqual(45, e.TopMargin);
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
