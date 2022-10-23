using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject trees;
    [SerializeField] TerrainBlocks terrain;

    [SerializeField] int count = 3;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> emptyPost = new List<Vector3>();

        for (int i = -terrain.Extend; i< terrain.Extend; i++)
        {
            if (transform.position.z == 0 && i == 0)
            {
                continue;
            }
            emptyPost.Add(transform.position + Vector3.right * i);
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, emptyPost.Count);
            var spawnPost = emptyPost[index];

            Instantiate(trees, spawnPost, Quaternion.identity, this.transform);
            emptyPost.RemoveAt(index);
        }

        Instantiate(trees, transform.position + Vector3.right * -(terrain.Extend + 1), Quaternion.identity, this.transform);
        Instantiate(trees, transform.position + Vector3.right * (terrain.Extend + 1), Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
