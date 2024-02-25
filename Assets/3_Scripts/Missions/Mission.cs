using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Missions/Mission")]
public class Mission : ScriptableObject
{

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    [SerializeField]
    private string _id = string.Empty;
    public string title = "New Mission";
    public Difficulty difficulty = Difficulty.Easy;
    public List<MissionStep> steps = new List<MissionStep>();
    public List<Reward> rewards = new List<Reward>();
    
    private bool completed = false;

    public string ID => _id;

    private void Awake()
    {
        if (_id.Equals(string.Empty))
        {
            _id = System.Guid.NewGuid().ToString();
        }
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public void SetComplete(bool state)
    {
        completed = state;
    }

    public void ClaimRewards()
    {
        for(int i = 0; i < rewards.Count; i++)
        {
            rewards[i].ClaimReward();
        }
    }
}

