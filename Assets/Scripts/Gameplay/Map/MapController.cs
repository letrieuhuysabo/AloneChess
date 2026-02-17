using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapController : MonoBehaviour
{
    HashSet<Vector2Int> obstacles;
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

        Tilemap tilemap = transform.GetChild(0).gameObject.GetComponent<Tilemap>();
        if (tilemap != null)
        {
            BoundsInt bounds = tilemap.cellBounds;
            foreach (Vector3Int pos in bounds.allPositionsWithin)
            {
                if (tilemap.HasTile(pos))
                {
                    // pos chính là tọa độ ô gạch (Vector3Int)
                    // Bạn có thể lưu pos vào List hoặc Dictionary để xử lý logic
                    obstacles.Add(Configs.ConvertVectorToInt(new Vector3(pos.x + 1f, pos.y + 1f, 0)));
                    // Debug.Log(pos);
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                obstacles.Add(Configs.ConvertVectorToInt(transform.GetChild(i).position));
            }
        }
        enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);

    }
    public bool IsEmpty(Vector3 pos)
    {
        Vector2Int convertedPos = Configs.ConvertVectorToInt(pos);
        foreach (EnemyAttack enemyAttack in enemyAttacks)
        {
            if (!enemyAttack.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Configs.ConvertVectorToInt(enemyAttack.gameObject.transform.position) == convertedPos)
            {
                return false;
            }
        }
        // Debug.Log(convertedPos);
        // Debug.Log(!obstacles.Contains(convertedPos));
        return !obstacles.Contains(convertedPos);
    }
}
