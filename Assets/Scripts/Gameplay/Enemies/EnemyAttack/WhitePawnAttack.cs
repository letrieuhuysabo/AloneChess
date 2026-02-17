using UnityEngine;

public class WhitePawnAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        GetPos(transform.position + Vector3.up + Vector3.right);
        GetPos(transform.position + Vector3.up + Vector3.left);
    }
}
