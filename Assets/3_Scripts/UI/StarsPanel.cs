using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    [SerializeField]
    private MissionManager manager;

    [SerializeField]
    private TMPro.TMP_Text amount;

    // Start is called before the first frame update
    void Start()
    {
        manager.RewardsClaimed += UpdateFromInventory;
        UpdateFromInventory();
    }

    private void OnDestroy()
    {
        manager.RewardsClaimed -= UpdateFromInventory;
    }

    private void UpdateFromInventory()
    {
        amount.text = SaveData.Stars.ToString();
    }
}
