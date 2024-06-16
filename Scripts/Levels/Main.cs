using Godot;
using SeaQuest.Scripts.Resources.BaseClass;
using System;

public partial class Main : Node2D
{
    [ExportCategory("Required References")]
    [Export]
    public ObjectsPool ObjectsPool { get; private set; }

    [Export]
    public PackedScene BulletScene { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        ObjectsPool.FillThePool<Bullet>(this,new Bullet());
    }
}
