using UnityEngine;

public class WhiteQueenAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        
        Vector3 currentPos = transform.position;

        GetPoses(currentPos,Vector3.up + Vector3.right);
        GetPoses(currentPos,Vector3.up + Vector3.left);
        GetPoses(currentPos,Vector3.down + Vector3.right);
        GetPoses(currentPos,Vector3.down + Vector3.left);

        
        // đi sang phải
        GetPoses(currentPos, Vector3.right);
        // đi sang trái
        GetPoses(currentPos, Vector3.left);
        // đi lên trên
        GetPoses(currentPos, Vector3.up);
        // đi xuống dưới
        GetPoses(currentPos, Vector3.down);
    }
}
