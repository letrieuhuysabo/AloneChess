using UnityEngine;

public class WhiteKnightAttack : EnemyAttack
{
    public override void CalculateControlledPoses()
    {
        landingPos = Configs.ConvertVectorToInt(transform.position);
        GetPos(transform.position + Vector3.up*2 + Vector3.right);
        GetPos(transform.position + Vector3.up*2 + Vector3.left);

        GetPos(transform.position + Vector3.down*2 + Vector3.right);
        GetPos(transform.position + Vector3.down*2 + Vector3.left);

        GetPos(transform.position + Vector3.left*2 + Vector3.up);
        GetPos(transform.position + Vector3.left*2 + Vector3.down);

        GetPos(transform.position + Vector3.right*2 + Vector3.up);
        GetPos(transform.position + Vector3.right*2 + Vector3.down);
    }
}
