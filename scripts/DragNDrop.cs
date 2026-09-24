using Godot;
using System;

public partial class DragNDrop : Sprite2D
{ 
	private bool _isDragging = false; 
	// if the user's cursor is currently dragging clothing item/prop, defaults to false
	
	private Vector2 _dragOffset = Vector2.Zero; 
	// the distance between where you clicked inside the sprite and the sprite's center point.
	// NOTE set vector zero for now, maybe change it later
	
	public override void _Process(double delta)
	 {	// override: using C# to replace Godot's base_Process method (inherited from Node) with a new custom-made version.
		// called every frame, 'delta' is the elapsed time since the previous frame
		
		if (_isDragging)
		{// If actively dragging, follow the mouse position (accounting for offset)
			GlobalPosition = GetGlobalMousePosition() - _dragOffset;
		}
	}

	// FIXME Attach this method to the child Area2D's input_event signal in the Godot Inspector.
	public void _OnArea2DInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton mouseButtonEvent)
		{
			// Check if left mouse button is clicked
			if (mouseButtonEvent.ButtonIndex == MouseButton.Left)
			{
				if (mouseButtonEvent.Pressed)
				{
					_isDragging = true;
					// Calculate offset so the sprite doesn't awkwardly snap its center to the cursor
					_dragOffset = GetGlobalMousePosition() - GlobalPosition;
				}
				else
				{
					_isDragging = false;
				}
			}
		}
	}
}
