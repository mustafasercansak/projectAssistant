using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class ActionTrigger
    {
        string name;
        ActionTriggerType triggerType;
        ActionTriggerCycle cycle;
        string varName;
        ActionAcyclicTrigger acyclic;

        public string Name { get => name; set => name = value; }
        public ActionTriggerType TriggerType
        {
            get => triggerType;
            set => triggerType = value;
        }

        public ActionTriggerCycle Cycle { get => cycle; set => cycle = value; }
        public string VarName { get => varName; set => varName = value; }
        public ActionAcyclicTrigger Acyclic { get => acyclic; set => acyclic = value; }
    }
}
