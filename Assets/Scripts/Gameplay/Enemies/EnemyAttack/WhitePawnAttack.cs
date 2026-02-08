using UnityEngine;

public class WhitePawnAttack : EnemyAttack
{
    protected override void CalculateControlledPoses()
    {
        controledPoses.Add(Configs.ConvertVectorToInt(transform.position));
        GetPos(transform.position + Vector3.up + Vector3.right);
        GetPos(transform.position + Vector3.up + Vector3.left);
    }
}
