/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "source")]
    public class Source
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "event")]
    public class Event
    {
        [XmlElement(ElementName = "source")]
        public Source Source { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "startTime")]
        public int StartTime { get; set; }
        [XmlAttribute(AttributeName = "endTime")]
        public int EndTime { get; set; }
        [XmlAttribute(AttributeName = "offset")]
        public int Offset { get; set; }
        [XmlAttribute(AttributeName = "totalTime")]
        public int TotalTime { get; set; }
    }

    [XmlRoot(ElementName = "track")]
    public class Track
    {
        [XmlElement(ElementName = "event")]
        public List<Event> Event { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "numEvents")]
        public int NumEvents { get; set; }
    }

    [XmlRoot(ElementName = "composition")]
    public class Composition
    {
        [XmlElement(ElementName = "track")]
        public List<Track> Track { get; set; }
    }

}

