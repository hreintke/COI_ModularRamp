using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mafi.Core.Prototypes.Proto;

namespace ModularRampMod;

public partial class PrototypeIDs
{
    public partial class LocalEntities
    {
        public static readonly MRPrototype.ID ModularRampCenter = new MRPrototype.ID("ModularRampCenter");
        public static readonly MRPrototype.ID ModularRampCenterSingle = new MRPrototype.ID("ModularRampCenterSingle");
        public static readonly MRPrototype.ID ModularRampEntrance2 = new MRPrototype.ID("ModularRampEntrance2");
        public static readonly MRPrototype.ID ModularRampEntrance = new MRPrototype.ID("ModularRampEntrance");
        public static readonly MRPrototype.ID ModularRampEntrance4 = new MRPrototype.ID("ModularRampEntrance4");
//        public static readonly MRPrototype.ID ModularRampEntrance6 = new MRPrototype.ID("ModularRampEntrance6");
        public static readonly MRPrototype.ID ModularRampEntrance1 = new MRPrototype.ID("ModularRampEntrance1");
        public static readonly MRPrototype.ID ModularRampEntranceSingle = new MRPrototype.ID("ModularRampSingle");
        public static readonly MRPrototype.ID ModularRampEntranceDouble = new MRPrototype.ID("ModularRampDouble");
        public static readonly MRPrototype.ID ModularRampEntranceTriple = new MRPrototype.ID("ModularRampTriple");
        
    }
}

public class MRPrototype : LayoutEntityProto, IProto, IProtoWithTiers, IProtoWithIcon
{
    public MRPrototype(MRPrototype.ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics)
         : base(id, strings, layout, costs, graphics)
    {
        this.TierData = new TierData((IProtoWithTiers)this, -1);
    }

    public override Type EntityType => typeof(ModularRamp);

    public ITierData TierData  {get;}
    
}
