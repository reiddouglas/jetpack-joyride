using UnityEngine;

public class ChunkManager : Spawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn(new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
