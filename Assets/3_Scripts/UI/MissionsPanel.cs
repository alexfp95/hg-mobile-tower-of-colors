using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsPanel : MonoBehaviour
{

    [SerializeField]
    private MissionManager manager;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private MissionItem missionItemPrefab;


    public void Toggle()
    {
        if (gameObject.activeSelf)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        manager.EvaluateCurrentMision(); // This evaluation is for non-gameplay missions, like current Level or other actions
        CleanMissions();
        SetMissions();
        gameObject.SetActive(true);
    }

    private void CleanMissions()
    {
        foreach(Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetMissions()
    {
        List<Mission> missions = manager.Missions;
        for(int i = 0; i < missions.Count; i++)
        {
            MissionItem item = Instantiate(missionItemPrefab, content.transform);
            item.Setup(missions[i], i == manager.CurrentIndex);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
