using Mafi;
using Mafi.Collections;
using Mafi.Core.Mods;
using Mafi.Core.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mafi.Core.Prototypes;


namespace ModularRampMod;

public sealed class ModularRampMod : IMod
{
    ModManifest manifest;

    public ModularRampMod(ModManifest mmf)
    {
        manifest = mmf; 
    }

    public string Name => typeof(ModularRampMod).Assembly.GetName().Name;

    public int Version => (typeof(ModularRampMod).Assembly.GetName().Version.Major * 100) +
                            (typeof(ModularRampMod).Assembly.GetName().Version.Minor * 10) +
                            (typeof(ModularRampMod).Assembly.GetName().Version.Build);

    public static Version ModVersion => typeof(ModularRampMod).Assembly.GetName().Version;
    public bool IsUiOnly => false;

    public Option<IConfig> ModConfig { get; }

    public ModManifest Manifest => manifest;

    public ModJsonConfig JsonConfig => new ModJsonConfig(this);

    public void ChangeConfigs(Lyst<IConfig> configs)
    {
    }

    public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
    {
        LogWrite.Info($"Initializing Version = {Version}");
    }

    public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)
    {
        LogWrite.Info("Register Dependencies ");
    }

    public void RegisterPrototypes(ProtoRegistrator registrator)
    {
        LogWrite.Info("Registrating Prototypes");
        registrator.RegisterData<MRData>();
        registrator.RegisterData<MRResearch>();
    }

    public void EarlyInit(DependencyResolver resolver)
    {
        LogWrite.Info($"EarlyInit");
    }

    public void MigrateJsonConfig(VersionSlim savedVersion, Dict<string, object> savedValues)
    { 
    }

    public void Dispose()
    {
    }
}

