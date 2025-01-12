using System.Collections.Generic;
using CriticalCommonLib.Crafting;
using CriticalCommonLib.Extensions;
using CriticalCommonLib.Models;
using CriticalCommonLib.Sheets;
using InventoryTools.Logic.Filters.Abstract;
using InventoryTools.Logic.Settings.Abstract;

namespace InventoryTools.Logic.Filters;

public class CraftHouseVendorFilter : ChoiceFilter<HouseVendorSetting>
{
    public override HouseVendorSetting CurrentValue(FilterConfiguration configuration)
    {
        return configuration.CraftList.HouseVendorSetting;
    }

    public override void ResetFilter(FilterConfiguration configuration)
    {
        UpdateFilterConfiguration(configuration, DefaultValue);
    }

    public override void UpdateFilterConfiguration(FilterConfiguration configuration, HouseVendorSetting newValue)
    {
        configuration.CraftList.HouseVendorSetting = newValue;
        configuration.NotifyConfigurationChange();
    }

    public override string Key { get; set; } = "CraftHouseVendor";
    public override string Name { get; set; } = "Group House Vendors By";

    public override string HelpText { get; set; } =
        "How should house vendor items be grouped?";

    public override FilterCategory FilterCategory { get; set; } = FilterCategory.Basic;
    public override HouseVendorSetting DefaultValue { get; set; } = HouseVendorSetting.Together;
    public override FilterType AvailableIn { get; set; } = FilterType.CraftFilter;
    public override bool? FilterItem(FilterConfiguration configuration, InventoryItem item)
    {
        return null;
    }

    public override bool? FilterItem(FilterConfiguration configuration, ItemEx item)
    {
        return null;
    }

    public override List<HouseVendorSetting> GetChoices(FilterConfiguration configuration)
    {
        return new List<HouseVendorSetting>()
        {
            HouseVendorSetting.Together,
            HouseVendorSetting.Separate
        };
    }

    public override string GetFormattedChoice(HouseVendorSetting choice)
    {
        return choice.ToString();
    }
}