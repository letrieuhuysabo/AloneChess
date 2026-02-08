using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    HashSet <Vector2Int> obstacles;
    EnemyAttack[] enemyAttacks;
    
    public static MapController instance;

    public HashSet<Vector2Int> Obstacles { get => obstacles; set => obstacles = value; }

    void Awake()
    {
        instance = this;
        obstacles = new();
    }

    void Start()
    {
        // thêm các ô gạch
        for (int i = 0; i < transform.childCount; i++)
        {
            obstacles.Add(Configs.ConvertVectorToInt(transform.GetChild(i).position));
        }

        enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
        
    }
    public bool IsEmpty(Vector3 pos)
    {
        Vector2Int convertedPos = Configs.ConvertVectorToInt(pos);
        foreach (EnemyAttack enemyAttack in enemyAttacks)
        {
            if (Configs.ConvertVectorToInt(enemyAttack.gameObject.transform.position) == convertedPos)
            {
                return false;
            }
        }
        
        return !obstacles.Contains(convertedPos);
    }
}
