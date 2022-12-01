using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] List<GameObject> tiles = new List<GameObject>();
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> Tiles => tileList;
    [SerializeField] GameObject gem;
    int numOfGems = 0;


    public void DrawGridTiles(IEnumerable<Vector3Int> tilePositions)
    {
        GetTileList();
        DrawTiles(tilePositions, tileList);
    }

    void GetTileList()
    {
        int listLenght = Random.Range(3, tiles.Count);
        for (int i = 0; i < listLenght; i++)
        {
            tileList.Add(tiles[i]);
        }
        Debug.Log(tileList.Count);
    }


    void DrawTiles(IEnumerable<Vector3Int> positions, List<GameObject> tiles)
    {
        
        foreach (var position in positions)
        {
            DrawSingleTile(tiles[Random.Range(0,tileList.Count)],position);
        }
    }

    void DrawSingleTile(GameObject tile, Vector3Int position)
    {
        var tileInstance = Instantiate(tile, position, Quaternion.identity);
        tileInstance.transform.parent = this.transform;
        int random = Random.Range(0, 30);
        if (random < 5 && numOfGems<=5)
        {
            Instantiate(gem, new Vector3(tileInstance.transform.position.x, 4.5f, tileInstance.transform.position.z), Quaternion.identity);
            numOfGems++;
        }
    }
}
