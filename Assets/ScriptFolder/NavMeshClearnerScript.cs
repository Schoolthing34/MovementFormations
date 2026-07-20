using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

//made by kalineh from https://discussions.unity.com/t/cannot-clear-delete-any-navmesh-weird-bug/820400/3
//super cool and now just a free button nice
public class NavMeshClearnerScript : MonoBehaviour
{
    [MenuItem("Light Brigade/Debug/Force Cleanup NavMesh")]
    public static void ForceCleanupNavMesh()
    {
        if (Application.isPlaying)
            return;

        NavMesh.RemoveAllNavMeshData();
        Debug.Log("Hey you clicked it wait");
    }
}
