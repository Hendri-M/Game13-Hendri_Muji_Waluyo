using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject planePrefab;
    [SerializeField] int spawnZPos = 20;
    [SerializeField] float timeOut = 20f;
    [SerializeField] float timer = 0;

    int playerLastMxTravel = 0;

    private void SpawnPlane(){
        player.enabled = false;
        var post = new Vector3(player.transform.position.x, 1, player.CurrentTravel + spawnZPos);
        var rotate = Quaternion.Euler(0, 180, 0);
        var planeObject = Instantiate(planePrefab, post, rotate);
        var planes = planeObject.GetComponent<Pesawat>();
        planes.SetupTarget(player);
    }

    private void Update(){
        // jika player bergerak
        if (player.MaxTravel != playerLastMxTravel)
        {
            // reset timer
            timer = 0;
            playerLastMxTravel = player.MaxTravel;
            return;
        }

        // jalankan timer jika afk
        if (timer < timeOut)
        {
            timer += Time.deltaTime;
            return;
        }

        // timeout player die
        if (player.isJump() == false && player.isAnimalDie == false)
            SpawnPlane();
    }
}
