using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public static bool clicked;
    protected int posCanMoveQuantity;
    Coroutine showCantMoveAnywhereCoroutine;
    private void Start() {
        posCanMoveQuantity = 0;
    }
    void OnMouseDown()
    {
        if (Player.instance.Falling || Player.instance.Dead || CompleteGameController.completed)
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
            posCanMoveQuantity = 0;
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
            posCanMoveQuantity++;
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
                posCanMoveQuantity++;
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
            SwitchPiece switchPiece = collision.gameObject.GetComponent<SwitchPiece>();
            GameObject piece = Instantiate(switchPiece.PiecePrefab);
            piece.transform.SetParent(transform.parent, false);
            piece.transform.localPosition = Vector3.zero;
            SoundGameplayController.instance.PlaySwitchPieceSound();
            SpawnSwitchPieceVfx(switchPiece.SwitchVfxPrefab,collision.transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Portal"))
        {
            Portal.instance.CompleteLevel();
        }
        if (collision.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            StarCollector.instance.CollectStar(collision.gameObject);
            StarCollector.instance.SpawnGainStarVfx(collision.gameObject.transform.position);
        }
    }
    void SpawnSwitchPieceVfx(GameObject switchVfxPrefab, Vector3 pos)
    {
        GameObject switchVfx = Instantiate(switchVfxPrefab);
        switchVfx.transform.position = pos;
        Destroy(switchVfx,5);
    }
    protected void ShowCantMoveAnywhere()
    {
        if (showCantMoveAnywhereCoroutine != null)
        {
            StopCoroutine(showCantMoveAnywhereCoroutine);
        }
        showCantMoveAnywhereCoroutine = StartCoroutine(ShowCantMoveAnywhereCoroutine());
    }
    IEnumerator ShowCantMoveAnywhereCoroutine()
    {
        SoundGameplayController.instance.PlayCantMoveSound();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float duration = 0.05f;
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(duration);
            spriteRenderer.color = Color.black;
            yield return new WaitForSeconds(duration);
        }
        clicked = false;
    }
}
