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
        EntityLayoutParams layoutParams = new EntityLayoutParams(customTokens: (IEnumerable<CustomLayoutToken>)new CustomLayoutToken[23]
        {
           new CustomLayoutToken("C5]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(-2,
                                  3,
                                  LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                  minTerrainHeight: new int?(-2),
                                  maxTerrainHeight: new int?(0),
                                  vehicleHeight :  new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

           new CustomLayoutToken("D4]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(2,
                                  3,
                                  LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                  minTerrainHeight: new int?(-2),
                                  maxTerrainHeight: new int?(0),
                                  vehicleHeight : new Fix32?((Fix32)(2))))),
           new CustomLayoutToken("D1]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(0,
                                  1,
                                  minTerrainHeight: new int?(-4),
                                  maxTerrainHeight: new int?(0),
                                  vehicleHeight : new Fix32?((Fix32)(0))))),

           new CustomLayoutToken("C3]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ( (p, h) =>
             new LayoutTokenSpec(2,
                                  3,
                                  LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                  minTerrainHeight: new int?(-2),
                                  maxTerrainHeight: new int?(0),
                                  vehicleHeight :  new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),
                                  


#if false
          
          int heightToExcl = 5;
          int? terrainSurfaceHeight = new int?(0);
          Proto.ID? nullable = new Proto.ID?(p.HardenedFloorSurfaceId);
         // int? minTerrainHeight = new int?();
         int? minTerrainHeight = new int?();
          int? maxTerrainHeight = new int?();
          Fix32? vehicleHeight = new Fix32?();
          Proto.ID? terrainMaterialId = new Proto.ID?();
          Proto.ID? surfaceId = new Proto.ID?();
          LayoutTileConstraint lt =   LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
          return new LayoutTokenSpec(heightToExcl: heightToExcl, constraint : lt,
              minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
        })),
#endif
         new CustomLayoutToken("(M)", 
         (Func<EntityLayoutParams, int, LayoutTokenSpec>) (
           (p, h) => new LayoutTokenSpec(3, 
                                          4, 
                                          LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, 
                                          minTerrainHeight: new int?(-2), 
                                          maxTerrainHeight: new int?(0)))),
          new CustomLayoutToken("(W)", (Func<EntityLayoutParams, int, LayoutTokenSpec>) (
          (p, h) => new LayoutTokenSpec(-1,
                                         5, 
                                         LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, 
                                         minTerrainHeight: new int?(-2), 
                                         maxTerrainHeight: new int?(0)))),
                    new CustomLayoutToken("(R)", (Func<EntityLayoutParams, int, LayoutTokenSpec>) (
          (p, h) => new LayoutTokenSpec(-1,
                                         5,
                                         LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                                         minTerrainHeight: new int?(-2),
                                         vehicleHeight : new Fix32?((Fix32) (1)),
    maxTerrainHeight: new int?(0)))),


         new CustomLayoutToken("(0]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
        {
            int heightFrom = -1;
          int heightToExcl = h-1;
          int? terrainSurfaceHeight = new int?(0);
          Proto.ID? nullable = new Proto.ID?(p.HardenedFloorSurfaceId);
         // int? minTerrainHeight = new int?();
         int? minTerrainHeight = new int?(-1);
          int? maxTerrainHeight = new int?(1);
          Fix32? vehicleHeight = new Fix32?();
          Proto.ID? terrainMaterialId = new Proto.ID?();
          Proto.ID? surfaceId = new Proto.ID?();
          return new LayoutTokenSpec(heightFrom : heightFrom,heightToExcl: heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
        })),
                    new CustomLayoutToken("&0]", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
        {
          int heightToExcl = h;
          int? terrainSurfaceHeight = new int?(0);
          Proto.ID? nullable = new Proto.ID?(p.HardenedFloorSurfaceId);
         // int? minTerrainHeight = new int?();
         int? minTerrainHeight = new int?();
          int? maxTerrainHeight = new int?();
          Fix32? vehicleHeight = new Fix32?();
          Proto.ID? terrainMaterialId = new Proto.ID?();
          Proto.ID? surfaceId = new Proto.ID?();

          LayoutTileConstraint lt =   LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
          return new LayoutTokenSpec(heightToExcl: heightToExcl, constraint : lt,
              minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
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
                int? minTerrainHeight = new int?(-4);
                int? maxTerrainHeight = new int?(h - 1);
                Fix32? vehicleHeight = new Fix32?((Fix32) (h - 1));
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = new Proto.ID?();
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
        new CustomLayoutToken("$0_", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
        {
          int heightFrom = 0;
          int heightToExcl = 1;
          int? terrainSurfaceHeight = new int?();
          int? minTerrainHeight = new int?(-4);
          int? maxTerrainHeight = new int?(0);
          Fix32? vehicleHeight = new Fix32?((Fix32) (h - 1));
          Proto.ID? terrainMaterialId = new Proto.ID?();
          Proto.ID? surfaceId = new Proto.ID?();
          return new LayoutTokenSpec(
              heightFrom: heightFrom,
              heightToExcl: heightToExcl,
              terrainSurfaceHeight: terrainSurfaceHeight,
              minTerrainHeight: minTerrainHeight,
              maxTerrainHeight: maxTerrainHeight,
              vehicleHeight: vehicleHeight,
              terrainMaterialId: terrainMaterialId,
              surfaceId: surfaceId);
        })),
            new CustomLayoutToken("+0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightFrom = h - 1;
                int heightToExcl = h;
                int? terrainSurfaceHeight = new int?();
                int? minTerrainHeight = new int?(-h);
                int? maxTerrainHeight = new int?(h - 1);
                Fix32? vehicleHeight = new Fix32?((Fix32) (h - 1));
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = new Proto.ID?();
                return new LayoutTokenSpec(heightFrom, heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),
            new CustomLayoutToken("@0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightFrom = 0;
                int heightToExcl = 1;
                int? terrainSurfaceHeight = new int?();
                int? minTerrainHeight = new int?(0);
                int? maxTerrainHeight = new int?(0);
                Fix32? vehicleHeight = new Fix32?(0);
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = new Proto.ID?();
                return new LayoutTokenSpec(heightFrom, heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),


            new CustomLayoutToken("<R0", (Func<EntityLayoutParams, int, LayoutTokenSpec>)
                ((p, h) => new LayoutTokenSpec(heightToExcl: 1,
                minTerrainHeight : new int?(-2),
                maxTerrainHeight: new int?(4),
                surfaceId: new Proto.ID?(p.HardenedFloorSurfaceId),
                isRamp: true))),

            new CustomLayoutToken("<R1", (Func<EntityLayoutParams, int, LayoutTokenSpec>)
                ((p, h) => new LayoutTokenSpec(heightToExcl: 1,
                minTerrainHeight : new int?(-2),
                maxTerrainHeight: new int?(4),
                surfaceId: new Proto.ID?(),
                isRamp: true))),

            new CustomLayoutToken("<R2", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
            new LayoutTokenSpec(1, 2,  minTerrainHeight : new int?(-2), maxTerrainHeight: new int?(4), isRamp: true))),


            new CustomLayoutToken("<R3", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
            new LayoutTokenSpec(2, 3, minTerrainHeight : new int?(-3), maxTerrainHeight: new int?(2), isRamp: true))),

                        new CustomLayoutToken("<R4", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            new LayoutTokenSpec(3, 4, minTerrainHeight : new int?(-4), maxTerrainHeight: new int?(4), isRamp: true))),

            new CustomLayoutToken("=23", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
            new LayoutTokenSpec(1, 3, minTerrainHeight : new int?(-3),maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=24", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
            new LayoutTokenSpec(2, 4, minTerrainHeight : new int?(-4),maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => 
            new LayoutTokenSpec(3, 4, maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("+3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>)((p, h) => 
            new LayoutTokenSpec(3, 4,minTerrainHeight: -2, maxTerrainHeight: 1, vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))) }
          );

        EntityLayout newLayout;
        EntityCostsTpl entityCost;

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

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance2,
            "ModularRamp (Ramp 2)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance2.prefab",
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

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance,
            "ModularRamp (Ramp 3)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance3Stp1.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampEntrance.png"
            );

        // Entrance 4

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            //       "[1][1][2]=23=23=24=24=24=24&5]",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=",
            "_1_<R0<R1<R2<R2<R3<R3<R4<R4+5=+5=+5=+5=");
          //  "[1][1][2]=23=23=24=24=24=24&5]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance4,
            "ModularRamp (Ramp 4)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance4x.prefab",
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

        entityCost = new EntityCostsTpl.Builder().CP(10);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceSingle,
            "ModularRamp (Single)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E1Extended.prefab",
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

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceDouble,
            "ModularRamp (Double)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E2Extended.prefab",
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

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceTriple,
            "ModularRamp (Triple)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E3Extended.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampTriple.png"
            );


        //------------------------------------------------------------------------


        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,

           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4=",
           "_4=_4="
);



        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,

           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]",
           "D4]D4]"
);



        entityCost = new EntityCostsTpl.Builder().CP2(20).Concrete(40);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampCenter,
            "ModularRamp (Center)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
        //            "Assets/ModularRamp/Prefabs/CenterRoad2.prefab",
        "Assets/ModularRamp/Prefabs/Centerx.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampCenter.png"
            );
        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,

   "$4_$4_",
   "$4_$4_",
   "$4_$4_",
   "$4_$4_",
   "$4_$4_",
   "$4_$4_");

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,

"D1]D1]",
"D1]D1]",
"D1]D1]",
"D1]D1]",
"D1]D1]",
"D1]D1]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampTest5,
            "ModularRamp (singleY)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E1Boxed9.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle1.png"
            );



#if false

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "&5]=3-=3-=3-=3-=3-=3-&5]",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "&5]_4=_4=_4=_4=_4=_4=&5]");
        // uses already set entitycost

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceDouble,
            "ModularRamp (double)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E2.prefab",
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
        // uses already set entitycost
        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
"C5]D4]D4]D4]D4]D4]D4]C5]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"D4]D4]D4]D4]D4]D4]D4]D4]",
"C5]C3]C3]C3]C3]C3]C3]C5]");

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceTriple,
            "ModularRamp (triple)",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/E3Extended.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampTriple.png"
            );

        // used for testing purposes only



        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[1][1][2][2]=23=23=23&4]",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "_1_<R0<R1<R1<R2<R2<R2_3=",
            "[1][1][2][2]=23=23=23&4]");

        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampTest2,
            "ModularRamp Test2",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/TestCube11.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle.png"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
    "[1][1][2][2]=23=23=24=24=24=24=24=24=24&5]",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3<R4<R4<R4_5=",
    "[1][1][2][2]=23=23=24=24=24=24=24=24=24&5]");
  
       


        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampTest3,
            "ModularRamp Test3",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/TestCube1.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle.png"
            );



        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
"[1][1][2]=23=23&5]",
"_1_<R0<R1<R2<R2_3=",
"_1_<R0<R1<R2<R2_3=",
"_1_<R0<R1<R2<R2_3=",
"_1_<R0<R1<R2<R2_3=",
"_1_<R0<R1<R2<R2_3=",
"_1_<R0<R1<R2<R2_3=",
"[1][1][2]=23=23&5]");



        entityCost = new EntityCostsTpl.Builder().CP2(60).Concrete(200);

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampTest6,
            "ModularRamp Test5",
            newLayout,
            entityCost.MapToEntityCosts(registrator),
            "Assets/ModularRamp/Prefabs/Entrance2.prefab",
            "Assets/ModularRamp/Prefabs/ModularRampSingle1.png"
            );
#endif
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
