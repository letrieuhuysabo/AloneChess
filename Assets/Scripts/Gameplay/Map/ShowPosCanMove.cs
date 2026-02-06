using System.Collections.Generic;
using UnityEngine;

public class ShowPosCanMove : MonoBehaviour
{
    List <GameObject> canMoveEffects;
    public static ShowPosCanMove instance;
    void Awake()
    {
        instance = this;
        canMoveEffects = new();
    }
    public void ShowThisPos(Vector3 pos)
    {
        CanMoveEffectController.clicked = false;
        GameObject canMoveEffect = CanMoveEffectPooling.instance.TakeObj();
        canMoveEffect.transform.position = new Vector3(pos.x,pos.y,-2);
        canMoveEffects.Add(canMoveEffect);
    }
    public void ClearAllEffects()
    {
        foreach (GameObject effect in canMoveEffects)
        {
            CanMoveEffectPooling.instance.ReturnObj(effect);
        }
    }
}
