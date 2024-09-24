using Godot;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	public Vector2 playerPosition;
	public List<string> cats = new List<string>() {"orange", "black", "tortoise", "void", "gray"};
	public List<string> likes = new List<string>() {"boop", "belly", "bongo", "back", "hold"};
	public Dictionary<string, bool> catsFound = new Dictionary<string, bool>();
	public Dictionary<string, string> catLikes = new Dictionary<string, string>(); 
	public override void _Ready()
	{
	}

	public void startGame(){
		RandomNumberGenerator rng = new RandomNumberGenerator();
		for(int i=0;i<cats.Count;i++){
			catsFound[cats[i]] = false;
			catLikes[cats[i]] = likes[rng.RandiRange(0, likes.Count-1)];
		}
		// need to add hints spawn locations
	}

	
}
