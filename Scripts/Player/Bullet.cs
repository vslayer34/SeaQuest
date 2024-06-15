using Godot;
using System;

public partial class Bullet : AnimatedSprite2D
{
    [ExportCategory("Properties")]
    [Export]
    private float _speed = 300.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _PhysicsProcess(double delta)
    {
        Position += Vector2.Right * _speed * (float)delta;
    }
}
