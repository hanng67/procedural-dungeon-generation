using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDG
{
    public static class Direction2D
    {
        public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>(){
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left,
        };

        public static Vector2Int GetRandomCardinalDirection()
        {
            return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
        }
    }
}