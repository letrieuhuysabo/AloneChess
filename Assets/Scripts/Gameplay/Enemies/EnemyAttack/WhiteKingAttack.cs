using UnityEngine;

public class WhiteKingAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        GetPos(transform.position + Vector3.up);
        GetPos(transform.position + Vector3.left);
        GetPos(transform.position + Vector3.right);
        GetPos(transform.position + Vector3.down);
        
        GetPos(transform.position + Vector3.down + Vector3.right);
        GetPos(transform.position + Vector3.down + Vector3.left);
        GetPos(transform.position + Vector3.up + Vector3.right);
        GetPos(transform.position + Vector3.up + Vector3.left);
    }
}
