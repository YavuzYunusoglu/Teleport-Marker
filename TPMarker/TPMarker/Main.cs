using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMarker
{
    public class Main : RocketPlugin<Configuration>
    {
        public static Main Instance { get; private set; }
        protected override void Load()
        {
            Instance = this;
            Console.WriteLine($"{Name} Active!");
        }
        protected override void Unload()
        {
            Instance = null;
            Console.WriteLine($"{Name} Deactive!");
        }
    }
}
