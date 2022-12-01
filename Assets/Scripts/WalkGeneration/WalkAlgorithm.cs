using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WalkAlgorithm 
{
    public static HashSet<Vector3Int> RandomWalk(Vector3Int startPosition,int walkLength)
    {
        HashSet<Vector3Int> path  = new HashSet<Vector3Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for(int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection(); 
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }
}
public static class Direction2D
{
    public static List<Vector3Int> cardinalDirectionList = new List<Vector3Int>
    {
        new Vector3Int(0,0,10), //UP
        new Vector3Int(10,0,0), //RIGHT
        new Vector3Int(0,0,10), //DOWN
        new Vector3Int(-10,0,0) //LEFT

    };

    public static Vector3Int GetRandomCardinalDirection()
    {
        return cardinalDirectionList[Random.Range(0,cardinalDirectionList.Count)];
    }
}
