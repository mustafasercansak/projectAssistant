using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public class ProjectInfo
    {
        public string ProjectFile { get; set; }
        public string DSNName { get; set; }
        public CultureInfo DataLocale { get; set; }
        public string ProjectDir { get; set; }
        public string ProjectAppDir { get; set; }
        public string GlobalLibDir { get; set; }
        public string ProjectLibDir { get; set; }
        public string LocalProjectAppDir { get; set; }
        public Version Version { get; set; }
        public string Name { get; set; }
        public bool RuntimeActive { get; set; }
    }
}
