using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefBoolSaver : MonoBehaviour
{
    [SerializeField] private string valueKey;

    public void saveValue(bool val)
    {
        PlayerPrefs.SetInt(valueKey, val ? 1 : 0);
    }

}
