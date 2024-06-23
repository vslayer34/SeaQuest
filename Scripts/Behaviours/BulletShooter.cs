using Godot;
using SeaQuest.Scripts.Helper;
using SeaQuest.Scripts.Resources.BaseClass;
using System;

public partial class BulletShooter : Node2D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public ObjectsPool ObjectPool { get; private set; }

	private Bullet _firedBullet;



	// Game Loop Methods---------------------------------------------------------------------------
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(InputMapActions.InputAction.SHOOT))
		{
			Shoot();
		}
    }


	// Member Methods------------------------------------------------------------------------------

	private void Shoot()
	{
		_firedBullet = ObjectPool.GetBullet();

		_firedBullet.Position = GlobalPosition;
		_firedBullet.Rotation = GlobalRotation;

		// _firedBullet.Transform = GlobalTransform;
	}
}
