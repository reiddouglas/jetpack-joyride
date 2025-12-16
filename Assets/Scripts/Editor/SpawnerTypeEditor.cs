using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnerType))]
public class SpawnerTypeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw default inspector
        DrawDefaultInspector();

        // Reference to target ScriptableObject
        SpawnerType spawnerType = (SpawnerType)target;

        // Validation check
        if (spawnerType.prefab != null && spawnerType.prefab.GetComponent<Spawnable>() == null)
        {
            EditorGUILayout.HelpBox("Assigned prefab must contain a Spawnable component!", MessageType.Error);
        }
    }
}
