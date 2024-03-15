using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    Tilemap tilemap;
    public Tile debugTile = null;
    public Tile dirtHard = null;
    public Tile dirtSoft = null;

    public int xMax = 17;
    public int yMax = 5;

    public int debug = 0;
    public int debug1 = 0;

    void Start()
    {

        xMax = xMax - 9;
        yMax = yMax * -1;


        tilemap = GetComponentInChildren<Tilemap>();
        for (int i = -8; i <= xMax; i++)
        { 
            for (int j = 0; j >= yMax; j--)
            {
                if (Random.Range(1, 20) == 1 && (i >= 10 || j <= -6)) { tilemap.SetTile(new Vector3Int(i, j, 0), dirtHard); }

                else { tilemap.SetTile(new Vector3Int(i, j, 0), dirtSoft); }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlaceTile(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    void PlaceTile(Vector3Int tilePos)
    {
        tilePos.z = 0;
        Debug.Log("PLACING TILE " + debugTile.name + " AT " +  tilePos.ToString());
        tilemap.SetTile(tilePos, debugTile);
    }


}
