using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileBuildable : MonoBehaviour
{
    public Tilemap groundTile;
    public List<GameObject> buildings;

    public int mainTreeQuantity;
    public int idBuilding;

    private void Start()
    {
        
        idBuilding = 0;
    }
    private void Update()
    {
        inputSetID();
        getTilePos();
    }
    void getTilePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilePos = groundTile.LocalToCell(mousePos);
            var centerTilePos = groundTile.GetCellCenterWorld(tilePos);
            centerTilePos+= new Vector3(0, 0, 5);
            Debug.Log(tilePos);
            Debug.Log("before: " +groundTile.GetColliderType(tilePos));
            
            if (groundTile.GetColliderType(tilePos) == Tile.ColliderType.None)
            {
                spawnBuilding(centerTilePos);
                groundTile.SetColliderType(tilePos, Tile.ColliderType.Sprite);
                
                Debug.Log("After: "+groundTile.GetColliderType(tilePos));
                Debug.Log("Build Complete");
            }
            else
            {
                Debug.Log("Already built!");
            }

        }
    }
    void spawnBuilding(Vector3 position)
    {
        GameObject building = Instantiate(buildings[idBuilding]);
        building.transform.position = position;
        
    }
    public void setIDbuilding(int id  )
    {
        Debug.Log("Set ID Building to = " + id);
        idBuilding = id;
    }
    void inputSetID()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            idBuilding = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            idBuilding = 1;
        }
    }
}
