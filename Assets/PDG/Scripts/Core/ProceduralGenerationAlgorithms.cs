using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDG
{
    public static class ProceduralGenerationAlgorithms
    {
        public static HashSet<Vector2Int> RandomWalk(Vector2Int startPosition, int walkLength)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            Vector2Int currentPosition = startPosition;
            path.Add(currentPosition);
            for (int i = 0; i < walkLength; i++)
            {
                currentPosition += Direction2D.GetRandomCardinalDirection();
                path.Add(currentPosition);
            }
            return path;
        }

        public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLegth)
        {
            List<Vector2Int> path = new List<Vector2Int>();
            Vector2Int currentPosition = startPosition;
            Vector2Int direction = Direction2D.GetRandomCardinalDirection();
            path.Add(currentPosition);
            for (int i = 0; i < corridorLegth; i++)
            {
                currentPosition += direction;
                path.Add(currentPosition);
            }
            return path;
        }
    }
}
