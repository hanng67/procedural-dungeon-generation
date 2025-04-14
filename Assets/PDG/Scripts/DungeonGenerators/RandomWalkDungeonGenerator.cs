using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PDG
{
    public class RandomWalkDungeonGenerator : AbstractDungeonGenerator
    {
        [SerializeField] protected RandomWalkSO randomWalkSO;


        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();
            floors = RunRandomWalk(startPosition, randomWalkSO);

            tilemapVisualizer.Clear();
            tilemapVisualizer.PaintFloorTiles(floors);
        }

        protected HashSet<Vector2Int> RunRandomWalk(Vector2Int startPosition, RandomWalkSO randomWalkSO)
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();
            Vector2Int currentPosition = startPosition;
            for (int i = 0; i < randomWalkSO.interations; i++)
            {
                floors.UnionWith(ProceduralGenerationAlgorithms.RandomWalk(currentPosition, randomWalkSO.walkLength));
                if (!randomWalkSO.startRandomlyEachInteration) continue;
                currentPosition = floors.ElementAt(Random.Range(0, floors.Count));
            }
            return floors;
        }
    }
}
