using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    [SerializeField] GameObject train;
    [SerializeField] TerrainBlocks terrain;

    [SerializeField] float minSpawnDuration = 2;
    [SerializeField] float maxSpawnDuration = 4;

    bool isRight;
    float timer = 4;

    void Start()
    {
        isRight = Random.value > 0.5f ? true : false;
        timer = Random.Range(minSpawnDuration, maxSpawnDuration);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        timer = Random.Range(minSpawnDuration, maxSpawnDuration);

        var spawn = this.transform.position + 
        Vector3.right * (isRight ? -(terrain.Extend + 0.5f) : terrain.Extend + 0.5f);

        var go = Instantiate(
            original: train,
            position: spawn,
            rotation: Quaternion.Euler(0, isRight ? 90  : -90, 0),
            parent: this.transform
        );

        var trains = go.GetComponent<Train>();
        trains.Setup(terrain.Extend);
    }
}
