using Godot;
using System;
using System.Collections.Generic;

public partial class CatItem : StaticBody2D
{
	public Cat cat;
	public bool used = false;

	public void init(Cat kitty){
		List<Vector2> posList = new List<Vector2>() {new Vector2(224,288), new Vector2(352, 352), new Vector2(480, 352), new Vector2(1440, 288), new Vector2(1504,288), new Vector2(1568,352), new Vector2(1440,672), new Vector2(1248,672), new Vector2(288,800), new Vector2(224,736)};
		Position = posList[kitty.locationNum];
		cat = kitty;
		// set sprite here using cat stuff
		GetNode<Sprite2D>("CatSprite").Texture = ResourceLoader.Load<Texture2D>("Assets/"+cat.type+"Cat.png");
	}

	public override void _Ready()
	{
		//temp
		//cat = GetNode<Global>("/root/Global").cats[0];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void inputEvent(Viewport viewport, InputEvent @event, int shapeidx){
		if (@event is InputEventMouseButton mouse && !used && !cat.found){
			Vector2 playerPos = GetNode<CharacterBody2D>("../Player").Position;
			Vector2 diff = (Position-playerPos).Abs();
			if(diff.X<=120 && diff.Y<=120){
				GD.Print("cat got clicked on");
				used = true;
				GetNode<Global>("/root/Global").catInteraction(cat, GetNode<CharacterBody2D>("../Player").Position);
			}
		}
	}
}
