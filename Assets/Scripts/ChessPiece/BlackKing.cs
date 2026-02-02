using System.Collections;
using UnityEngine;

public class BlackKing : ChessPiece
{
    public override void ShowPosesCanMove()
    {
        Vector3 currentPos = transform.position;
        // đi sang phải
        ShowPos(currentPos+ Vector3.right);
        // đi sang trái
        ShowPos(currentPos+ Vector3.left);
        // đi lên trên
        ShowPos(currentPos+ Vector3.up);
        // đi xuống dưới
        ShowPos(currentPos+ Vector3.down);
        // đi phải lên
        ShowPos(currentPos + Vector3.right + Vector3.up);
        // đi trái lên
        ShowPos(currentPos + Vector3.left + Vector3.up);
        // đi phải xuống
        ShowPos(currentPos +Vector3.right + Vector3.down);
        // đi trái xuống
        ShowPos(currentPos +Vector3.left + Vector3.down);
    }
}
