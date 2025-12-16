using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour, ISpawner
{
    private IPool pool;
    private readonly List<Spawnable> active = new();

    [SerializeField] protected SpawnerType spawnerType;


    protected virtual void Awake()
    {
        pool = PoolFactory.CreatePool(
            spawnerType.GetSpawnable(),
            spawnerType.initialSize,
            spawnerType.poolType
        );
    }

    public Spawnable Spawn(Vector2 position, Quaternion rotation)
    {
        Spawnable obj = pool.Get();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.OnDespawnRequested += Despawn;
        obj.OnSpawn();
        active.Add(obj);
        return obj;
    }

    public void Despawn(Spawnable obj)
    {
        obj.OnDespawn();
        obj.OnDespawnRequested -= Despawn;
        pool.Return(obj);
        active.Remove(obj);
    }

    public void DespawnAll()
    {
        foreach (Spawnable obj in active)
        {
            Despawn(obj);
        }
    }
}
