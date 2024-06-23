using Godot;
using SeaQuest.Scripts.Helper;
using System;

namespace SeaQuest.Scripts.Player;
public partial class Player : AnimatedSprite2D
{
    [ExportCategory("Player Properties")]
    [Export]
    private float _speed = 50.0f;

    [Export]
    public BulletShooter BulletShooterComponent { get; private set; }


    private Vector2 _velocity;

    private const double IDLE_ANIMATION_SPEED = 5.0;

    private readonly Vector2 _faceingRightBulletSpawnerPosition = new Vector2(13, 2);
    private readonly Vector2 _faceingLeftBulletSpawnerPosition = new Vector2(-13, 2);



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
            SpriteFrames.SetAnimationSpeed(AnimationsNames.Player.DEFAULT, IDLE_ANIMATION_SPEED * 2);

            GlobalPosition += _velocity.Normalized() * _speed * (float)delta;

            if (_velocity.X == 0)
            {
                return;
            }
            else
            {
                FlipH = _velocity.X < 0;
                RotateShootingPoints(_velocity.X > 0);
            }
        }
        else
        {
            SpriteFrames.SetAnimationSpeed(AnimationsNames.Player.DEFAULT, IDLE_ANIMATION_SPEED);
        }
    }


    private void RotateShootingPoints(bool facingRight)
    {
        if (facingRight)
        {
            BulletShooterComponent.Position = _faceingRightBulletSpawnerPosition;
            BulletShooterComponent.RotationDegrees = 0.0f;
        }
        else
        {
            BulletShooterComponent.Position = _faceingLeftBulletSpawnerPosition;
            BulletShooterComponent.RotationDegrees = 180.0f;
        }
    }
}