using UnityEngine;

public class BlackPawn : ChessPiece
{
    public override void ShowPosesCanMove()
    {
        Vector3 currentPos = transform.position;
        // đi lên trên
        if (MapController.instance.IsEmpty(currentPos + Vector3.up))
        {
            ShowPosCanMove.instance.ShowThisPos(currentPos + Vector3.up);
            posCanMoveQuantity++;
        }
        // ăn quân chéo
        if (PlayerAttacktion.instance.HoldingAttacktion > 0)
        {
            Vector3 leftTarget = currentPos + Vector3.up + Vector3.left;
            Vector3 rightTarget = currentPos + Vector3.up + Vector3.right;
            EnemyAttack[] enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
            foreach (EnemyAttack enemyAttack in enemyAttacks)
            {
                if (enemyAttack.LandingPos == Configs.ConvertVectorToInt(leftTarget))
                {
                    ShowPosCanMove.instance.ShowThisAttackPos(leftTarget);
                    posCanMoveQuantity++;

                }
                else if (enemyAttack.LandingPos == Configs.ConvertVectorToInt(rightTarget))
                {
                    ShowPosCanMove.instance.ShowThisAttackPos(rightTarget);
                    posCanMoveQuantity++;
                }
            }
        }

        if (posCanMoveQuantity == 0)
        {
            ShowCantMoveAnywhere();
        }
    }
}
