using Mafi;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRampMod;

[GenerateSerializer(false, null, 0)]
public class ModularRamp : LayoutEntityBase
{
    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

    public override bool CanBePaused => false;

    public ModularRamp(EntityId id, LayoutEntityProto proto, TileTransform transform, EntityContext context)
        : base (id, proto, transform, context)
    {
    }

    public static void Serialize(ModularRamp value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
        }
    }

    public static ModularRamp Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out ModularRamp obj, (Func<BlobReader, Type, ModularRamp>)null, (Func<BlobReader, string, ModularRamp>)null, nullObjIsOk: false))
        {
            reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
        }

        return obj;
    }

    static ModularRamp()
    {
         s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((ModularRamp)obj).SerializeData(writer);
        };
        s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((ModularRamp)obj).DeserializeData(reader);
        };
    }
}

