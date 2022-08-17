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
        public static int ToId(this BuildingType type)
        {
            return type switch
            {
                BuildingType.None => -1,
                BuildingType.JumpingBuilding => 1,
                BuildingType.PlatformBuilding => 2,
                BuildingType.SprintBuilding => 3,
                BuildingType.EconomistBuilding => 4,
                BuildingType.SafetyBuilding => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static BuildingType BuildingTypeFromId(this int id)
        {
            return id switch
            {
                -1 => BuildingType.None,
                1 => BuildingType.JumpingBuilding,
                2 => BuildingType.PlatformBuilding,
                3 => BuildingType.SprintBuilding,
                4 => BuildingType.EconomistBuilding,
                5 => BuildingType.SafetyBuilding,
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
        }
    }
}