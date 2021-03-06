﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonCompositionFromIkc2009.Events.Composition;
using JsonCompositionFromIkc2009.Events.Config;
using JsonCompositionFromIkc2009.Events.MusicEnvironment;
using JsonCompositionFromIkc2009.Events.Scroll;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

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
        private readonly List<IMusicEnvironmentEvent> _environmentEvents = new List<IMusicEnvironmentEvent>();

        public override string ToString()
        {
            List<object> all = new List<object>();
            all.AddRange(ScrollEvents);
            all.AddRange(ProjectEvents);
            all.AddRange(EnvironmentEvents);
            all.AddRange(CompositionEvents);
            return JsonConvert.SerializeObject(all);
        }
        public List<IMusicEnvironmentEvent> EnvironmentEvents
        {
            get
            {
                return this._environmentEvents;
            }
        }

        private readonly List<IConfig> _projectEvents = new List<IConfig>();

        public List<IConfig> ProjectEvents
        {
            get
            {
                return this._projectEvents;
            }
        }

        private readonly List<IScroll> _scrollEvents = new List<IScroll>();

        public List<IScroll> ScrollEvents
        {
            get
            {
                return this._scrollEvents;
            }
        }

        private readonly List<IComposition> _compositionEvents = new List<IComposition>();

        public List<IComposition> CompositionEvents
        {
            get
            {
                return this._compositionEvents;
            }
        }

        /// <summary>
        /// translate a composite object as used by the 2009 ikcomponeer
        /// version (listen to the EmitEventAsTableEntity function to 
        /// capture the data in the form of Events)
        /// </summary>
        /// <param name="root"></param>
        public void Translate(Rootobject root)
        {
            _projectEvents.AddRange(root.environment.projectRules.Where(
                x => x.type == "screenWidthInMeasures").Select(
                    x => new ZoomFactorChange
                    {
                        Denominator = (int)x.value
                    }
            ));

            _projectEvents.AddRange(root.environment.projectRules.Where(
                x => x.type == "trackHeight").Select(
                    x =>
                    new TrackHeightChange
                    {
                        Value = x.value
                    }
            ));

            _environmentEvents.AddRange(root.environment.projectRules.Where(
                x => x.type == "bpmTempo").Select(
                    x =>
                    new TempoDefined
                    {
                        BpmTempo = x.value
                    }
            ));

            _environmentEvents.Add(
                new MeasureDefined
                {
                    Numerator = (int)root.environment.projectRules.Single(x => x.type == "measureNumerator").value,
                    Denominator = (int)root.environment.projectRules.Single(x => x.type == "beatDenominator").value
                });

            _projectEvents.Add(

                new QuantizeGridChange
                {
                    Numerator = (int)root.environment.projectRules.Single(x => x.type == "gridQuantizeNumerator").value,
                    Denominator = (int)root.environment.projectRules.Single(x => x.type == "gridQuantizeDenominator").value
                });

            _environmentEvents.Add(
                new MusicSetCreated
                {
                    id = root.environment.projectMaterial.id,
                    background = root.environment.projectMaterial.background,
                    description = root.environment.projectMaterial.textSlogan,
                    name = root.environment.projectMaterial.name,
                    type = root.environment.projectMaterial.type
                });

            var setId = root.environment.projectMaterial.id;

            var MusicPartCreatedSortList = new Dictionary<string, MusicPartCreated>();
            var MusicClipsSortLists = new Dictionary<string, Dictionary<string, MusicClipCreated>>();

            var orderSuitableToSortOn =
                root.environment.projectMaterial.parts.Count == root.environment.projectMaterial.parts.GroupBy(x => x.Value.order).Count();

            foreach (var partKVP in root.environment.projectMaterial.parts)
            {
                var part = partKVP.Value;
                var partId = part.id;

                var order = orderSuitableToSortOn ? part.order : part.id;

                MusicPartCreatedSortList.Add(order,
                    new MusicPartCreated
                    {
                        id = part.id,
                        setId = setId,
                        name = part.name,
                        width = part.width,
                        marginX = part.marginx,
                        marginY = part.marginy
                    });

                MusicClipsSortLists.Add(order, new Dictionary<string, MusicClipCreated>());

                var clipsOrderSuitableToSortOn =
                    part.clips.Count == part.clips.GroupBy(x => x.Value.order).Count();

                foreach (var clipKVP in part.clips)
                {
                    var clip = clipKVP.Value;
                    var clipOrder = clipsOrderSuitableToSortOn ? clip.order : clip.id;

                    MusicClipsSortLists[order].Add(clipOrder, new MusicClipCreated
                    {
                        id = clip.id,
                        partId = partId,
                        color = clip.color,
                        entrypoint = clip.entrypoint,
                        exitpoint = clip.exitpoint,
                        ficon = clip.ficon,
                        ficonroll = clip.ficonroll,
                        iconAdjustHeight = clip.height,
                        icon = clip.icon,
                        name = clip.name,
                        tag = clip.tag,
                        iconAdjustWidth = clip.width
                    });
                }
            }

            var musicPartCreatedEvents = from x in MusicPartCreatedSortList
                                         orderby x.Key.Length, x.Key
                                         select x;



            foreach (var musicPartCreatedEvent in musicPartCreatedEvents)
            {
                _environmentEvents.Add(musicPartCreatedEvent.Value);

                var musicClipCreatedEvents = from y in MusicClipsSortLists[musicPartCreatedEvent.Key]
                                             orderby y.Key.Length, y.Key
                                             select y;

                foreach (var musicClipCreatedEvent in musicClipCreatedEvents)
                {
                    var clip = musicClipCreatedEvent.Value as MusicClipCreated;
                    var sort = musicClipCreatedEvent.Key;
                    _environmentEvents.Add(musicClipCreatedEvent.Value);
                }
            }

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_saveButtonVisible").Select(
                x => new SaveButtonVisibilityConfigured { Visible = x.Value == "1" }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonText")).Select(
                x => new ButtonTextConfigured
                {
                    ButtonPosition = x.Key == "conf_topLeftButtonText" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonText = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonTextSize")).Select(
                x => new ButtonTextSizeConfigured
                {
                    ButtonPosition = x.Key == "topLeftButtonTextSize" ? ButtonPosition.Left : ButtonPosition.Right,
                    Size = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonNote")).Select(
                x => new ButtonBehaviorConfigured
                {
                    ButtonPosition = x.Key == "conf_topLeftButtonNote" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonNote = IkcNotificationTransformer.Transform(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonMode")).Select(
                x => new ButtonModeConfigured
                {
                    ButtonPosition = x.Key == "conf_topLeftButtonMode" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonMode = ButtonModeTransformer.Transform(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_showLoggerButtons").Select(
                x => new LoggerButtonsHidden()));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_licenseText").Select(
                x => new LicenseTextConfigured { Text = x.Value }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_defaultTemplateCompositionId").Select(
                x => new TemplateCompositionConfigured { Id = x.Value }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_slogan").Select(
                x => new SloganConfigured { Value = x.Value }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_hide_subparts").Select(
                x => new SubpartsHidden { SubPartsCommaSeparated = x.Value }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonClass")).Select(
                x => new ButtonClassConfigured
                {
                    ButtonPosition = x.Key == "conf_topLeftButtonClass" ? ButtonPosition.Left : ButtonPosition.Right,
                    ButtonClass = ButtonClass.KarolaRondje
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_audiotips").Select(
                x => new AudioTipsConfigured
                {
                    AudioTipsCommaSeperated = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_preview_playbuttonmode").Select(
                x => new PreviewPlayButtonModeConfigured
                {
                    Value = x.Value == "upDown" ? PreviewPlayButtonMode.UpDown : PreviewPlayButtonMode.None
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_composition_playmode").Select(
                x => new CompositionPlayButtonModeConfigured
                {
                    Value = x.Value == "upDown" ? CompositionPlayButtonMode.UpDown : CompositionPlayButtonMode.None
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_centerTracks").Select(
               x => new TracksCentered()));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_turnOffHelpBalloons").Select(
               x => new HelpBalloonsTurnedOff()));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_turnOffClipButtons").Select(
               x => new ClipButtonsTurnedOff()));

            _projectEvents.AddRange(root.conf_override.Where(
                x => x.Key == "conf_trackColorA").Select(x => new TrackColorDefined
                {
                    Value = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(
                x => x.Key == "conf_trackColorB").Select(x => new TrackColorDefined
                {
                    Value = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_tracksBackgroundImg").Select(
                x => new TracksBackgroundConfigured
                {
                    BackgroundImage = x.Value
                }));

            _projectEvents.AddRange(root.environment.projectRules.Where(x => x.type == "trackHeight").Select(
                x => new TrackHeightConfigured
                {
                    TrackHeight = (int)x.value
                }));


            _projectEvents.AddRange(root.environment.projectRules.Where(x => x.type == "numTracks").Select(
                x => new NumberOfTracksConfigured
                {
                    NumberOfTracks = (int)x.value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_numTracks").Select(
                x => new NumberOfTracksConfigured
                {
                    NumberOfTracks = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_trackHeight").Select(
                x => new TrackHeightConfigured
                {
                    TrackHeight = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(
                x => x.Key.Contains("ButtonImg"))
                .Select(x => new ButtonImgConfigured
                {
                    Img = x.Value,
                    ButtonPosition = x.Key.Contains("topRight") ? ButtonPosition.Right : ButtonPosition.Left
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_hideScroll").Select(
               x => new ScrollHiddenConfigured()));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_sloganFont").Select(
                x => new SloganFontConfigured
                {
                    Font = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_sloganLineHeigt").Select(
                x => new SloganLineHeightConfigured
                {
                    Height = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_sloganFontSize").Select(
                x => new SloganFontSizeConfigured
                {
                    FontSize = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_sloganColor").Select(
                x => new SloganFontColorConfigured
                {
                    Color = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_noTrackDrawing").Select(
                x => new TrackDrawingTypeConfigured
                {
                    TrackDrawingType = x.Value == "true" ? TrackDrawingType.Hidden : TrackDrawingType.Default
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_magicDelay").Select(
                x => new MagicDelayConfigured
                {
                    MagicDelay = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_playheadCircle").Select(
                x => new PlayHeadTypeConfigured
                {
                    PlayHeadType = x.Value == "false" ? PlayHeadType.Hidden : PlayHeadType.Default
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_lineColor").Select(
                x => new PlayHeadLineColorConfigured
                {
                    Color = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_subpartsTopMargin").Select(
                x => new TopMarginForSubpartsConfigured
                {
                    TopMargin = int.Parse(x.Value)
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_noBorderClips").Select(
                x => new ClipDrawingTypeConfigured
                {
                    ClipDrawingType = x.Value == "true" ? ClipDrawingType.NoBorders : ClipDrawingType.Default
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_noGrid").Select(
                x => new GridDrawingTypeConfigured
                {
                    GridDrawingType = x.Value == "true" ? GridDrawingType.NoBorders : GridDrawingType.Default
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key.Contains("ButtonColor")).Select(
                x => new ButtonColorConfigured
                {
                    ButtonPosition = x.Key.Contains("Right") ? ButtonPosition.Right : ButtonPosition.Left,
                    Order = int.Parse(x.Key.Last().ToString()),
                    ButtonColor = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_bgImg").Select(
                x => new BackgroundImageConfigured
                {
                    BackgroundImage = x.Value
                }));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "maskButtonsOff").Select(
                x => new MaskButtonsTurnedOff
                {
                    Off = true
                }));


            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_hideTrackBackground").Select(
                x => new TrackBackgroundHidden()));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_displayMenuRight").Select(
                x => new MenuDisplayHiddenRight()
            ));

            _projectEvents.AddRange(root.conf_override.Where(x => x.Key == "conf_displayMenuLeft").Select(
                x => new MenuDisplayHiddenLeft()
            ));

            _scrollEvents.AddRange(root.scrollitems.OrderBy(x => x.order).Select(x => new ScrollItemAdded
            {
                Name = x.name,
                Index = x.order,
                Id = x.id.ToString()
            }));

            _compositionEvents.Add(new ClearCompositionEvent());

            _compositionEvents.Add(
                new CompositionCreated
                {
                    Conf = root.conf_identifier,
                    Scroll = root.scrollitems_identifier,
                    Environment = root.environment_identifier,
                    Name = root.composition.name,
                    Id = root.composition.id.ToString(),
                    Time = root.composition.created,
                    User = root.composition.user_id,
                    UserName = root.composition.username
                });
        }

        public void TranslateComposition(Xml2CSharp.Composition composition)
        {
            _compositionEvents.AddRange(composition.Track.SelectMany(x => x.Event.Select(e => new EventAddedToTrack
            {
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
