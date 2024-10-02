using Godot;
using System;

public partial class End : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global global = GetNode<Global>("/root/Global");
		if(global.catsLeft == 0){
			GetNode<Label>("Lose").Visible = false;
			GetNode<Label>("Win").Visible = true;	
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void restart(){
		Global global = GetNode<Global>("/root/Global");
		global.catsLeft = global.numCats;
		global.timer = 10000f;
		GetTree().ChangeSceneToFile("StartMenu.tscn");
	}
}
