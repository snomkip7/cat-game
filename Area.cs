using Godot;
using System;

public partial class Area : Node2D
{
	[Export]
	public string name;

	public Label timer;
	public Global global;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Label>("Timer");
		global = GetNode<Global>("/root/Global");
		GetNode<CharacterBody2D>("Player").Position = global.playerPosition;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer.Text = ((int)global.timer/60)+":"+(int)global.timer%60+"."+(int)(global.timer*100)%100;
	}
}
