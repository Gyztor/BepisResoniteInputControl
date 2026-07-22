using Elements.Core;
using HarmonyLib;
using BepInEx;
using BepInEx.Logging;
using BepInEx.NET.Common;
using BepInExResoniteShim;
using BepisResoniteWrapper;
using System.Linq;
using System.Reflection;
using Renderite.Shared;
using BepInEx.Configuration;


namespace ResoniteInputControl;

[ResonitePlugin(PluginMetadata.GUID, PluginMetadata.NAME, PluginMetadata.VERSION, PluginMetadata.AUTHORS, PluginMetadata.REPOSITORY_URL)]
[BepInDependency(BepInExResoniteShim.PluginMetadata.GUID)]
public class ResoniteInputControl : BasePlugin
{
	internal new static ManualLogSource Log = null!;
	/*private static Assembly ModAssembly => typeof(ResoniteInputControl).Assembly;

	public override string Name => ModAssembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title;
	public override string Author => ModAssembly.GetCustomAttribute<AssemblyCompanyAttribute>()!.Company;
	public override string Version => ModAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
	public override string Link => ModAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().First(meta => meta.Key == "RepositoryUrl").Value!;

	internal static string HarmonyId => $"com.IHaveAName2653.{ModAssembly.GetName()}";

	private static readonly Harmony harmony = new(HarmonyId);

	public static ModConfiguration? Config;

	// Example Mod Config Key // Provides a "Mod Toggle" (assuming the functions implement it)
	[AutoRegisterConfigKey]
	public static ModConfigurationKey<bool> shouldBeActive = new("IsActive", "If the mod should generate the dynvars", () => true);*/
	internal static ConfigEntry<bool> shouldBeActive;

	/*static ResoniteInputControl()
	{
		DebugFunc(() => $"Static Initializing {nameof(ResoniteInputControl)}...");
	}*/

	public override void Load()
	{
		Log = base.Log;
		shouldBeActive = Config.Bind("Resonite Input Control", "Mod Enabled", true, new ConfigDescription("Enables the mod."));

        try
        {
            HarmonyInstance.PatchAll();
            Log.LogInfo("Resonite Input Control has successfully loaded!");
        } 
        catch (System.Exception ex)
        {
            Log.LogError($"Resonite Input Control failed to patch: {ex}");
        }
	}
}
