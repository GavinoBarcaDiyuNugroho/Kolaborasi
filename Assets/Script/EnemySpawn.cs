using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
    [Header("Enemy Types")]
    [SerializeField]
    private GameObject enemyPrefab;
    [Space(2)]

    [Header("Spawn System")]
    [SerializeField]
    private float spawnTimer = 0f;
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private List<Vector3> availablePlaces;

    void Start()
    {
        FindLocationsOfTiles();
    }

    private void FindLocationsOfTiles()
    {
        availablePlaces = new List<Vector3>(); // create a new list of vectors by doing...

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++) // scan from left to right for tiles
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++) // scan from bottom to top for tiles
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tileMap.transform.position.y); // if you find a tile, record its position on the tile map grid
                Vector3 place = tileMap.CellToWorld(localPlace); // convert this tile map grid coords to local space coords
                if (tileMap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, 0.05f);


    }

    private void SpawnEnemy()
    {
        if (spawnTimer > 2)
        {
            for (int i = 0; i < availablePlaces.Count; i++)
            {
                // spawn prefab at the vector's position which is at the availablePlaces location and add 0.5f units as the bottom left
                // of the CELL (square) is (0,0), the top right of the CELL (square) is (1,1) therefore, the middle is (0.5,0.5)
                Instantiate(enemyPrefab, new Vector3(availablePlaces[i].x + 0.5f, availablePlaces[i].y + 0.5f, availablePlaces[i].z), Quaternion.identity);
            }
            spawnTimer = 0f;
        }
    }
}
