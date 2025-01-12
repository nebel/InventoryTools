using Dalamud.Game.Gui;
using InventoryTools.Services.Interfaces;

namespace InventoryTools.Services;

public class GuiService : IGuiService
{
    private GameGui _gameGui;
    public GuiService(GameGui gameGui)
    {
        _gameGui = gameGui;
    }
    public ulong HoveredItem {
        get
        {
            return _gameGui.HoveredItem;
        }
        set
        {
            _gameGui.HoveredItem = value;
        }
    }
    public nint FindAgentInterface(string addonName)
    {
        return _gameGui.FindAgentInterface(addonName);
    }

    public unsafe nint GetUIModule()
    {
        return _gameGui.GetUIModule();
    }
}