using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDG
{
    public static class ProceduralGenerationAlgorithms
    {
        public static HashSet<Vector2Int> RandomWalk(Vector2Int startPosition, int walkLegth)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            Vector2Int currentPosition = startPosition;
            path.Add(currentPosition);
            for (int i = 0; i < walkLegth; i++)
            {
                currentPosition += Direction2D.GetRandomCardinalDirection();
                path.Add(currentPosition);
            }
            return path;
        }
    }
}
