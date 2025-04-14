using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBox;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PDG
{
    public class RandomWalkDungeonGenerator : MonoBehaviour
    {
        [SerializeField] private Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] private int interations = 10, walkLegth = 10;
        [SerializeField] private bool startRandomlyEachInteration = false;
        [SerializeField] private TilemapVisualizer tilemapVisualizer;


        [ButtonMethod]
        private void ProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();
            RunRandomWalk(floors);

            tilemapVisualizer.Clear();
            tilemapVisualizer.PaintFloorTiles(floors);
        }

        private void RunRandomWalk(HashSet<Vector2Int> floors)
        {
            Vector2Int currentPosition = startPosition;
            for (int i = 0; i < interations; i++)
            {
                floors.UnionWith(ProceduralGenerationAlgorithms.RandomWalk(currentPosition, walkLegth));
                if (!startRandomlyEachInteration) continue;
                currentPosition = floors.ElementAt(Random.Range(0, floors.Count));
            }
        }
    }
}
