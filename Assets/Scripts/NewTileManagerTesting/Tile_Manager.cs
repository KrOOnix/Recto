using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip completeSound;

    public void DecreaseTileCount(Color color)
    {
       CheckIfColorClear(color);
       CheckIfAllTilesClear();
    }

    private void CheckIfColorClear(Color originalColor)
    {
        bool recolorBlackTiles = true;
        Tile[] tiles = FindObjectsOfType<Tile>();

        foreach(Tile tile in tiles)
        {
            if (tile.GetComponent<Renderer>().material.color == originalColor)
            {
                recolorBlackTiles = false;
                return;
            }
        }

        if (recolorBlackTiles) { RecolorBlackTiles(); }
    }

    private void CheckIfAllTilesClear()
    {
        bool loadNextLevel = true;
        Tile[] tiles = FindObjectsOfType<Tile>();

        foreach (Tile tile in tiles)
        {
            if (tile.GetComponent<Renderer>().material.color != FindObjectOfType<ColorManager>().EndingTileColor)
            {
                loadNextLevel = false;
                return;
            }
        }

        if (loadNextLevel)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }

    }

    void RecolorBlackTiles()
    {
        Tile[] blackTiles = FindObjectsOfType<Tile>();

        for (int i = 0; i < blackTiles.Length; i++)
        {
            if (blackTiles[i].GetComponent<Renderer>().material.color == Color.black)
            {
                blackTiles[i].GetComponent<Renderer>().material.color = FindObjectOfType<ColorManager>().EndingTileColor;
                blackTiles[i].CanKillPlayer = false;
            }
        }

        FindObjectOfType<ColorManager>().ChangeColor();

        audioSource.PlayOneShot(completeSound);

    }
}
