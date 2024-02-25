using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsUI : MonoBehaviour
{
    private void OnEnable()
    {
        if (!RemoteConfig.BOOL_MISSIONS_ENABLED)
        {
            gameObject.SetActive(false);
        }
    }
}
