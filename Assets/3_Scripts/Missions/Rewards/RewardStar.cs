using UnityEngine;

[CreateAssetMenu(menuName = "Missions/Rewards/Stars")]
public class RewardStar : Reward
{
    public int Amount = 1;

    public override void ClaimReward()
    {
        SaveData.Stars += Amount;
    }

    public override string GetDescription()
    {
        return "x" + Amount + " Stars";
    }
}
