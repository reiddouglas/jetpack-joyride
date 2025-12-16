using UnityEngine;

[CreateAssetMenu(menuName = "Spawner")]
public class SpawnerType : ScriptableObject
{
    [Tooltip("Prefab that contains a Spawnable component")]
    public GameObject prefab;
    public int initialSize;
    public PoolFactory.PoolType poolType;

    public Spawnable GetSpawnable()
    {
        return prefab != null ? prefab.GetComponent<Spawnable>() : null;
    }
}
