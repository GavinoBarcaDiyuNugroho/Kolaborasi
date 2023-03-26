using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map_Manager : MonoBehaviour
{
    private static Map_Manager _instance;
    public static Map_Manager Instance { get{ return _instance; } }

    public GameObject overlayTilePrefab;
    public GameObject TileOverlayContainer;

    // Start is called before the first frame update
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        BoundsInt boundsInt = tileMap.cellBounds;
        for(int z = boundsInt.max.z; z > boundsInt.min.z; z--)
        {
            for(int y = boundsInt.min.y; y < boundsInt.max.y; y++)
            {
                for(int x = boundsInt.min.x; x < boundsInt.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    if (tileMap.HasTile(tileLocation))
                    {
                        var overlayTile = Instantiate(overlayTilePrefab, TileOverlayContainer.transform);
                        var overlayTilePos = tileMap.GetCellCenterWorld(tileLocation);

                        overlayTile.transform.position = new Vector3(overlayTilePos.x, overlayTilePos.y, overlayTilePos.z + 1);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<SpriteRenderer>().sortingOrder;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
