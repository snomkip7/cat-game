using Godot;
using System;

public partial class Hint : Node2D
{
	public Label timer;
	public Global global;
	public PackedScene piece;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Label>("Timer");
		global = GetNode<Global>("/root/Global");
		piece = ResourceLoader.Load<PackedScene>("HintStuff/Piece.tscn");
		global.setHint(this);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer.Text = ((int)global.timer/60)+":"+(int)global.timer%60+"."+(int)(global.timer*100)%100;
	}
	
	public void init(string cat, string thing){
		for(int i=0;i<cat.Length;i++){
			Piece temp = piece.Instantiate<Piece>();
			temp.init("icon.svg"); // needs to be updated to show sprite
			//GD.Print("initiated a piece");
			AddChild(temp);
		}
		for(int i=0;i<thing.Length;i++){
			Piece temp = piece.Instantiate<Piece>();
			temp.init("icon.svg"); // needs to be updated to show sprite
			//GD.Print("initiated a piece");
			AddChild(temp);
		}
	}

	public void returnToMap(){
		GetTree().ChangeSceneToFile(global.area+".tscn");
	}
}
