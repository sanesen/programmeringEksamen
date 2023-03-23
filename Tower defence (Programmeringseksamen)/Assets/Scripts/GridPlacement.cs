using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridPlacement : MonoBehaviour
{
    public Tilemap map;
    public GameObject tower;
    public LayerMask towerLayer;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = new Vector3Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y),0);
            
            TileBase tile = map.GetTile(gridPos);

            if (tile != null)
            {
                if (Physics2D.OverlapCircle(new Vector2(gridPos.x, gridPos.y) + new Vector2(0.5f, 0.5f), 0.1f, towerLayer))
                    return;

                Instantiate(tower, gridPos + new Vector3(0.5f,0.5f,0), Quaternion.identity);
            }
        }
    }
}
