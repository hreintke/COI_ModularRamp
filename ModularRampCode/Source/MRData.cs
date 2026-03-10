using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities.Dynamic;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Trains;
using Mafi.Core.Vehicles.Trucks;
using Mafi.Localization;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RTG.Object2ObjectSnap;

namespace ModularRampMod;

public class MRData : IModData
{
    public static readonly LocStr RAMPS_DESC;

    public void RegisterData(ProtoRegistrator registrator)
    {
        EntityLayoutParams layoutParams = new EntityLayoutParams(customTokens: (IEnumerable<CustomLayoutToken>)new CustomLayoutToken[9]
        {
                    new CustomLayoutToken("&0]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
        {
          int heightToExcl = h;
          int? terrainSurfaceHeight = new int?(0);
          Proto.ID? nullable = new Proto.ID?(p.HardenedFloorSurfaceId);
          int? minTerrainHeight = new int?();
          int? maxTerrainHeight = new int?();
          Fix32? vehicleHeight = new Fix32?();
          Proto.ID? terrainMaterialId = new Proto.ID?();
          Proto.ID? surfaceId = new Proto.ID?();
          return new LayoutTokenSpec(heightToExcl: heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
        })),
            new CustomLayoutToken("%0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightFrom = h - 1;
                int heightToExcl = h;
                int? nullable1 = new int?(h - 1);
                Fix32? nullable2 = new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value);
                Proto.ID? nullable3 = new Proto.ID?(p.HardenedFloorSurfaceId);
                int? terrainSurfaceHeight = new int?();
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = nullable1;
                Fix32? vehicleHeight = nullable2;
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = nullable3;
                return new LayoutTokenSpec(
                    heightFrom,
                    heightToExcl,
                    terrainSurfaceHeight: terrainSurfaceHeight,
                    minTerrainHeight: minTerrainHeight,
                    maxTerrainHeight: maxTerrainHeight,
                    vehicleHeight: vehicleHeight,
                    terrainMaterialId: terrainMaterialId,
                    surfaceId: surfaceId);
            })),
            new CustomLayoutToken("_0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightFrom = h - 1;
                int heightToExcl = h;
                int? terrainSurfaceHeight = new int?();
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = new int?(h - 1);
                Fix32? vehicleHeight = new Fix32?((Fix32) (h - 1));
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = new Proto.ID?();
                return new LayoutTokenSpec(heightFrom, heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),
            new CustomLayoutToken("<R1", (Func<EntityLayoutParams, int, LayoutTokenSpec>)
                ((p, h) => new LayoutTokenSpec(heightToExcl: 1,
                surfaceId: new Proto.ID?(p.HardenedFloorSurfaceId),
                isRamp: true))),

            new CustomLayoutToken("<R2", (Func<EntityLayoutParams, int, LayoutTokenSpec>)
                ((p, h) => new LayoutTokenSpec(1, 2, maxTerrainHeight: new int?(1), isRamp: true))),
            new CustomLayoutToken("<R3", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(2, 3, maxTerrainHeight: new int?(1), isRamp: true))),

            new CustomLayoutToken("=23", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(1, 3, maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=24", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(2, 4, maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(3, 4, maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))) }

        );

        EntityLayout newLayout;
        EntityCostsTpl entityCost;

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2][2]=23=23=23=24=24=24&5]",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4=",
            "[1][1][2][2]=23=23=23=24=24=24&5]");
        
        entityCost = new EntityCostsTpl.Builder().CP2(40).Concrete(100);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance,
            "ModularRamp (entrance)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
//            "Assets/ModularRamp/Prefabs/EntranceHlafPillarTextured.prefab",
//            "Assets/ModularRamp/Prefabs/EntranceHlafPillarTexturedBoxed.prefab",
            "Assets/ModularRamp/Prefabs/EntranceBoxed.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );


        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "=3-=3-",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "=3-=3-");

        entityCost = new EntityCostsTpl.Builder().CP2(20).Concrete(40);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampCenter,
            "ModularRamp (center)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
        //            "Assets/ModularRamp/Prefabs/CenterRoad2.prefab",
        "Assets/ModularRamp/Prefabs/CenterBoxed.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampCenter.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,


           "&5]_4=_4=_4=_4=_4=_4=&5]",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "=3-_4=_4=_4=_4=_4=_4=_4=",
           "&5]=3-=3-=3-=3-=3-=3-&5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceSingle,
            "ModularRamp (single)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E1Boxed.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "&5]=3-=3-=3-=3-=3-=3-&5]",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "&5]_4=_4=_4=_4=_4=_4=&5]");

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceDouble,
            "ModularRamp (double)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E2Boxed.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampDouble.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "&5]_4=_4=_4=_4=_4=_4=&5]",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "&5]_4=_4=_4=_4=_4=_4=&5]");

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceTriple,
            "ModularRamp (triple)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E3Boxed.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampTriple.png"
            );
    }



    void registerPrototype(
        ProtoRegistrator registrator,
        StaticEntityProto.ID protoID,
        string rampDescription,
        EntityLayout entityLayout,
        EntityCosts entityCosts,
        string prefab,
        string icon
        )
    {
        ProtosDb prototypesDb3 = registrator.PrototypesDb;

        StaticEntityProto.ID newID = protoID;
        Proto.Str str = Proto.CreateStr((Proto.ID)protoID, rampDescription, MRData.RAMPS_DESC);
        ImmutableArray<ToolbarEntryData>? categories = new ImmutableArray<ToolbarEntryData>?(registrator.GetCategoriesProtos(Ids.ToolbarCategories.Transports));
        LayoutEntityProto.Gfx graphics = new LayoutEntityProto.Gfx(prefab, customIconPath : icon, categories: categories, useInstancedRendering: false);
        MRPrototype newProto = new MRPrototype(newID, str, entityLayout, entityCosts, graphics);
        prototypesDb3.Add<MRPrototype>(newProto);

    }

    static MRData()
    {
        MRData.RAMPS_DESC = Loc.Str("VehicleRamp__desc", "Allows vehicles to cross obstacles such as transports.", "description for vehicle ramps");
    }

}
