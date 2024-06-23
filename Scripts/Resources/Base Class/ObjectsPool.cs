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
    
    
    /// <summary>
    /// Create the pool and fill it with the relavent objects
    /// </summary>
    /// <param name="owner">The Parent node</param>
    /// <param name="poolObject">The object to be created</param>
    /// <typeparam name="T"></typeparam>
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

                    EnablePoolObject<Bullet>(bullet, false);
                }
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Get a bullet from the bullet pool
    /// </summary>
    /// <returns>stored bullet fint the pool</returns>
    public Bullet GetBullet() => GetFromPool<Bullet>(BulletPool);


    /// <summary>
    /// Get an item form the pool and enable it
    /// </summary>
    /// <param name="pool">The pool that contains the objects</param>
    /// <typeparam name="T">The type of the objects to be returned</typeparam>
    /// <returns>an enabled version of the pool</returns>
    private T GetFromPool<T>(List<T> pool) where T : Node2D
    {
        foreach (T obj in pool)
        {
            if (obj != null)
            {
                pool.Remove(obj);
                EnablePoolObject<T>(obj, true);
                return obj;
            }
        }

        return null;
    }


    /// <summary>
    /// Enable/Disable the visibility and both normal process and physical process
    /// </summary>
    /// <param name="poolObject">The target object</param>
    /// <param name="enabled">The stats of the object enabled or disabled</param>
    /// <typeparam name="T">Any object that inherits Node2D</typeparam>
    private void EnablePoolObject<T>(T poolObject, bool enabled) where T : Node2D
    {
        poolObject.SetProcess(enabled);
        poolObject.SetPhysicsProcess(enabled);
        poolObject.Visible = enabled;
    }

}