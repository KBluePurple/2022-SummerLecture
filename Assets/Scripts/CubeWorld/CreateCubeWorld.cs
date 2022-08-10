using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeWorld : MonoBehaviour
{
    public int width;
    public int depth;
    public GameObject cubePrefab;

    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 position = new Vector3(x, Mathf.PerlinNoise(x * 0.1f, z * 0.1f) * 10, z);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cube.name = "Cube " + x + "," + z;
            }
        }
    }
}
