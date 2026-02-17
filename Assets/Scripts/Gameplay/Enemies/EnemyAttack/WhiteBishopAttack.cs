using UnityEngine;

public class WhiteBishopAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        
        Vector3 currentPos = transform.position;

        GetPoses(currentPos,Vector3.up + Vector3.right);
        GetPoses(currentPos,Vector3.up + Vector3.left);
        GetPoses(currentPos,Vector3.down + Vector3.right);
        GetPoses(currentPos,Vector3.down + Vector3.left);
    }
}
