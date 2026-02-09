using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected HashSet<Vector2Int> controledPoses;
    protected Vector2Int landingPos;

    public Vector2Int LandingPos { get => landingPos; set => landingPos = value; }

    void Awake()
    {
        controledPoses = new();
    }
    async void Start()
    {
        MyEventTrigger.instance.PlayerMoveEventTriggers.Add(() => CheckControlledPoses());
        controledPoses.Add(Configs.ConvertVectorToInt(transform.position));
        await Task.Yield();
        CalculateControlledPoses();
    }
    public bool IsControlled(Vector3 pos)
    {
        Vector2Int convertedPos = Configs.ConvertVectorToInt(pos);
        return controledPoses.Contains(convertedPos);
    }
    void CheckControlledPoses()
    {
        Vector2Int playerPos = Configs.ConvertVectorToInt(Player.instance.gameObject.transform.position);
        if (controledPoses.Contains(playerPos))
        {
            Attack();
        }
    }
    void Attack()
    {
        Vector3 targetPos = Player.instance.gameObject.transform.position;
        Vector3 startPos = transform.position;
        StartCoroutine(AttackCoroutine(startPos,targetPos));
    }
    IEnumerator AttackCoroutine(Vector3 startPos, Vector3 targetPos)
    {
        float duration = 0f;
        
        while (duration < 0.05f)
        {
            transform.position = Vector3.Lerp(startPos,targetPos,duration/0.05f);
            duration += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        
        Player.instance.Respawn();
        yield return new WaitForSeconds(1f);
        transform.position = startPos;
    }
    protected abstract void CalculateControlledPoses();
    protected void GetPoses(Vector3 currentPos, Vector3 dir)
    {
        int distance = 1;
        while (true)
        {
            if (MapController.instance.IsEmpty(currentPos + dir * distance))
            {
                controledPoses.Add(Configs.ConvertVectorToInt(currentPos + dir*distance));
                // Debug.Log("spawned at " + currentPos + dir*distance);
            }
            else
            {
                // Debug.Log(dir * distance);
                break;
            }
            distance++;
        }
    }
    protected void GetPos(Vector3 pos)
    {
        if (MapController.instance.IsEmpty(pos))
        {
            controledPoses.Add(Configs.ConvertVectorToInt(pos));
        }
    }
}
