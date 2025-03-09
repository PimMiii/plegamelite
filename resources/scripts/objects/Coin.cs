using Godot;
using System;

public partial class Coin : Area2D
{
    private void _on_body_entered(Node body)
    {
        QueueFree();
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }
}
