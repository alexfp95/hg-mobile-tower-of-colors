using UnityEngine;
using System.Collections;

public static class SaveData
{
    public static int CurrentLevel
    {
        get {
            return PlayerPrefs.GetInt("CurrentLevel", 1);
        }
        set {
            PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }

    public static float PreviousHighscore
    {
        get {
            return PlayerPrefs.GetFloat("PreviousHighscore", 0);
        }
        set {
            PlayerPrefs.SetFloat("PreviousHighscore", value);
        }
    }

    public static int CurrentColorList
    {
        get {
            return PlayerPrefs.GetInt("CurrentColorList", 0);
        }
        set {
            PlayerPrefs.SetInt("CurrentColorList", value);
        }
    }

    public static int VibrationEnabled
    {
        get {
            return PlayerPrefs.GetInt("VibrationEnabled", 1);
        }
        set {
            PlayerPrefs.SetInt("VibrationEnabled", value);
        }
    }

    public static bool IsMissionCompleted(string id)
    {
        return PlayerPrefs.GetInt(id, 0) != 0;
    }

    public static void SetMissionCompleted(string id, bool state)
    {
        PlayerPrefs.SetInt(id, state ? 1 : 0);
    }

    public static int Stars
    {
        get
        {
            return PlayerPrefs.GetInt("Stars", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Stars", value);
        }
    }

}
