using Godot;
using System;
using System.Collections.Generic;

public partial class Item : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public string catColor = "tabby";
	public string itemName = "bean";
	public bool used = false;
	public override void _Ready()
	{
	}

	public void init(int pos, string color, string name){
		List<Vector2> posList = new List<Vector2>() {new Vector2(640,640)};
		Position = posList[pos];
		catColor = color;
		itemName = name;
	}

	public void inputEvent(Viewport viewport, InputEvent @event, int shapeidx){
		if (@event is InputEventMouseButton mouse && !used){
			Vector2 playerPos = GetNode<CharacterBody2D>("../Player").Position;
			Vector2 diff = (Position-playerPos).Abs();
			if(diff.X<=120 && diff.Y<=120){
				GD.Print("got clicked on");
				used = true;
				GetNode<Global>("/root/Global").enterHint(catColor, itemName, GetNode<CharacterBody2D>("../Player").Position);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
