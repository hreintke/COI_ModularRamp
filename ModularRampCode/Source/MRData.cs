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
        EntityLayoutParams layoutParams = new EntityLayoutParams(customTokens: (IEnumerable<CustomLayoutToken>)new CustomLayoutToken[]
        {
           new CustomLayoutToken("C5]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(heightFrom : -2,
                                 heightToExcl : 3,
                                 LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                 minTerrainHeight: new int?(-2),
                                 maxTerrainHeight: new int?(0),
                                 vehicleHeight :  new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

           new CustomLayoutToken("D4]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(heightFrom : 2,
                                 heightToExcl :3,
                                 LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                 minTerrainHeight: new int?(-2),
                                 maxTerrainHeight: new int?(2),
                                 vehicleHeight : new Fix32?((Fix32)(2))))),

           new CustomLayoutToken("C3]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(heightFrom : 2,
                                  heightToExcl : 3,
                                  LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                  minTerrainHeight: new int?(-2),
                                  maxTerrainHeight: new int?(2),
                                  vehicleHeight :  new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("&0]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : 0,
                                 heightToExcl : h,
                                 maxTerrainHeight : new int?(h-1)
                                 ))),

            new CustomLayoutToken("_0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : h - 1,
                                  heightToExcl : h,
                                  maxTerrainHeight : new int?(h - 1),
                                  vehicleHeight : new Fix32?((Fix32) (h - 1))))),

             new CustomLayoutToken("<U0", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : (h==0) ? 0 : h - 1,
                                  heightToExcl: (h==0)? 1 : h,
                                  surfaceId: (h==0) ? new Proto.ID?(p.HardenedFloorSurfaceId) : new Proto.ID?(),
                                  isRamp: true))),


            new CustomLayoutToken("<R0", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightToExcl: 1,
                                  surfaceId: new Proto.ID?(p.HardenedFloorSurfaceId),
                                  isRamp: true))),

            new CustomLayoutToken("<R1", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightToExcl: 1,
                                  surfaceId: new Proto.ID?(),
                                  isRamp: true))),

            new CustomLayoutToken("<R2", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightFrom : 1, 
                                  heightToExcl : 2, 
                                  maxTerrainHeight: new int?(1), 
                                  isRamp: true))),

            new CustomLayoutToken("<R3", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightFrom : 2,
                                  heightToExcl : 3, 
                                  maxTerrainHeight: new int?(2), 
                                  isRamp: true))),

            new CustomLayoutToken("<R4", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : 3, 
                                  heightToExcl : 4, 
                                  maxTerrainHeight: new int?(3), 
                                  isRamp: true))),
            new CustomLayoutToken("<R5", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : 4,
                                  heightToExcl : 5,
                                  maxTerrainHeight: new int?(4),
                                  isRamp: true))),
            new CustomLayoutToken("<R6", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
              new LayoutTokenSpec(heightFrom : 5,
                                  heightToExcl : 6,
                                  maxTerrainHeight: new int?(5),
                                  isRamp: true))),

            new CustomLayoutToken("=23", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightFrom : 1, 
                                  heightToExcl : 3, 
                                  maxTerrainHeight: new int?(2), 
                                  vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=24", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightFrom : 2, 
                                  heightToExcl : 4, 
                                  maxTerrainHeight: new int?(3), 
                                  vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
              new LayoutTokenSpec(heightFrom : 3, 
                                  heightToExcl : 4, 
                                  maxTerrainHeight: new int?(3), 
                                  vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("+3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>)((p, h) => 
              new LayoutTokenSpec(heightFrom : 3, 
                                  heightToExcl : 4,
                                  minTerrainHeight: -2, 
                                  maxTerrainHeight: 3, 
                                  vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))) }
          );

        EntityLayout newLayout;
        EntityCostsTpl entityCost;

        // Entrance 1

        // Entrance 1

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2]&4]",
            "_1_<R0<R1_2=",
            "_1_<R0<R1_2=",
            "_1_<R0<R1_2=",
            "_1_<R0<R1_2=",
            "_1_<R0<R1_2=",
            "_1_<R0<R1_2=",
            "[1][1][2]&4]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(100);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance1,
            "ModularRamp (Ramp 1)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance1BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        // Entrance 2

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2]=23=23&5]",
            "_1_<R0<R1<R2<R2_3=",
            "_1_<R0<R1<R2<R2_3=",
            "_1_<R0<R1<R2<R2_3=",
            "_1_<R0<R1<R2<R2_3=",
            "_1_<R0<R1<R2<R2_3=",
            "_1_<R0<R1<R2<R2_3=",
            "[1][1][2]=23=23&5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(100);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance2,
            "ModularRamp (Ramp 2)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance2BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        // Entrance 3

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2]=23=23=24=24&5]",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "_1_<R0<R1<R2<R2<R3<R3_4=",
            "[1][1][2]=23=23=24=24&5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(120);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance,
            "ModularRamp (Ramp 3)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance3BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        // Entrance 4

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2]=23=23=24=24=24=24&5]",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4_5=",
            "[1][1][2]=23=23=24=24=24=24&5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(140);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance4,
            "ModularRamp (Ramp 4)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance4BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
    "[1][1][2]=23=23=24=24=24=24&5]&6]&6]&6]&7]",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "_1_<R0<R1<R2<R2<R3<R3<R4<R4<R5<R5<R6<R6_7=",
    "[1][1][2]=23=23=24=24=24=24&5]&6]&6]&6]&7]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(140);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance6,
            "ModularRamp (Ramp 6)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance6BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        // Extension Single

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "C5]D4]D4]D4]D4]D4]C5]C5]",
            "D4]D4]D4]D4]D4]D4]C5]C5]",
            "D4]D4]D4]D4]D4]D4]C3]C3]",
            "D4]D4]D4]D4]D4]D4]C3]C3]",
            "D4]D4]D4]D4]D4]D4]C3]C3]",
            "D4]D4]D4]D4]D4]D4]C3]C3]",
            "C5]C5]C3]C3]C3]C3]C5]C5]",
            "C5]C5]C3]C3]C3]C3]C5]C5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceSingle,
            "ModularRamp (Single)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Extension1BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle.png"
        );

        // Extension Double 

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "C5]D4]D4]D4]D4]D4]D4]C5]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "C5]C5]C3]C3]C3]C3]C5]C5]",
            "C5]C5]C3]C3]C3]C3]C5]C5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceDouble,
            "ModularRamp (Double)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Extension2BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampDouble.png"
            );

        // Extension Triple

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "C5]D4]D4]D4]D4]D4]C3]C5]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "D4]D4]D4]D4]D4]D4]D4]D4]",
            "C3]D4]D4]D4]D4]D4]D4]C3]",
            "C5]D4]D4]D4]D4]D4]C3]C5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceTriple,
            "ModularRamp (Triple)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Extension3BakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampTriple.png"
            );


        //------------------------------------------------------------------------


        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "C3]C3]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "C3]C3]");

        entityCost = new EntityCostsTpl.Builder().CP2(20).Concrete(40);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampCenter,
            "ModularRamp (Center Double)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/CenterBakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampCenter.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "C3]",
            "D4]",
            "D4]",
            "D4]",
            "D4]",
            "D4]",
            "D4]",
            "C3]");

        entityCost = new EntityCostsTpl.Builder().CP2(20).Concrete(40);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampCenterSingle,
            "ModularRamp (Center Single)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/CenterSingleBakedCollider.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampCenter.png"
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
