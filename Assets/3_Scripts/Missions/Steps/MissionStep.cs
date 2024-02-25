using UnityEngine;

public abstract class MissionStep : ScriptableObject
{

    public virtual bool Evaluate(GameManager gameManager)
    {
        return false;
    }

    public virtual string GetID()
    {
        return string.Empty;
    }

    public virtual bool IsCompleted()
    {
        return false;
    }

    public virtual void SetCompleted(bool state)
    {
    }

    public virtual string GetDescription()
    {
        return string.Empty;
    }
}
