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
        Player.instance.Move(new Vector3(transform.position.x,transform.position.y,0));
        ChessPiece.clicked = false;
        ShowPosCanMove.instance.ClearAllEffects();
    }
}
