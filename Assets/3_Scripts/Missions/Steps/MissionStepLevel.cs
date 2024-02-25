using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Missions/Steps/Level")]
public class MissionStepLevel : MissionStep
{
    [SerializeField]
    private string _id = string.Empty;
    [SerializeField]
    private int reachLevel = 5;

    private bool completed;

    private void Awake()
    {
        if (_id.Equals(string.Empty))
        {
            _id = System.Guid.NewGuid().ToString();
        }
    }

    public override string GetID()
    {
        return _id;
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
        return "Reach level " + reachLevel + ".";
    }

    public override bool Evaluate(GameManager gameManager)
    {
        if (SaveData.CurrentLevel >= reachLevel)
        {
            completed = true;
        }
        return completed;
    }
}
