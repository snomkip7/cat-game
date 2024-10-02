using Godot;
using System;

public partial class Petting : Node2D
{
	public Label timer;
	public Global global;
	public Cat cat;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Label>("Timer");
		global = GetNode<Global>("/root/Global");
		global.setPet(this);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer.Text = ((int)global.timer/60)+":"+(int)global.timer%60+"."+(int)(global.timer*100)%100;
	}

	public void init(Cat kitty){
		cat = kitty;
		GD.Print(cat);
	}

	public void returnToMap(){
		GetTree().ChangeSceneToFile(global.area+".tscn");
	}

	public void useItem(string item){
		if(item==cat.like){
			//win
			//play happy noise
			global.cats[cat.index].found = true;
			global.catsLeft--;
			//change scene to home
			returnToMap();
		} else{
			//angry noise
			// lose l bozo gg get wrecked
			global.playing = false;
			GetTree().ChangeSceneToFile("End.tscn");
		}
	}

	public void useBongo(){
		useItem("bongo");
	}
	public void useBoop(){
		useItem("boop");
	}
	public void useBellyrubs(){
		useItem("bellyrubs");
	}
	public void useStringToy(){
		useItem("stringtoy");
	}
	public void useHolding(){
		useItem("holding");
	}
	public void useMouseToy(){
		useItem("mousetoy");
	}

}
