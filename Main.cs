using Alkahest.Core;
using Alkahest.Core.Logging;
using Alkahest.Core.Net.Game;
using Alkahest.Core.Net.Game.Packets;
using Alkahest.Plugins.CSharp;
using System.Linq;

namespace Alkahest.Scripts.Example
{
    public static class ExampleScript
    {
        static CSharpScriptContext _context;

        static bool HandleCheckVersion(GameClient client, Direction direction, CCheckVersionPacket packet)
        {
            foreach (var ver in packet.Versions)
                _context.Log.Info("Client reported version: {0}", ver.Value);

            return true;
        }

        public static void __Start__(CSharpScriptContext context, GameProxy[] proxies)
        {
            _context = context;

            foreach (var proc in proxies.Select(x => x.Processor))
                proc.AddHandler<CCheckVersionPacket>(HandleCheckVersion);

            _context.Log.Basic("Started example script");
        }

        public static void __Stop__(CSharpScriptContext context, GameProxy[] proxies)
        {
            foreach (var proc in proxies.Select(x => x.Processor))
                proc.RemoveHandler<CCheckVersionPacket>(HandleCheckVersion);

            _context.Log.Basic("Stopped example script");
        }
    }
}
