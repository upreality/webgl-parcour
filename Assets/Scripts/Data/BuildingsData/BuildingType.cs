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

    public static class BuildingTypeExtensions
    {
        public static string ToId(this BuildingType type) => type.ToString();

        public static BuildingType IdToBuildingType(this string id) => Enum
            .TryParse(id, out BuildingType type)
            ? type
            : BuildingType.None;

        private const string PurchaseCategoryIdPrefix = "BuildingLevelPurchases_";

        public static string ToPurchaseCategoryId(this BuildingType type) => PurchaseCategoryIdPrefix + type;

        public static BuildingType PurchaseCategoryIdToBuildingType(this string categoryId) => categoryId
            .Replace(PurchaseCategoryIdPrefix, "")
            .IdToBuildingType();
    }
}