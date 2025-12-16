using UnityEngine;

public class Chunk : Spawnable
{
    public float speed = 1.0f;
    private float chunkWidth;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        chunkWidth = GetComponent<BoxCollider>().bounds.size.x;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        float leftCameraEdge =
            cam.transform.position.x -
            cam.orthographicSize * cam.aspect;

        if (transform.position.x + chunkWidth < leftCameraEdge)
        {
            RequestDespawn();
        }
    }

    public override void OnSpawn()
    {
        // Add hazards, pickups, enemies
    }

    public override void OnDespawn()
    {
        // Cleanup spawned objects
    }
}
