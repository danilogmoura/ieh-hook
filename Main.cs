using MelonLoader;

namespace IEHHook
{
    public static class BuildInfo
    {
        public const string Name = "IEH Mod";
        public const string Description = "";
        public const string Author = "Author";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }

    public class TRHook : MelonMod
    {
        public override void OnInitializeMelon()
        {
            var harmony = new HarmonyLib.Harmony("br.com.danilogmoura.ieh");
            harmony.PatchAll();
        }
    }
}