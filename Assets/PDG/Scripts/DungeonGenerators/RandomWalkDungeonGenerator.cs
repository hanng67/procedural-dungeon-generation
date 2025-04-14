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
        [SerializeField] private RandomWalkSO randomWalkSO;


        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();
            RunRandomWalk(floors, randomWalkSO);

            tilemapVisualizer.Clear();
            tilemapVisualizer.PaintFloorTiles(floors);
        }

        private void RunRandomWalk(HashSet<Vector2Int> floors, RandomWalkSO randomWalkSO)
        {
            Vector2Int currentPosition = startPosition;
            for (int i = 0; i < randomWalkSO.interations; i++)
            {
                floors.UnionWith(ProceduralGenerationAlgorithms.RandomWalk(currentPosition, randomWalkSO.walkLength));
                if (!randomWalkSO.startRandomlyEachInteration) continue;
                currentPosition = floors.ElementAt(Random.Range(0, floors.Count));
            }
        }
    }
}
