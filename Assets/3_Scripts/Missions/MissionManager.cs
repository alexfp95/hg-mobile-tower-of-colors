using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{

    [SerializeField]
    private GameManager gameManager;

    public List<Mission> missions = new List<Mission>();
    private int currentMission = -1;

    public List<Mission> Missions => missions;
    public int CurrentIndex => currentMission;

    public System.Action RewardsClaimed;

    // Start is called before the first frame update
    void Start()
    {
        if (!RemoteConfig.BOOL_MISSIONS_ENABLED)
        {
            return;
        }
        for(int i = 0; i < missions.Count; i++)
        {
            Mission mission = missions[i];
            mission.SetComplete(SaveData.IsMissionCompleted(mission.ID));
            if (!mission.IsCompleted() && currentMission == -1)
            {
                currentMission = i;
            }
            for(int k = 0; k < mission.steps.Count; k++)
            {
                mission.steps[k].SetCompleted(SaveData.IsMissionCompleted(mission.steps[k].GetID()));
            }
        }
        gameManager.ActionPerformed += EvaluateCurrentMision;
    }

    private void OnDestroy()
    {
        gameManager.ActionPerformed -= EvaluateCurrentMision;
    }


    public void EvaluateCurrentMision()
    {
        if (currentMission == -1 || currentMission >= missions.Count)
        {
            return;
        }

        // Check missions
        Mission current = missions[currentMission];
        if (current.IsCompleted())
        {
            HandleFinishedMission(current);
            return;
        }

        // Check steps
        int totalSteps = current.steps.Count;
        for (int i = 0; i < current.steps.Count; i++)
        {
            bool stepCompleted = current.steps[i].IsCompleted();
            if (!stepCompleted)
            {
                stepCompleted = current.steps[i].Evaluate(gameManager);
                if (stepCompleted)
                {
                    SaveData.SetMissionCompleted(current.steps[i].GetID(), true);
                }
            }
            if (stepCompleted)
            {
                totalSteps--;
            }
        }
        if (totalSteps == 0)
        {
            // Mission finished
            HandleFinishedMission(current);
        }
    }

    private void HandleFinishedMission(Mission mission)
    {
        mission.SetComplete(true);
        SaveData.SetMissionCompleted(mission.ID, true);
        mission.ClaimRewards();
        RewardsClaimed?.Invoke();
        SelectNextMission();
    }

    private void SelectNextMission()
    {
        currentMission = -1;
        for (int i = 0; i < missions.Count; i++)
        {
            if (!missions[i].IsCompleted())
            {
                currentMission = i;
                break;
            }
        }
    }

}
