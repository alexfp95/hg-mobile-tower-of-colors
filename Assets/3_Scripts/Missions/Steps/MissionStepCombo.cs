using UnityEngine;

[CreateAssetMenu(menuName = "Missions/Steps/Combo")]
public class MissionStepCombo : MissionStep
{
    [SerializeField]
    private string _id = string.Empty;
    [SerializeField]
    private int reachCount = 10;

    private bool completed;

    public string ID => _id;

    private void Awake()
    {
        if (_id.Equals(string.Empty))
        {
            _id = System.Guid.NewGuid().ToString();
        }
    }

    public override string GetID()
    {
        return ID;
    }

    public override bool Evaluate(GameManager gameManager)
    {
        if (gameManager.GetCurrentCombo() >= reachCount)
        {
            completed = true;
        }
        return completed;
    }

    public override bool IsCompleted()
    {
        return completed;
    }

    public override void SetCompleted(bool state)
    {
        completed = state;
    }

    public override string GetDescription()
    {
        return "Get a x" + reachCount + " combo.";
    }
}
