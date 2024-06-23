using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace SeaQuest.Scripts.Resources.BaseClass;
public partial class ObjectsPool : Resource
{
    [ExportGroup("Bullet Pool")]
    [Export]
    public PackedScene BulletScene { get; private set; }
    [Export]
    public int BulletPoolCount { get; private set; }

    public List<Bullet> BulletPool { get; private set; } = new List<Bullet>();
    
    
    public void FillThePool<T>(Node owner, T poolObject) where T : new()
    {
        switch (poolObject)
        {
            case Bullet bullet:
                for (int i = 0; i < BulletPoolCount; i++)
                {
                    bullet =  BulletScene.Instantiate() as Bullet;
                    BulletPool.Add(bullet);
                    
                    owner.AddChild(bullet);

                    bullet.SetProcess(false);
                    bullet.SetPhysicsProcess(false);
                    bullet.Hide();
                }
                break;

            default:
                break;
        }
    }


    public T GetObject<T>(T poolObject) where T : class
    {
        switch (poolObject)
        {
            case Bullet bullet:
                bullet = GetFromPool<Bullet>(BulletPool);
                return poolObject;    
            
            default:
                return null;
        }
    }


    private T GetFromPool<T>(List<T> pool) where T : class
    {
        foreach (T obj in pool)
        {
            if (obj != null)
            {
                return obj;
            }
        }

        return null;
    }
}