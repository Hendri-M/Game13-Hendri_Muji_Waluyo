using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject sideWalk;
    [SerializeField] GameObject rail;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] int extend = 7;
    [SerializeField] int frontDistance = 10;
    [SerializeField] int backDistance = -5;
    [SerializeField] int maxSameTerrainRandom = 3;

    TMPro.TMP_Text gameOverScore;

    Dictionary<int, TerrainBlocks> map = new Dictionary<int, TerrainBlocks>(50);


    void Start()
    {
        // Set panel off
        gameOverPanel.SetActive(false);
        gameOverScore = gameOverPanel.GetComponentInChildren<TMPro.TMP_Text>();

        // Set terrain
        for (int z = backDistance; z <= 0; z++)
        {
            CreateTerrain(sideWalk, z);
        }

        for (int z = 1; z <= frontDistance; z++)
        {
            var prefab = GetNextRandomTerrainInPrefabs(z);

            // Instantiate bloknya
            CreateTerrain(prefab, z);
        }

        foreach (var pos in Tree.AllPosition)
        {
            Debug.Log(pos);
        }

        player.Setup(backDistance, extend);
    }

    private int playerLastMaxTravel;
    void Update()
    {
        if (player.isAnimalDie && gameOverPanel.activeInHierarchy == false)
            StartCoroutine(GameOver());

        // Infinite Terrain
        if (player.MaxTravel == playerLastMaxTravel)
            return;

        playerLastMaxTravel = player.MaxTravel;

        // Membuat Terrain ke Depan
        var randomTbPrefabs = GetNextRandomTerrainInPrefabs(player.MaxTravel + frontDistance);
        CreateTerrain(randomTbPrefabs, player.MaxTravel+frontDistance);
        
        // Hapus Terrain belakang
        TerrainBlocks lastTb = map[player.MaxTravel + frontDistance];
        int lastPost = player.MaxTravel;

        foreach (var (pos, tb) in map)
        {
            if(pos < lastPost)
            {
                lastPost = pos;
                lastTb = tb;
            }
        }

        // Hapus dari daftar list
        map.Remove(player.MaxTravel - 1 + backDistance);

        // Hilangkan Gameobject pada posisi tertentu {player.MaxTravel - 1 + backDistance}
        Destroy(lastTb.gameObject);

        // Player tidak bisa bergerak batas belakang
        player.Setup(player.MaxTravel + backDistance, extend);
    }

    private void CreateTerrain(GameObject prefab, int zPos)
    {
        var go = Instantiate(prefab, new Vector3(0, 0, zPos), Quaternion.identity);
        var tb = go.GetComponent<TerrainBlocks>();
        tb.Build(extend);

        map.Add(zPos, tb);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        gameOverScore.text = "Your Score :\n" + player.MaxTravel;
        gameOverPanel.SetActive(true);
    }

    private GameObject GetNextRandomTerrainInPrefabs(int pos)
    {
        bool IsUniform = true;
        var tbRef = map[pos - 1];

        for (int i = 2; i <= maxSameTerrainRandom; i++)
        {
            if (map[pos - i].GetType() != tbRef.GetType())
            {
                IsUniform = false;
                break;
            }
        }

        if (IsUniform)
        {
            if (tbRef is Sidewalk)
                return rail;
            else
                return sideWalk;
        }

        // Penentu terrain random dengan probabilitas 50%
        return UnityEngine.Random.value > 0.5f ? rail : sideWalk;
    }

    // Scene Load
    public void LoadScene()
    {
        LoadScenes.Load("MainMenu");
    }

    public void Replay()
    {
        LoadScenes.Replay();
    }

    public void Setting()
    {
        LoadScenes.Load("Settings");
    }
}
