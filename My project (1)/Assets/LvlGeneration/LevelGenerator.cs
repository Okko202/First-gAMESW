using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public Transform player;

    private List<GameObject> activeGrids = new List<GameObject> ();
    private float spawnPos = 0;
    private float gridLength = 66;
    private int startGrids = 3;

    private void Start()
    {
        for(int i = 0; i< startGrids; i++)
        {
            SpawnGrid(Random.Range(0, gridPrefabs.Length));
        }
    }

    private void Update()
    {

        if (player.position.x - 80> spawnPos - (startGrids * gridLength))
        {
            SpawnGrid(Random.Range(0, gridPrefabs.Length));
            DeleteGrid();
        }
    }
    private void SpawnGrid(int gridIndex)
    {
        GameObject nextGrid = Instantiate(gridPrefabs[gridIndex], transform.right * spawnPos, transform.rotation);
        activeGrids.Add(nextGrid);
        spawnPos += gridLength;
    }
    private void DeleteGrid() 
    {
        Destroy(activeGrids[0]);
        activeGrids.RemoveAt(0);
    }
}