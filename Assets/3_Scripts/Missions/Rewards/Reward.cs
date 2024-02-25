using UnityEngine;

public abstract class Reward : ScriptableObject
{
    public virtual void ClaimReward()
    {
    }

    public virtual string GetDescription()
    {
        return string.Empty;
    }
}
