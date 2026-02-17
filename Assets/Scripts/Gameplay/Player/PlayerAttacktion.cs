using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAttacktion : MonoBehaviour
{
    [SerializeField] GameObject gainAttacktionVfxPrefab, slashVfxPrefab;
    public static PlayerAttacktion instance;
    int holdingAttacktion;
    Stack<GameObject> takenAttacktion;
    Stack<GameObject> attackedEnemy;
    Coroutine clearTakenAttacktionCoroutine, clearAttackedEnemyCoroutine;

    public int HoldingAttacktion { get => holdingAttacktion; set
        {
            holdingAttacktion = value;
            AuraAttacktion.instance.ShowAura(holdingAttacktion > 0);
        }
    }
    public Stack<GameObject> TakenAttacktion { get => takenAttacktion; set => takenAttacktion = value; }

    private void Awake()
    {
        instance = this;
        takenAttacktion = new();
        attackedEnemy = new();
        holdingAttacktion = 0;
    }
    private void Start()
    {

        MyEventTrigger.instance.PlayerFallEventTriggers.Add(() =>
        {
            
            clearTakenAttacktionCoroutine = StartCoroutine(ClearTakenAttacktionCoroutine());
            clearAttackedEnemyCoroutine = StartCoroutine(ClearAttackedEnemyCoroutine());
        });
        MyEventTrigger.instance.PlayerDeadEventTriggers.Add(() =>
        {
            // tính toán xem có còn giữ attack hay ko
            if (holdingAttacktion > takenAttacktion.Count)
            {
                HoldingAttacktion = 1;
            }
            else
            {
                HoldingAttacktion = 0;
            }
            
            // StopCoroutine(clearTakenAttacktionCoroutine);
            // StopCoroutine(clearAttackedEnemyCoroutine);
            // hồi sinh các attacktion đã ăn
            while (takenAttacktion.Count > 0)
            {
                GameObject attacktion = takenAttacktion.Pop();
                attacktion.SetActive(true);
            }
            // hồi sinh enemy
            if (attackedEnemy.Count > 0)
            {
                StartCoroutine(RespawnEnemiesCoroutine());
                StartCoroutine(RecalculateControlledPosForEnemiesCoroutine());
                HoldingAttacktion = 1;
            }

        });
    }
    IEnumerator RecalculateControlledPosForEnemiesCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        EnemyAttack[] enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
        foreach (EnemyAttack enemyAttack in enemyAttacks)
        {
            if (enemyAttack.gameObject.activeInHierarchy)
            {
                enemyAttack.CalculateControlledPoses();
            }
        }
    }
    IEnumerator RespawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(1f);
        while (attackedEnemy.Count > 0)
        {
            GameObject enemy = attackedEnemy.Pop();
            enemy.SetActive(true);
        }
    }
    IEnumerator ClearTakenAttacktionCoroutine()
    {
        // yield return new WaitForSeconds(1f);
        yield return null;
        takenAttacktion.Clear();
    }
    IEnumerator ClearAttackedEnemyCoroutine()
    {
        // yield return new WaitForSeconds(1f);
        yield return null;
        attackedEnemy.Clear();
    }
    public void Attack(GameObject enemy)
    {
        SoundGameplayController.instance.PlayAttackSound();
        GameObject slashVfx = Instantiate(slashVfxPrefab);
        slashVfx.transform.position = enemy.transform.position;
        Destroy(slashVfx,2);
        enemy.SetActive(false);
        attackedEnemy.Push(enemy);
        HoldingAttacktion = 0;
        EnemyAttack[] enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
        foreach (EnemyAttack enemyAttack in enemyAttacks)
        {
            if (enemyAttack.gameObject.activeInHierarchy)
            {
                enemyAttack.CalculateControlledPoses();
            }
        }
        
        
    }
    public void GainAttacktion(GameObject collision)
    {
        HoldingAttacktion+=1;
        takenAttacktion.Push(collision.gameObject);
        collision.gameObject.SetActive(false);
        SoundGameplayController.instance.PlayGainAttacktionSound();
        GameObject gainAttacktionVfx = Instantiate(gainAttacktionVfxPrefab);
        gainAttacktionVfx.transform.position = transform.position;
        Destroy(gainAttacktionVfx,2);
    }
}
