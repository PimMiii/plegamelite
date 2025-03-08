using Godot;
using System;

public partial class Killzone : Area2D
{
    private Timer timer;
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }
    private void _on_body_entered(Node body)
    {
        GD.Print("You died");
        timer.Start();

    }

    private void _on_timer_timeout()
    {
        GetTree().ReloadCurrentScene();
    }
}
