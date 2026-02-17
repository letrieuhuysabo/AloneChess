using UnityEngine;

public class WhiteRockAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        Vector3 currentPos = transform.position;
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
