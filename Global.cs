using Godot;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	public Vector2 playerPosition;
	public string area = "Enterance";
	public int numCats = 5;
	public float timer; // in seconds (300), now 180
	public bool playing = false;
	public int catsLeft;
	public string tempColor;
	public string tempCat;
	
	/*
	public Dictionary<string, bool> catsFound = new Dictionary<string, bool>();
	public Dictionary<string, string> catLikes = new Dictionary<string, string>(); */
	public List<Cat> cats = new List<Cat>();
	public override void _Ready()
	{
	}

    public override void _Process(double delta)
    {
        if(playing){
			timer -= (float) delta;
			if(timer <= 0){
				//game over
				GD.Print("game ova");
			}
		}
    }

    public void startGame(){
		// info to get from
		List<string> catColors = new List<string>() {"orange", "black", "tortoise", "void", "gray"};
		List<string> likes = new List<string>() {"boop", "bellyrubs", "bongo", "backpets", "holding"};
		List<int> locations = new List<int>() {1,2,3,4,5,6,7,8,9,10};
		List<int> hints = new List<int>() {1,2,3,4,5,6,7,8,9,10};

		// generating the things
		RandomNumberGenerator rng = new RandomNumberGenerator();
		for(int i=0;i<numCats;i++){
			int likeNum = rng.RandiRange(0, likes.Count-1);
			int locNum = rng.RandiRange(0, locations.Count-1);
			int hintNum = rng.RandiRange(0, hints.Count-1);
			Cat kitty = new Cat(catColors[i], likes[likeNum], locations[locNum], hints[hintNum]);
			cats.Add(kitty);
			likes.RemoveAt(likeNum);
			locations.RemoveAt(locNum);
			hints.RemoveAt(hintNum);
			GD.Print(kitty);
		}
		catsLeft = numCats;
		playing = true;
		timer = 180f;
		GetTree().ChangeSceneToFile("Entrance.tscn");
	}

	public void enterHint(string color, string name, Vector2 playerPos){
		playerPosition = playerPos;
		tempColor = color;
		tempCat = name;
		GetTree().ChangeSceneToFile("HintStuff/Hint.tscn");
	}

	public void setHint(Hint hint){
		hint.init(tempColor, tempCat);
	}
	
}
