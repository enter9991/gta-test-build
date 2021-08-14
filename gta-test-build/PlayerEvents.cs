using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace gta_test_build
{
    class PlayerEvents : IScript { 
    
        [ScriptEvent(ScriptEventType.PlayerConnect)]

        public void OnPlayerConnect(IPlayer player, string reason)
        {
            player.Model = (uint) PedModel.Andreas;
            player.Spawn(new AltV.Net.Data.Position(0, 0, 0));
        }
    }
}
