using Alkahest.Core.Net.Game.Packets;
using Alkahest.Plugins.CSharp;

namespace Alkahest.Scripts.Example
{
    public static class ExampleScript
    {
        static CSharpScriptContext _context;

        public static void __Start__(CSharpScriptContext context)
        {
            _context = context;

            context.Dispatch.AddHandler<CCheckVersionPacket>((client, direction, packet, flags) =>
            {
                foreach (var ver in packet.Versions)
                    _context.Log.Info("Client reported version: {0}", ver.Value);

                return true;
            });

            context.Log.Basic("Started example script");
        }

        public static void __Stop__(CSharpScriptContext context)
        {
            context.Log.Basic("Stopped example script");
        }
    }
}
