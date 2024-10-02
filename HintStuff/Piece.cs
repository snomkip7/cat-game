using Godot;
using System;

public partial class Piece : Node2D
{
	public bool dragging = false;
	public Vector2 offset;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(dragging){
			Position = GetGlobalMousePosition()+offset;
		}
	}

	public void init(string text, bool cat){
		GetNode<Label>("Text").Text = text;
		RandomNumberGenerator rng = new RandomNumberGenerator();
		Position = new Vector2(rng.RandfRange(200, 1720), rng.RandfRange(200, 880));
		GD.Print(Position);
		if(cat){
			GetNode<Sprite2D>("PieceSprite").Modulate = Color.Color8(255, 220, 120);
		}
	}

	public override void _UnhandledInput(InputEvent @event){
		if (@event is InputEventMouseButton mouse){
			if (!mouse.IsPressed() && dragging){
				dragging = false;
			}
		}
	}

	public void inputEvent(Viewport viewport, InputEvent @event, int shapeidx){
		if (@event is InputEventMouseButton mouse){
			if (mouse.IsPressed() && !dragging){
				dragging = true;
				offset = Position - GetGlobalMousePosition();
			}
		}
	}
}
