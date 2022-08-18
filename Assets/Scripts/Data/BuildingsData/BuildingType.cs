using System;

namespace Data.BuildingsData
{
    public enum BuildingType
    {
        None,
        JumpingBuilding,
        PlatformBuilding,
        SprintBuilding,
        EconomistBuilding,
        SafetyBuilding
    }

    public static class BuildingTypeConverter
    {
        public static string ToId(this BuildingType type) => type.ToString();

        public static BuildingType BuildingTypeFromId(this string id) => Enum
            .TryParse(id, out BuildingType type) 
            ? type : BuildingType.None;
    }
}