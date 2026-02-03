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
        
        Player.instance.Anim.SetTrigger("Move");
        yield return new WaitForSeconds(0.25f);
        Player.instance.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y,0);
        Player.instance.Fall(0.25f);
        ShowPosCanMove.instance.ClearAllEffects();
        
    }
}
