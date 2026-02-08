using UnityEngine;

public class BlackKnight : ChessPiece
{
    public override void ShowPosesCanMove()
    {
        Vector3 currentPos = transform.position;
        ShowPos(currentPos + Vector3.up * 2 + Vector3.right);
        ShowPos(currentPos + Vector3.up * 2 + Vector3.left);
        ShowPos(currentPos + Vector3.down * 2 + Vector3.left);
        ShowPos(currentPos + Vector3.down * 2 + Vector3.right);
        ShowPos(currentPos + Vector3.left * 2 + Vector3.up);
        ShowPos(currentPos + Vector3.left * 2 + Vector3.down);
        ShowPos(currentPos + Vector3.right * 2 + Vector3.up);
        ShowPos(currentPos + Vector3.right * 2 + Vector3.down);
        if (posCanMoveQuantity == 0)
        {
            ShowCantMoveAnywhere();
        }
    }
    
}
