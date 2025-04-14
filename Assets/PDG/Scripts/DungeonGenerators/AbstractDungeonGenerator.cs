using System;
using MyBox;
using UnityEngine;

namespace PDG
{
    public abstract class AbstractDungeonGenerator : MonoBehaviour
    {
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] protected TilemapVisualizer tilemapVisualizer;


        [ButtonMethod]
        public void GenerateDungeon()
        {
            tilemapVisualizer.Clear();
            RunProceduralGeneration();
        }

        protected virtual void RunProceduralGeneration() { }
    }
}