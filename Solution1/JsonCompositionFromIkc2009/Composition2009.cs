using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompositionFromIkc2009
{
    public class Rootobject
    {
        public Composition composition { get; set; }
        public Environment environment { get; set; }
        public string environment_identifier { get; set; }
        public Scrollitem[] scrollitems { get; set; }
        public string scrollitems_identifier { get; set; }
        public string conf_identifier { get; set; }
        public Dictionary<string, string> conf_override { get; set; }
    }

    public class Composition
    {
        public int id { get; set; }
        public string content { get; set; }
        public int published { get; set; }
        public int hasmp3 { get; set; }
        public string name { get; set; }
        public int mtime { get; set; }
        public int project_id { get; set; }
        public int limited { get; set; }
        public int empty { get; set; }
        public int migrated { get; set; }
    }

    public class Environment
    {
        public Projectrule[] projectRules { get; set; }
        public Projectmaterial projectMaterial { get; set; }
    }

    public class Projectmaterial
    {
        public int id { get; set; }
        public string name { get; set; }
        public string textSlogan { get; set; }
        public string background { get; set; }
        public string type { get; set; }
        public Dictionary<int, Part> parts { get; set; }
    }

    public class Part
    {
        public int id { get; set; }
        public string name { get; set; }
        public int marginx { get; set; }
        public int marginy { get; set; }
        public int order { get; set; }
        public int width { get; set; }
        public Dictionary<int, Clip> clips { get; set; }
    }

    public class Clip
    {
        public int id { get; set; }
        public int exitpoint { get; set; }
        public int entrypoint { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public string icon { get; set; }
        public string ficon { get; set; }
        public string ficonroll { get; set; }
        public int order { get; set; }
        public string color { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class Projectrule
    {
        public string type { get; set; }
        public float value { get; set; }
    }

    public class Scrollitem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
    }
}
