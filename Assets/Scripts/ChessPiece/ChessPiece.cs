using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public static bool clicked;
    void OnMouseDown()
    {
        if (Player.instance.Falling || CompleteGameController.completed)
        {
            return;
        }
        if (clicked)
        {
            ShowPosCanMove.instance.ClearAllEffects();
            clicked = false;
        }
        else
        {
            clicked = true;
            ShowPosesCanMove();
        }
        
    }
    
    public abstract void ShowPosesCanMove();
    // hàm này dùng cho vua, mã, tốt
    public void ShowPos(Vector3 targetPos)
    {
        if (MapController.instance.IsEmpty(targetPos))
        {
            ShowPosCanMove.instance.ShowThisPos(targetPos);
            // Debug.Log("spawned at " + targetPos);
        }
    }
    // hàm này dùng cho hậu, tượng, xe
    public void ShowPoses(Vector3 currentPos, Vector3 dir)
    {
        int distance = 1;
        while (true)
        {
            if (MapController.instance.IsEmpty(currentPos + dir * distance))
            {
                ShowPosCanMove.instance.ShowThisPos(currentPos + dir * distance);
                // Debug.Log("spawned at " + currentPos + dir+distance);
            }
            else
            {
                // Debug.Log(dir * distance);
                break;
            }
            distance++;
            // yield return new WaitForSeconds(1f);
            // yield return null;
        }
        // StartCoroutine(ShowPosesCoroutine(currentPos,dir));
    }
    // IEnumerator ShowPosesCoroutine(Vector3 currentPos, Vector3 dir)
    // {
        
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwitchPiece"))
        {
            
            GameObject piece = Instantiate(collision.gameObject.GetComponent<SwitchPiece>().PiecePrefab);
            piece.transform.SetParent(transform.parent, false);
            piece.transform.localPosition = Vector3.zero;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Portal"))
        {
            Portal.instance.CompleteLevel();
        }
        if (collision.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            StarCollector.instance.CollectStar();
        }
    }
}
