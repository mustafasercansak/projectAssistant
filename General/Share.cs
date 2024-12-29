using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static class Share
    {
        private static ProjectInfo projectInfo = new ProjectInfo();

        public static ProjectInfo ProjectInfo { get => projectInfo; set => projectInfo = value; }
    }
}
