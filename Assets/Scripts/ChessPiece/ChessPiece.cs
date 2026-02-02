using System.Collections;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log(Player.instance.Falling);
        if (Player.instance.Falling)
        {
            return;
        }
        ShowPosesCanMove();
    }
    
    public abstract void ShowPosesCanMove();
    // hàm này dùng cho vua, mã, tốt
    public void ShowPos(Vector3 targetPos)
    {
        if (MapController.instance.IsEmpty(targetPos))
        {
            ShowPosCanMove.instance.ShowThisPos(targetPos);
        }
    }
    // hàm này dùng cho hậu, tượng, xe
    public void ShowPoses(Vector3 currentPos, Vector3 dir)
    {
        StartCoroutine(ShowPosesCoroutine(currentPos,dir));
    }
    IEnumerator ShowPosesCoroutine(Vector3 currentPos, Vector3 dir)
    {
        int distance = 1;
        while (true)
        {
            if (MapController.instance.IsEmpty(currentPos + dir * distance))
            {
                ShowPosCanMove.instance.ShowThisPos(currentPos + dir * distance);
            }
            else
            {
                // Debug.Log(dir * distance);
                break;
            }
            distance++;
            // yield return new WaitForSeconds(1f);
            yield return null;
        }
    }
}
