using System.Collections;
using UnityEngine;

public class CanMoveEffectController : MonoBehaviour
{
    public static bool clicked;
    void OnMouseDown()
    {
        if (clicked)
        {
            return;
        }
        clicked = true;
        StartCoroutine(MovePlayerCoroutine());
    }
    IEnumerator MovePlayerCoroutine()
    {

        Player.instance.BeforePos = Player.instance.gameObject.transform.position;
        Player.instance.Anim.SetTrigger("Move");
        yield return new WaitForSeconds(0.15f);
        SoundGameplayController.instance.PlayMoveSound();
        yield return new WaitForSeconds(0.25f - 0.15f);
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, 0);
        EnemyAttack[] enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
        foreach (EnemyAttack enemyAttack in enemyAttacks)
        {
            if (enemyAttack.LandingPos == Configs.ConvertVectorToInt(targetPos))
            {
                PlayerAttacktion.instance.Attack(enemyAttack.gameObject);
                break;
            }
        }
        Player.instance.Move(targetPos);
        ChessPiece.clicked = false;
        ShowPosCanMove.instance.ClearAllEffects();
    }
}
