using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class WalkMapGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    [SerializeField]int iterations = 10;
    [SerializeField]public int walkLenght;
    [SerializeField]public bool startRandomlyEachIteration;
    [SerializeField]TilemapVisualizer tilemapVisualizer;
    float valueOfWalkLenght;
    public float ValueOfWalkLenght => valueOfWalkLenght;


    void Awake()
    {
        walkLenght = Random.Range(5, 15);
        valueOfWalkLenght = walkLenght;
    }

    public void RunGeneration()
    {
        HashSet<Vector3Int> tilePositions = RunRandomWalk();
        tilemapVisualizer.DrawGridTiles(tilePositions);
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector3Int> tilePositions = new HashSet<Vector3Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = WalkAlgorithm.RandomWalk(currentPosition, walkLenght);
            tilePositions.UnionWith(path);
            if (startRandomlyEachIteration)
            {
                currentPosition = tilePositions.ElementAt(Random.Range(0,tilePositions.Count));
            }
        }

        return tilePositions;
    }
}
