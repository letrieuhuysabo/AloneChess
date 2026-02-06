using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    HashSet <Vector2Int> obstacles;
    public static MapController instance;

    public HashSet<Vector2Int> Obstacles { get => obstacles; set => obstacles = value; }

    void Awake()
    {
        instance = this;
        obstacles = new();
    }

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            obstacles.Add(Configs.ConvertVectorToInt(transform.GetChild(i).position));
        }
    }
    public bool IsEmpty(Vector3 pos)
    {
        // Debug.Log(pos);
        Vector2Int convertedPos = Configs.ConvertVectorToInt(pos);
        // Debug.Log(convertedPos + "\n" + !obstacles.Contains(convertedPos) + "\n___");

        return !obstacles.Contains(convertedPos);
    }
}
