using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShockTrap : MonoBehaviour
{
    // Later, add scriptable objects for max height and width of cells for spawning

    [SerializeField] private GameObject shockCirclePrefab;
    [SerializeField] private GameObject shockArcPrefab;
    private List<GameObject> shockCircles = new List<GameObject>();
    private GameObject shockArc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        SpawnCircles(2);
        SpawnShockArc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        RandomizeCircles();
        ConnectCircles();
    }

    private void OnDisable()
    {
        
    }

    private void SpawnCircles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject shockCircle = Instantiate(shockCirclePrefab, Vector2.zero, Quaternion.identity);
            shockCircles.Add(shockCircle);
        }
    }

    private void SpawnShockArc()
    {
        shockArc = Instantiate(shockArcPrefab, Vector2.zero, Quaternion.identity);
    }

    private void RandomizeCircles()
    {
        foreach(GameObject circle in shockCircles)
        {
            //TODO change this so multiple traps do not overlap - use a grid system?
            circle.transform.position = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
        }
    }

    private void ConnectCircles()
    {
        if (shockCircles.Count < 2 || shockArc == null) return;

        Vector3 posA = shockCircles[0].transform.position;
        Vector3 posB = shockCircles[1].transform.position;

        // --- LINE RENDERER ---
        LineRenderer line = shockArc.GetComponent<LineRenderer>();
        if (line != null)
        {
            line.positionCount = 2;
            line.SetPosition(0, posA);
            line.SetPosition(1, posB);
        }

        // --- EDGE COLLIDER 2D ---
        EdgeCollider2D edge = shockArc.GetComponent<EdgeCollider2D>();
        if (edge != null)
        {
            // Convert to Vector2 array
            Vector2[] points = new Vector2[2];
            points[0] = posA;
            points[1] = posB;
            edge.points = points;
        }

        // Optional: move shockArc object to origin of first circle (or 0,0)
        shockArc.transform.position = Vector3.zero;
    }
}
