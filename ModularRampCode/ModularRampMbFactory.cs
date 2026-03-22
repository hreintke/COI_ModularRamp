using Mafi;
using Mafi.Unity.Entities;
using RTG;
using System;
using System.Collections.Generic;
using System.Text;
using static RTG.Object2ObjectSnap;

namespace ModularRampMod;

[GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
public class ModularRampMbFactory :
        IEntityMbFactory<ModularRamp>,
        IFactory<ModularRamp, EntityMb>
{

    private readonly ProtoModelFactory modelFactory;

    public ModularRampMbFactory(ProtoModelFactory mFactory)
    {
        modelFactory = mFactory;
    }

    public EntityMb Create(ModularRamp ramp)
    {
        LogWrite.Info("Creating ModularRampMb");
        ModularRampMb modularRampMb = modelFactory.CreateModelFor(ramp.Prototype).AddComponent<ModularRampMb>();
        modularRampMb.Initialize(ramp);
        LogWrite.Info("Creating ModularMb Done");
        return (EntityMb)modularRampMb;
  
    }
}
