namespace JsonCompositionFromIkc2009.Events.Config
{
    public enum IkcNotification
    {
        None,
        HelpHooverOnOff,
        AboutThisApplication,
        OpenSessionModule,
        PlayAudioTip,
        ClearComposition,
        PlayPause,
        WhiteLabelHelp
    }

    public class IkcNotificationTransformer
    {
        public static IkcNotification Transform(string value)
        {
            switch (value)
            {
                case "help hoover on/off":
                    return IkcNotification.HelpHooverOnOff;

                case "about this application":
                    return IkcNotification.AboutThisApplication;

                case "open session module":
                    return IkcNotification.OpenSessionModule;

                case "play audio tip":
                    return IkcNotification.PlayAudioTip;

                case "clear composition":
                    return IkcNotification.ClearComposition;

                case "play pause":
                    return IkcNotification.PlayPause;

                case "white label help":
                    return IkcNotification.WhiteLabelHelp;

                default:
                    return IkcNotification.None;
            }
        }
    }
}
