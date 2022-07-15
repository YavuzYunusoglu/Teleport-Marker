using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMarker
{
    public class Configuration : IRocketPluginConfiguration
    {
        public string chatIcon;
        public void LoadDefaults()
        {
            chatIcon = "https://cdn-icons-png.flaticon.com/512/1673/1673221.png";
        }
    }
}
