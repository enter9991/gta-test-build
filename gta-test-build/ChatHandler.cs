using System;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;

namespace gta_test_build
{
    class ChatHandler : IScript
    {
        [ClientEvent("chat:message")]

        public void OnChatMessage(IPlayer player, string msg)
        {
            foreach(IPlayer target in Alt.GetAllPlayers())
            {
                if(target.Position.Distance(player.Position)<=10)
                {
                    player.SendChatMessage($"{player.Name} sagt: {msg}");
                }
            }
        }


        [CommandEvent(CommandEventType.CommandNotFound)]
        
        public void OnCommandNotFound(IPlayer player, string cmd)
        {
            player.SendChatMessage("{FF0000}[Server] {FFFFFF}Befehl konnte nicht gefunden werden!");
        }

        [Command("auto")]
        public static void CMD_CreateVehicle(IPlayer player, string vehName, int r = 0, int g = 0, int b = 0)
        {
            uint vehHash = Alt.Hash(vehName);

            if (!Enum.IsDefined(typeof(Vehicle), vehHash))
            {
                player.SendChatMessage("[Server] Ungültiger Fahrzeugname!");
                return;
            }

            IVehicle veh = Alt.CreateVehicle(vehHash, GetRandomPositionAround(player.Position, 5.0f), player.Rotation);
        }

        public static Position GetRandomPositionAround(Position pos, float range)
        {
            Random rnd = new Random();
            float x = pos.X + (float)rnd.NextDouble() * (range * 2) - range;
            float y = pos.y + (float)rnd.NextDouble() * (range * 2) - range;
            return new Position(x, y, pos.Z);
        }




    }
}
