using UnityEngine;

[CreateAssetMenu(fileName = "RandomWalkSO_", menuName = "PDG/RandomWalkSO")]
public class RandomWalkSO : ScriptableObject
{
    public int interations = 10, walkLength = 10;
    public bool startRandomlyEachInteration = false;
}