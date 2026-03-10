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

namespace ModularRampMod;

public class MRData : IModData
{
    public static readonly LocStr RAMPS_DESC;

    public void RegisterData(ProtoRegistrator registrator)
    {
        EntityLayoutParams layoutParams = new EntityLayoutParams(customTokens: (IEnumerable<CustomLayoutToken>)new CustomLayoutToken[12]
        {
            new CustomLayoutToken("=0=", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
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
                int? nullable4 = new int?(h - 1);
                Fix32? nullable5 = new Fix32?((Fix32) (h - 1));
                int? terrainSurfaceHeight = new int?();
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = nullable4;
                Fix32? vehicleHeight = nullable5;
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

            new CustomLayoutToken("=24", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(1, 4, maxTerrainHeight: new int?(1), vehicleHeight: new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value)))),

            new CustomLayoutToken("=3-", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(3, 4, maxTerrainHeight: new int?(1)))),

            new CustomLayoutToken(".0_", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightToExcl = h;
                int? terrainSurfaceHeight = new int?(0);
                Fix32? nullable1 = new Fix32?((Fix32) (h - 1));
                Proto.ID? nullable2 = new Proto.ID?(p.HardenedFloorSurfaceId);
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = new int?();
                Fix32? vehicleHeight = nullable1;
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = nullable2;
                return new LayoutTokenSpec(heightToExcl: heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),

            new CustomLayoutToken(".01", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightToExcl = h;
                int? terrainSurfaceHeight = new int?(0);
                Fix32? nullable1 = new Fix32?((Fix32) (h - 1) + (Fix32)(0.3));
                Proto.ID? nullable2 = new Proto.ID?(p.HardenedFloorSurfaceId);
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = new int?();
                Fix32? vehicleHeight = nullable1;
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = nullable2;
                return new LayoutTokenSpec(heightToExcl: heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),
            new CustomLayoutToken(".02", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) =>
            {
                int heightToExcl = h;
                int? terrainSurfaceHeight = new int?(0);
                Fix32? nullable1 = new Fix32?((Fix32) (h - 1)+ (Fix32)(0.3));
                Proto.ID? nullable2 = new Proto.ID?(p.HardenedFloorSurfaceId);
                int? minTerrainHeight = new int?();
                int? maxTerrainHeight = new int?();
                Fix32? vehicleHeight = nullable1;
                Proto.ID? terrainMaterialId = new Proto.ID?();
                Proto.ID? surfaceId = nullable2;
                return new LayoutTokenSpec(heightToExcl: heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
            })),

            new CustomLayoutToken ("L0L", (Func<EntityLayoutParams, int, LayoutTokenSpec>) ((p, h) => new LayoutTokenSpec(0, 2, maxTerrainHeight: new int?(4),  minTerrainHeight: new int?(0))))
            });

        EntityLayout newLayout;

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
            "[5][5][5][5][5][5][5][5][5][5][5]",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "_1_<R1<R1<R1<R2<R2<R2<R3<R3<R3_4_",
            "[5][5][5][5][5][5][5][5][5][5][5]");


        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntrance,
            "ModularRamp (entrance)",
            newLayout,
            EntityCosts.None,
            "Assets/ModularRamp/Prefabs/EntranceHlafPillarTextured.prefab"
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


        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampCenter,
            "ModularRamp (center)",
            newLayout,
            EntityCosts.None,
            "Assets/ModularRamp/Prefabs/CenterTexture.prefab"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,


           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5]_4=_4=_4=_4=_4=_4=_4=",
           "[5][5][5][5][5][5][5][5]");



        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceSingle,
            "ModularRamp (single)",
            newLayout,
            EntityCosts.None,
            "Assets/ModularRamp/Prefabs/Extension1HalfPillarTextured.prefab"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "[5][5][5][5][5][5][5][5]",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4=_4=_4=_4=_4=_4=_4=_4=",
           "_4__4__4__4__4__4__4__4_");

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceDouble,
            "ModularRamp (double)",
            newLayout,
            EntityCosts.None,
            "Assets/ModularRamp/Prefabs/Extension2HalfPillarTextured.prefab"
            );

        newLayout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams,
           "_4__4__4__4__4__4__4__4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4=_4=_4=_4=_4=_4=_4_",
           "_4__4__4__4__4__4__4__4_");

        registerPrototype(registrator,
            PrototypeIDs.LocalEntities.ModularRampEntranceTriple,
            "ModularRamp (triple)",
            newLayout,
            EntityCosts.None,
            "Assets/ModularRamp/Prefabs/Enxtension3HalfPlillarTextured.prefab"
            );
    }

    void registerPrototype(
        ProtoRegistrator registrator,
        StaticEntityProto.ID protoID,
        string rampDescription,
        EntityLayout entityLayout,
        EntityCosts entityCosts,
        string prefab
        )
    {
        ProtosDb prototypesDb3 = registrator.PrototypesDb;

        StaticEntityProto.ID newID = protoID;
        Proto.Str str = Proto.CreateStr((Proto.ID)protoID, rampDescription, MRData.RAMPS_DESC);
        ImmutableArray<ToolbarEntryData>? categories = new ImmutableArray<ToolbarEntryData>?(registrator.GetCategoriesProtos(Ids.ToolbarCategories.Transports));
        LayoutEntityProto.Gfx graphics = new LayoutEntityProto.Gfx(prefab, categories: categories, useInstancedRendering: false);
        MRPrototype newProto = new MRPrototype(newID, str, entityLayout, entityCosts, graphics);
        prototypesDb3.Add<MRPrototype>(newProto);

    }

    static MRData()
    {
        MRData.RAMPS_DESC = Loc.Str("VehicleRamp__desc", "Allows vehicles to cross obstacles such as transports.", "description for vehicle ramps");
    }

}
