using Godot;
using SeaQuest.Scripts.Helper;
using System;

namespace SeaQuest.Scripts.Player;
public partial class Player : AnimatedSprite2D
{
    [ExportCategory("Player Properties")]
    [Export]
    private float _speed = 50.0f;


    private Vector2 _velocity;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Input(InputEvent @event)
    {
        _velocity.X = Input.GetAxis(
            InputMapActions.InputAction.MOVE_LEFT, 
            InputMapActions.InputAction.MOVE_RIGHT
        );

        _velocity.Y = Input.GetAxis(
            InputMapActions.InputAction.MOVE_UP,
            InputMapActions.InputAction.MOVE_DOWN
        );
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_velocity != Vector2.Zero)
        {
            GlobalPosition += _velocity.Normalized() * _speed * (float)delta;
        }
    }
}
