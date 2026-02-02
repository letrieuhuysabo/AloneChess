using System.Collections;
using UnityEngine;

public class BlackBishop : ChessPiece
{
    public override void ShowPosesCanMove()
    {
        Vector3 currentPos = transform.position;
        // đi phải lên
        ShowPoses(currentPos, Vector3.right + Vector3.up);
        // đi trái lên
        ShowPoses(currentPos, Vector3.left + Vector3.up);
        // đi phải xuống
        ShowPoses(currentPos, Vector3.right + Vector3.down);
        // đi trái xuống
        ShowPoses(currentPos, Vector3.left + Vector3.down);
    }
}
