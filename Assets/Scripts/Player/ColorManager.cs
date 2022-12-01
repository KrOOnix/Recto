using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorManager : MonoBehaviour
{

    [SerializeField] Renderer renderer;
    List<Color> colors = new List<Color>();
    Color currentColor;
    Color endingTileColor;
    public Color EndingTileColor => endingTileColor;
    public Color CurrentColor => currentColor;

    void Start()
    {
        AddColor();
        DetermineEndingTileColor();
        ChangeColor();
    }

    private void DetermineEndingTileColor()
    {
        int i = Random.Range(0, colors.Count);
        endingTileColor = colors[i];
        colors.RemoveAt(i);
    }

    public void ChangeColor()
    {

        if(colors.Count <1) { return; }
        int i = Random.Range(0, colors.Count);

        renderer.material.color = colors[i];
        currentColor = colors[i];
        colors.RemoveAt(i);
    }

    public void AddColor()
    {
        List<GameObject> tiles = FindObjectOfType<TilemapVisualizer>().Tiles;
        foreach(GameObject tile in tiles)
        {
            colors.Add(tile.GetComponent<Tile>().OriginalColor);
        }
    }

}
