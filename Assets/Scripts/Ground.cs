using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Ground : MonoBehaviour
{
    public int size = 200;

    public int seed = 0;
    public Vector2Int position = new Vector2Int(0,0);
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;

    void Start()
    {
        mesh = new Mesh();
        CreateShape();
        UpdateMesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void OnValidate() {
        Start();
    }

    private void CreateShape()
    {
        var vertexCount = (size+1) * (size+1);
        vertices = new Vector3[vertexCount];
        uvs = new Vector2[vertexCount];

        for (int z = 0; z < size + 1; z++) {
            for (int x = 0; x < size + 1; x++) {
                var index = getIndex(x, z);

                vertices[index] = new Vector3(x - size/2, 0, z - size/2);
                uvs[index] = new Vector2((float)x/size, (float)z/size);
            }
        }
        
        triangles = new int[6 * size * size];

        for (int z = 0; z < size; z++) {
            for (int x = 0; x < size; x++) {
                var triangleIndex = 6 * (x + (z*size));
                triangles[triangleIndex + 0] = getIndex(x, z);
                triangles[triangleIndex + 1] = getIndex(x, z+ 1);
                triangles[triangleIndex + 2] = getIndex(x+1, z);
                triangles[triangleIndex + 3] = getIndex(x+1, z);
                triangles[triangleIndex + 4] = getIndex(x, z+1);
                triangles[triangleIndex + 5] = getIndex(x+1, z+1);
            }
        }
    }
    private int getIndex(int x, int z) {
        return z * (size + 1) + x;
    }
    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}
