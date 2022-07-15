using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TPMarker
{
    public class TPCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "tpm";

        public string Help => "tp to marker!";

        public string Syntax => "/tpm";

        public List<string> Aliases => new List<string> { "tpmarker" };

        public List<string> Permissions => new List<string> { "pdw.staff" };

        [Obsolete]
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer unp = caller as UnturnedPlayer;
            SteamPlayer player = PlayerTool.getSteamPlayer(unp.CSteamID);
            if (player.player.quests.markerPosition == null)
            {
                say(player, "If you want teleport to marker, you should mark to location!", Color.red);
                return;
            }
            unp.Teleport(GetGround(player.player.quests.markerPosition).Value, 0);
            say(player, "Successfully teleported to marker!", Color.yellow);
            player.player.quests.askSetMarker(unp.CSteamID,true,new Vector3(0f,0f,0f));
        }
        public static Vector3? GetGround(Vector3 Position)
        {
            int layerMasks = (RayMasks.BARRICADE | RayMasks.BARRICADE_INTERACT | RayMasks.ENEMY | RayMasks.ENTITY | RayMasks.ENVIRONMENT | RayMasks.GROUND | RayMasks.GROUND2 | RayMasks.ITEM | RayMasks.RESOURCE | RayMasks.STRUCTURE | RayMasks.STRUCTURE_INTERACT);
            if (Physics.Raycast(new Vector3(Position.x, Position.y + 400, Position.z), Vector3.down, out RaycastHit Hit, 500, layerMasks))
            {
                return Hit.point;
            }
            else
            {
                return null;
            }
        }
        private void say(SteamPlayer player, string text, Color color)
        {
            ChatManager.serverSendMessage(text, color, player, player, EChatMode.GLOBAL, Main.Instance.Configuration.Instance.chatIcon, true);
        }
    }
}
