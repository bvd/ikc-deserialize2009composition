using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonCompositionFromIkc2009.Events.Composition;
using JsonCompositionFromIkc2009.Events.Config;
using JsonCompositionFromIkc2009.Events.MusicEnvironment;
using JsonCompositionFromIkc2009.Events.Scroll;
using Microsoft.WindowsAzure.Storage.Table;

namespace JsonCompositionFromIkc2009.Events
{
    /// <summary>
    /// this class will swallow a 2009 style ikcomponeer composition
    /// complete with all its environment data and attributes
    /// and it will translate them to events which should better
    /// capture the essence of the data and make them less complex.
    /// </summary>
    public class IkcomponeerData2009ToEventsTranslator
    {
        /// <summary>
        /// use this variable to catch the events that are sent out
        /// </summary>
        public Action<IEnumerable<TableEntity>> EmitEventAsTableEntity;

        /// <summary>
        /// translate a composite object as used by the 2009 ikcomponeer
        /// version (listen to the EmitEventAsTableEntity function to 
        /// capture the data in the form of Events)
        /// </summary>
        /// <param name="root"></param>
        public void Translate(Rootobject root)
        {
            EmitEventAsTableEntity(root.environment.projectRules.Where(
                x => x.type == "screenWidthInMeasures").Select(
                    x => new ZoomFactorChange
                    {
                        Denominator = (int)x.value
                    }
            ));

            EmitEventAsTableEntity(root.environment.projectRules.Where(
                x => x.type == "trackHeight").Select(
                    x =>
                    new TrackHeightChange
                    {
                        Value = x.value
                    }
            ));
            
            EmitEventAsTableEntity(root.environment.projectRules.Where(
                x => x.type == "bpmTempo").Select(
                    x =>
                    new TempoDefined
                    {
                        BpmTempo = x.value
                    }
            ));

            EmitEventAsTableEntity(new List<MeasureDefined>
            {
                new MeasureDefined
                {
                    Numerator = (int)root.environment.projectRules.Single(x => x.type == "measureNumerator").value,
                    Denominator =(int)root.environment.projectRules.Single(x => x.type == "beatDenominator").value
                }
            });

            EmitEventAsTableEntity(new List<QuantizeGridChange>
            {
                new QuantizeGridChange
                {
                    Numerator = (int)root.environment.projectRules.Single(x => x.type == "gridQuantizeNumerator").value,
                    Denominator = (int)root.environment.projectRules.Single(x => x.type == "gridQuantizeDenominator").value
                }
            });

            EmitEventAsTableEntity(new List<MusicSetCreated> {
                new MusicSetCreated
                {
                    id = root.environment.projectMaterial.id,
                    background = root.environment.projectMaterial.background,
                    description = root.environment.projectMaterial.textSlogan,
                    name = root.environment.projectMaterial.name,
                    type = root.environment.projectMaterial.type
                }
            });

            var setId = root.environment.projectMaterial.id;

            foreach (var partKVP in root.environment.projectMaterial.parts)
            {
                var part = partKVP.Value;
                var partId = part.id;
                EmitEventAsTableEntity(new List<MusicPartCreated> {
                    new MusicPartCreated
                    {
                        id = part.id,
                        setId = setId,
                        name = part.name,
                        order = part.order,
                        width = part.width,
                        marginX = part.marginx,
                        marginY = part.marginy
                    }
                });

                foreach (var clipKVP in part.clips)
                {
                    var clip = clipKVP.Value;
                    EmitEventAsTableEntity(new List<MusicClipCreated> {
                        new MusicClipCreated
                        {
                            id = clip.id,
                            partId = partId,
                            color = clip.color,
                            entrypoint = clip.entrypoint,
                            exitpoint = clip.exitpoint,
                            ficon = clip.ficon,
                            ficonroll = clip.ficonroll,
                            height = clip.height,
                            icon = clip.icon,
                            name = clip.name,
                            order = clip.order,
                            tag = clip.tag,
                            width = clip.width
                        }
                    });
                }
            }

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "saveButtonVisible").Select(
                x => new SaveButtonVisibilityConfigured { Visible = x.Value == "1" }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonText")).Select(
                x => new ButtonTextConfigured {
                    ButtonPosition = x.Key == "topLeftButtonText" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonText = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonTextSize")).Select(
                x => new ButtonTextSizeConfigured
                {
                    ButtonPosition = x.Key == "topLeftButtonTextSize" ? ButtonPosition.Left : ButtonPosition.Right,
                    Size = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonNote")).Select(
                x => new ButtonBehaviorConfigured
                {
                    ButtonPosition = x.Key == "TopLeftButtonNote" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonNote = IkcNotificationTransformer.Transform(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonMode")).Select(
                x => new ButtonModeConfigured
                {
                    ButtonPosition = x.Key == "TopLeftButtonNote" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonNote = ButtonModeTransformer.Transform(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "showLoggerButtons").Select(
                x => new LoggerButtonsHidden { Show = x.Value != "0" }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "licenseText").Select(
                x => new LicenseTextConfigured { Text = x.Value }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "defaultTemplateCompositionId").Select(
                x => new TemplateCompositionConfigured { Id = int.Parse(x.Value) }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "slogan").Select(
                x => new SloganConfigured { Value = x.Value }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "hide_subparts").Select(
                x => new SubpartsHidden { SubPartsCommaSeparated = x.Value }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonClass")).Select(
                x => new ButtonClassConfigured {
                    ButtonPosition = x.Key == "topLeftButtonClass" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonClass = ButtonClass.KarolaRondje
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "audiotips").Select(
                x => new AudioTipsConfigured {
                    AudioTips = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "preview_playbuttonmode").Select(
                x => new PreviewPlayButtonModeConfigured
                {
                    Value = x.Value == "upDown" ? PreviewPlayButtonMode.UpDown : PreviewPlayButtonMode.None
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "composition_playmode").Select(
                x => new CompositionPlayButtonModeConfigured
                {
                    Value = x.Value == "upDown" ? CompositionPlayButtonMode.UpDown : CompositionPlayButtonMode.None
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "centerTracks").Select(
               x => new TracksCentered
               {
                   Value = x.Value == "true" 
               }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "turnOffHelpBalloons").Select(
               x => new HelpBalloonsTurnedOff
               {
                   Value = x.Value == "true"
               }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "turnOffClipButtons").Select(
               x => new ClipButtonsTurnedOff
               {
                   Value = x.Value == "buttons off"
               }));

            EmitEventAsTableEntity(root.conf_override.Where(
                x => 
                new List<string> { "trackColorA", "trackColorB" }
                .Contains(x.Key))
                .Select(
                    x => new TrackColorDefined
                    {
                        Value = x.Value 
                    }
             ));

             EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "tracksBackgroundImg").Select(
                x => new TracksBackgroundConfigured
                {
                    BackgroundImage = x.Value
                }));

            
            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "numTracks").Select(
                x => new NumberOfTracksConfigured
                {
                    NumberOfTracks = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "trackHeight").Select(
                x => new TrackHeightConfigured
                {
                    TrackHeight = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(
                x => new List<string> { "topRightButtonImg", "topLeftButtonImg" }.Contains(x.Key))
                .Select(x => new ButtonImgConfigured
                {
                    Img = x.Value,
                    Posistion = x.Key.Substring(0, 4) == "topR" ? ButtonPosition.Left : ButtonPosition.Right
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "hideScroll").Select(
               x => new ScrollHiddenConfigured
               {
                   Value = x.Value == "true"
               }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "sloganFont").Select(
                x => new SloganFontConfigured
                {
                    Font = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "sloganLineHeigt").Select(
                x => new SloganLineHeightConfigured
                {
                    Heiht = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "sloganFontSize").Select(
                x => new SloganFontSizeConfigured
                {
                    Heiht = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "sloganColor").Select(
                x => new SloganFontColorConfigured
                {
                    Color = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "noTrackDrawing").Select(
                x => new TrackDrawingTypeConfigured
                {
                    TrackDrawingType = x.Value == "true" ? TrackDrawingType.Hidden : TrackDrawingType.Default
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "magicDelay").Select(
                x => new MagicDelayConfigured
                {
                    MagicDelay = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "playheadCircle").Select(
                x => new PlayHeadTypeConfigured
                {
                    PlayHeadType = x.Value == "false" ? PlayHeadType.Hidden : PlayHeadType.Default
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "lineColor").Select(
                x => new PlayHeadLineColorConfigured
                {
                    Color = x.Value
                }));
            
            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "subpartsTopMargin").Select(
                x => new TopMarginForSubpartsConfigured
                {
                    TopMargin = int.Parse(x.Value)
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "noBorderClips").Select(
                x => new ClipDrawingTypeConfigured
                {
                    ClipDrawingType = x.Value == "true" ? ClipDrawingType.NoBorders : ClipDrawingType.Default
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "noGrid").Select(
                x => new GridDrawingTypeConfigured
                {
                    GridDrawingType = x.Value == "true" ? GridDrawingType.NoBorders : GridDrawingType.Default
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key.Contains("ButtonColor")).Select(
                x => new ButtonColorConfigured
                {
                    ButtonPosition = x.Key.Contains("Right") ? ButtonPosition.Right : ButtonPosition.Left,
                    Order = int.Parse(x.Key.Last().ToString()),
                    ButtonColor = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "bgImg").Select(
                x => new BackgroundImageConfigured
                {
                    BackgroundImage = x.Value
                }));

            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "maskButtonsOff").Select(
                x => new MaskButtonsTurnedOff
                {
                    Off = true
                }));


            EmitEventAsTableEntity(root.conf_override.Where(x => x.Key == "hideTrackBackground").Select(
                x => new TrackBackgroundHidden
                {
                    Hidden = true
                }));

            EmitEventAsTableEntity(root.scrollitems.Select(x => new ScrollItemAdded {
                Name = x.name,
                Index = x.order,
                Id = x.id
            }));

            EmitEventAsTableEntity(new List<CompositionCreated>() {
                new CompositionCreated {
                    Name = root.composition.name,
                    Id = root.composition.id,
                    Time = root.composition.created,
                    User = root.composition.user_id
            }}.AsEnumerable());
        }

        public void TranslateComposition(Xml2CSharp.Composition composition)
        {
            EmitEventAsTableEntity(composition.Track.SelectMany(x => x.Event.Select(e => new EventAddedToTrack {
                Track = x.Id,
                Index = e.Id,
                Start = e.StartTime,
                End = e.EndTime,
                Total = e.TotalTime,
                Offset = e.Offset,
                SourceId = e.Source.Id
            })));
        }
    }
}
