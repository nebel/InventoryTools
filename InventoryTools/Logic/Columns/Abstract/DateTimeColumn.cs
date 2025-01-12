using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CriticalCommonLib.Crafting;
using CriticalCommonLib.Models;
using CriticalCommonLib.Sheets;
using ImGuiNET;
using InventoryTools.Extensions;
using NaturalSort.Extension;

namespace InventoryTools.Logic.Columns.Abstract
{
    public abstract class DateTimeColumn : Column<DateTime?>
    {
        public override string CsvExport(InventoryItem item)
        {
            return CurrentValue(item)?.ToString(CultureInfo.CurrentCulture) ?? "";
        }

        public override string CsvExport(ItemEx item)
        {
            return CurrentValue(item)?.ToString(CultureInfo.CurrentCulture) ?? "";
        }

        public override string CsvExport(SortingResult item)
        {
            return CurrentValue(item)?.ToString(CultureInfo.CurrentCulture) ?? "";
        }
        public override DateTime? CurrentValue(CraftItem currentValue)
        {
            return CurrentValue(currentValue.Item);
        }
        
        public override DateTime? CurrentValue(InventoryChange currentValue)
        {
            return CurrentValue(currentValue.InventoryItem);
        }
        
        public override IEnumerable<CraftItem> Filter(IEnumerable<CraftItem> items)
        {
            return items;
        }

        public override IEnumerable<CraftItem> Sort(ImGuiSortDirection direction, IEnumerable<CraftItem> items)
        {
            return items;
        }
        
        public virtual string EmptyText
        {
            get
            {
                return "N/A";
            }
        }
        public override void Draw(FilterConfiguration configuration, InventoryItem item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex, configuration);
        }
        public override void Draw(FilterConfiguration configuration, SortingResult item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex, configuration);
        }
        public override void Draw(FilterConfiguration configuration, ItemEx item, int rowIndex)
        {
            DoDraw(CurrentValue((ItemEx)item), rowIndex, configuration);
        }
        public override void Draw(FilterConfiguration configuration, CraftItem item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex, configuration);
        }
        public override void Draw(FilterConfiguration configuration, InventoryChange item, int rowIndex)
        {
            DoDraw(CurrentValue(item), rowIndex, configuration);
        }

        public override IEnumerable<ItemEx> Filter(IEnumerable<ItemEx> items)
        {
            return FilterText == "" ? items : items.Where(c =>
            {
                var currentValue = CurrentValue( c);
                if (currentValue == null)
                {
                    return false;
                }
                return currentValue.Value.PassesFilter(FilterText.ToLower());
            });
        }

        public override IEnumerable<InventoryItem> Filter(IEnumerable<InventoryItem> items)
        {
            var isChecked = FilterText != "";
            return FilterText == "" ? items : items.Where(c =>
            {
                var currentValue = CurrentValue(c);
                if (currentValue == null)
                {
                    return false;
                }
                return currentValue.Value.PassesFilter(FilterText.ToLower());
            });
        }

        public override IEnumerable<SortingResult> Filter(IEnumerable<SortingResult> items)
        {
            var isChecked = FilterText != "";
            return FilterText == "" ? items : items.Where(c =>
            {
                var currentValue = CurrentValue(c);
                if (currentValue == null)
                {
                    return false;
                }
                return currentValue.Value.PassesFilter(FilterText.ToLower());
            });
        }
        
        public override IEnumerable<InventoryChange> Filter(IEnumerable<InventoryChange> items)
        {
            var isChecked = FilterText != "";
            return FilterText == "" ? items : items.Where(c =>
            {
                var currentValue = CurrentValue(c);
                if (currentValue == null)
                {
                    return false;
                }
                return currentValue.Value.PassesFilter(FilterText.ToLower());
            });
        }

        public override IEnumerable<InventoryItem> Sort(ImGuiSortDirection direction, IEnumerable<InventoryItem> items)
        {
            return direction == ImGuiSortDirection.Ascending ? items.OrderBy(CurrentValue) : items.OrderByDescending(CurrentValue);
        }

        public override IEnumerable<ItemEx> Sort(ImGuiSortDirection direction, IEnumerable<ItemEx> items)
        {
            return direction == ImGuiSortDirection.Ascending ? items.OrderBy(CurrentValue) : items.OrderByDescending(CurrentValue);
        }

        public override IEnumerable<SortingResult> Sort(ImGuiSortDirection direction, IEnumerable<SortingResult> items)
        {
            return direction == ImGuiSortDirection.Ascending ? items.OrderBy(CurrentValue) : items.OrderByDescending(CurrentValue);
        }
        
        public override IEnumerable<InventoryChange> Sort(ImGuiSortDirection direction, IEnumerable<InventoryChange> items)
        {
            return direction == ImGuiSortDirection.Ascending ? items.OrderBy(CurrentValue) : items.OrderByDescending(CurrentValue);
        }

        public override IColumnEvent? DoDraw(DateTime? currentValue, int rowIndex,
            FilterConfiguration filterConfiguration)
        {
            ImGui.TableNextColumn();
            if (currentValue != null)
            {
                var formattedValue = currentValue.Value.ToString(CultureInfo.CurrentCulture);
                var columnWidth = ImGui.GetColumnWidth();
                var frameHeight = filterConfiguration.TableHeight / 2.0f;
                var calcText = ImGui.CalcTextSize(formattedValue);
                var textHeight = calcText.X >= columnWidth ? 0 : calcText.Y / 2.0f;
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + frameHeight - textHeight);
                ImGui.TextUnformatted(formattedValue);
            }
            else
            {
                ImGui.TextUnformatted(EmptyText);
            }

            return null;
        }

        public override void Setup(int columnIndex)
        {
            ImGui.TableSetupColumn(RenderName ?? Name, ImGuiTableColumnFlags.WidthFixed, Width, (uint)columnIndex);
        }
    }
}