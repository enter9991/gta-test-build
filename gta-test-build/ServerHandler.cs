using System;
using AltV.Net;

namespace gta_test_build
{
    class ServerHandler : Resource
    {
        public override void OnStart()
        {
            Alt.Log("Console: Server wurde gestartet");
        }

        public override void OnStop()
        {
            Alt.Log("Console: Server wurde Gestopt");
        }
    }

}
