using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class BlackRock : ChessPiece
{
    public override void ShowPosesCanMove()
    {
        Vector3 currentPos = transform.position;
        // đi sang phải
        ShowPoses(currentPos, Vector3.right);
        // đi sang trái
        ShowPoses(currentPos, Vector3.left);
        // đi lên trên
        ShowPoses(currentPos, Vector3.up);
        // đi xuống dưới
        ShowPoses(currentPos, Vector3.down);
    }
}
