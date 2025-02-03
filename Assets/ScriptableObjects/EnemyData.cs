using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Generate Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    // Class that represents a specific type of vehicle
    [Range(0.1f, 10f)]
    public float health = 1f;

    [Range(0.1f, 10f)]
    public float speed = 2f;

    public float damage = 1f;

    public int score = 1;

}