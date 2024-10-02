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
			temp.init(cat.Substring(i,1).ToUpper(), true); 
			//GD.Print("initiated a piece");
			AddChild(temp);
		}
		for(int i=0;i<thing.Length;i++){
			Piece temp = piece.Instantiate<Piece>();
			temp.init(thing.Substring(i,1).ToUpper(), false);
			//GD.Print("initiated a piece");
			AddChild(temp);
		}
		PackedScene heartScene = ResourceLoader.Load<PackedScene>("HintStuff/Heart.tscn");
		Piece heart = heartScene.Instantiate<Piece>();
		heart.init("<3", false);
		AddChild(heart);
	}

	public void returnToMap(){
		GetTree().ChangeSceneToFile(global.area+".tscn");
	}
}
