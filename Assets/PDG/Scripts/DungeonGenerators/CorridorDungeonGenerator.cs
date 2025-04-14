using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PDG
{
    public class CorridorDungeonGenerator : RandomWalkDungeonGenerator
    {
        public int corridorCount = 10, corridorLength = 10;
        [Range(0.1f, 1)]
        public float roomPercent = 0.8f;


        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();
            HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

            CreateCorridors(floors, potentialRoomPositions);
            CreateRooms(floors, potentialRoomPositions);

            tilemapVisualizer.PaintFloorTiles(floors);
        }

        private void CreateRooms(HashSet<Vector2Int> floors, HashSet<Vector2Int> potentialRoomPositions)
        {
            int roomCreateCount = Mathf.RoundToInt(roomPercent * potentialRoomPositions.Count);
            List<Vector2Int> roomStartPositions = potentialRoomPositions.OrderBy(x => Random.value).Take(roomCreateCount).ToList();

            foreach (Vector2Int startPosition in roomStartPositions)
            {
                floors.UnionWith(RunRandomWalk(startPosition, randomWalkSO));
            }

            List<Vector2Int> deadends = FindAllDeadEnds(floors, potentialRoomPositions);
            foreach (Vector2Int startPosition in deadends)
            {
                floors.UnionWith(RunRandomWalk(startPosition, randomWalkSO));
            }
        }

        private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floors, HashSet<Vector2Int> potentialRoomPositions)
        {
            List<Vector2Int> deadends = new List<Vector2Int>();
            foreach (Vector2Int position in potentialRoomPositions)
            {
                int neightbourCount = 0;
                foreach (Vector2Int direction in Direction2D.cardinalDirectionList)
                {
                    if (floors.Contains(position + direction)) neightbourCount++;
                }
                if (neightbourCount <= 1) deadends.Add(position);
            }
            return deadends;
        }

        private void CreateCorridors(HashSet<Vector2Int> floors, HashSet<Vector2Int> potentialRoomPositions)
        {
            Vector2Int currentPosition = startPosition;
            List<Vector2Int> path;
            potentialRoomPositions.Add(currentPosition);
            for (int i = 0; i < corridorCount; i++)
            {
                path = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorLength);
                currentPosition = path.Last();
                potentialRoomPositions.Add(currentPosition);
                floors.UnionWith(path);
            }
        }
    }
}