using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float moveAmount = 64;
	public Timer moveTimer;
	public RayCast2D moveRay;

    public override void _Ready()
    {
        moveTimer = GetNode<Timer>("MoveTimer");
		moveRay = GetNode<RayCast2D>("MoveRay");
    }
		// add interactions
    public override void _PhysicsProcess(double delta)
	{
		Vector2 newPos = Position;
		if(Input.IsActionPressed("up") == Input.IsActionPressed("down")){}
		else if(Input.IsActionJustPressed("up") || (Input.IsActionPressed("up") && moveTimer.TimeLeft==0)){
			moveRay.TargetPosition = new Vector2(0, -moveAmount);
			moveRay.ForceRaycastUpdate();
			if(!moveRay.IsColliding()){
				newPos.Y -= moveAmount;
				moveTimer.Start();
			} else{
				GD.Print("no up cuz " + moveRay.GetCollider());
			}
		}
		else if(Input.IsActionJustPressed("down") || (Input.IsActionPressed("down") && moveTimer.TimeLeft==0)){
			moveRay.TargetPosition = new Vector2(0, moveAmount);
			moveRay.ForceRaycastUpdate();
			if(!moveRay.IsColliding()){
				newPos.Y += moveAmount;
				moveTimer.Start();
			} else{
				GD.Print("no down cuz " + moveRay.GetCollider());
			}
		}

		if(Input.IsActionPressed("left") == Input.IsActionPressed("right")){}
		else if(Input.IsActionJustPressed("left") || (Input.IsActionPressed("left") && moveTimer.TimeLeft==0)){
			moveRay.TargetPosition = new Vector2(-moveAmount, 0);
			moveRay.ForceRaycastUpdate();
			if(!moveRay.IsColliding()){
				newPos.X -= moveAmount;
				moveTimer.Start();
			} else{
				GD.Print("no left cuz " + moveRay.GetCollider());
			}
		}
		else if(Input.IsActionJustPressed("right") || (Input.IsActionPressed("right") && moveTimer.TimeLeft==0)){
			moveRay.TargetPosition = new Vector2(moveAmount, 0);
			moveRay.ForceRaycastUpdate();
			if(!moveRay.IsColliding()){
				newPos.X += moveAmount;
				moveTimer.Start();
			} else{
				GD.Print("no right cuz " + moveRay.GetCollider());
			}
		}
		Position = newPos;
	}
}
