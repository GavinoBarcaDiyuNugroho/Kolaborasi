using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Build_Management : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mainTree;
    public Tilemap buildable;
    public GameObject buildableTile;

    void Start()
    {
        makingFormat();
        screenMouseRay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void makingFormat()
    {
        int vision = 1;
        int counter = 0;
        Vector3Int basedTile = buildable.WorldToCell(mainTree.transform.position);
        for (int x = -vision; x <= 0; x++)
        {
            float holder = -0.4f;
            for (int y = -vision; y <= vision; y++)
            {
                float xPos = x;
                float yPos = y;
                counter++;
                GameObject builtTile = Instantiate(buildableTile);
                if (counter % 2 == 1)
                {
                    builtTile.transform.position = new Vector3(xPos, yPos + holder);
                    holder += -0.4f;
                }
                else
                {
                    if (x != 0) builtTile.transform.position = new Vector3(xPos + mainTree.position.x, yPos + mainTree.position.y);
                    else builtTile.transform.position = new Vector3(xPos + mainTree.position.x + 1, yPos + mainTree.position.y);
                }

            }
            counter++;
        }
    }
    void screenMouseRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        }
    }
}
