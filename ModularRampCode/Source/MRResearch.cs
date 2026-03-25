using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRampMod;


public partial class PrototypeIDs
{
    public partial class Research
    {
        public static readonly ResearchNodeProto.ID UnlockModularRamp = Ids.Research.CreateId("ModularRamp");
    }
}

public class MRResearch : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.ResearchNodeProtoBuilder
            .Start("ModularRamp", PrototypeIDs.Research.UnlockModularRamp, 30, "ModularRamp")
            .Description("Underground Transport")
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampCenter)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampCenterSingle)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntrance)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntrance4)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntrance2)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntrance1)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntranceSingle)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntranceDouble)
            .AddLayoutEntityToUnlock(PrototypeIDs.LocalEntities.ModularRampEntranceTriple)
            .SetGridPosition(new Vector2i(24, 11))
            .AddParents(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.Cp2Packing))
            .BuildAndAdd();
    }
}
