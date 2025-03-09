using Godot;
using System;
using System.Net;
public partial class Slime : Node2D
{
	[Export(PropertyHint.Range, "0,100,1")]
	public float speed = 60f;
	private int _direction = 1;
	[Export(PropertyHint.Enum, "Left,Right")]
	private int startingDirection = 1;

	private RayCast2D _raycastRight;
	private RayCast2D _raycastLeft;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_raycastRight = GetNode<RayCast2D>("Raycasts/RayCastRight");
		_raycastLeft = GetNode<RayCast2D>("Raycasts/RayCastLeft");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		_direction = startingDirection == 0 ? -1 : 1;
		if (_direction == -1) _animatedSprite.FlipH = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// check directional collision
		if (_raycastRight.IsColliding())
		{
			GD.Print("Collision to the Right", this);
			_animatedSprite.FlipH = true;
			_direction = -1;
		}
		if (_raycastLeft.IsColliding())
		{
			GD.Print("Collision to the Left", this);
			_animatedSprite.FlipH = false;
			_direction = 1;
		}

		// move along x-axis
		Position += new Vector2(speed * _direction, 0) * (float)delta;
	}
}
