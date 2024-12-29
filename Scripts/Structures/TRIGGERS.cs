using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    internal class TRIGGERS
    {
        TRIGGER[] triggers;

        public TRIGGERS(TRIGGER[] triggers) => this.triggers = triggers;

        public TRIGGERS(List<TRIGGER> triggers) => this.triggers = triggers.ToArray();
        public TRIGGERS(List<string> triggers) => this.triggers = triggers.Select(x => new TRIGGER(x)).ToArray();

        public int Length => Triggers.Length;
        public int Count() => Triggers.Count();

        public TRIGGER[] Triggers => triggers;

        public TRIGGER[] ToArray() => triggers;

        public TRIGGER this[int index]
        {
            get => Triggers[index];
            set => Triggers[index] = value;
        }

        public void Free() => Triggers.ToList().ForEach(z => z.Free());

        public static implicit operator TRIGGER[](TRIGGERS t) => t.Triggers;
        public static explicit operator TRIGGERS(TRIGGER[] t) => new TRIGGERS(t);
    }
}
