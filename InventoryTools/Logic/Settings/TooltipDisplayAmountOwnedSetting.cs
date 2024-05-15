using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings
{
    public class TooltipDisplayAmountOwnedSetting : BooleanSetting
    {
        public override bool DefaultValue { get; set; } = true;
        
        public override bool CurrentValue(InventoryToolsConfiguration configuration)
        {
            return configuration.TooltipDisplayAmountOwned;
        }

        public override void UpdateFilterConfiguration(InventoryToolsConfiguration configuration, bool newValue)
        {
            configuration.TooltipDisplayAmountOwned = newValue;
        }

        public override string Key { get; set; } = "TooltipDisplayOwned";
        public override string Name { get; set; } = "Add Amount Owned";

        public override string WizardName { get; } = "Amount Owned";

        public override string HelpText { get; set; } =
            "When hovering an item, should the tooltip contain information about where the items are located.";

        public override SettingCategory SettingCategory { get; set; } = SettingCategory.ToolTips;
        public override SettingSubCategory SettingSubCategory { get; } = SettingSubCategory.Subsetting;
        public override string Version => "1.7.0.0";

        public TooltipDisplayAmountOwnedSetting(ILogger<TooltipDisplayAmountOwnedSetting> logger, ImGuiService imGuiService) : base(logger, imGuiService)
        {
        }
    }
}