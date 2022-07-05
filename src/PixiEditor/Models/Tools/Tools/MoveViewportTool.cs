﻿using System.Windows.Input;
using ChunkyImageLib.DataHolders;
using PixiEditor.Models.Commands.Attributes;

namespace PixiEditor.Models.Tools.Tools;

[Command.Tool(Key = Key.H, Transient = Key.Space)]
public class MoveViewportTool : ReadonlyTool
{
    public MoveViewportTool()
    {
        Cursor = Cursors.SizeAll;
        ActionDisplay = "Click and move to pan viewport.";
    }

    public override bool HideHighlight => true;
    public override string Tooltip => $"Move viewport. ({Shortcut})";

    public override void Use(VecD pos)
    {
        // Implemented inside Zoombox.xaml.cs
    }
}
