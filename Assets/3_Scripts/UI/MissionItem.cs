using UnityEngine;
using UnityEngine.UI;

public class MissionItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Image background;
    [Header("References")]
    [SerializeField]
    private GameObject labelPrefab;
    [Header("Selected Mission")]
    [SerializeField]
    private Color currentColor;
    [SerializeField]
    private Color otherColor;
    [Header("Difficulty")]
    [SerializeField]
    private Color easyColor;
    [SerializeField]
    private Color mediumColor;
    [SerializeField]
    private Color hardColor;

    public void Setup(Mission mission, bool current = false)
    {
        CleanChildren();
        // Title
        GameObject titleGO = Instantiate(labelPrefab, transform);
        TMPro.TMP_Text title = titleGO.GetComponent<TMPro.TMP_Text>();
        title.text = "[" + mission.title + "]";
        Color titleColor = Color.white;
        switch (mission.difficulty)
        {
            case Mission.Difficulty.Easy: titleColor = easyColor; break;
            case Mission.Difficulty.Medium: titleColor = mediumColor; break;
            case Mission.Difficulty.Hard: titleColor = hardColor; break;
        }
        title.color = titleColor;
        if (mission.IsCompleted())
        {
            title.fontStyle = TMPro.FontStyles.Strikethrough;
        }
        // Steps
        for(int i = 0; i < mission.steps.Count; i++)
        {
            MissionStep step = mission.steps[i];
            GameObject stepLabelGO = Instantiate(labelPrefab, transform);
            TMPro.TMP_Text stepLabel = stepLabelGO.GetComponent<TMPro.TMP_Text>();
            stepLabel.text = step.GetDescription();
            if (step.IsCompleted())
            {
                stepLabel.fontStyle = TMPro.FontStyles.Strikethrough;
            }
        }
        // Rewards
        for(int i = 0; i < mission.rewards.Count; i++)
        {
            Reward reward = mission.rewards[i];
            GameObject rewardLabelGO = Instantiate(labelPrefab, transform);
            TMPro.TMP_Text rewardLabel = rewardLabelGO.GetComponent<TMPro.TMP_Text>();
            rewardLabel.text = reward.GetDescription();
            rewardLabel.alignment = TMPro.TextAlignmentOptions.MidlineRight;
            rewardLabel.fontStyle = TMPro.FontStyles.Italic;
        }
        // Current
        background.color = current ? currentColor : otherColor;
    }

    private void CleanChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
