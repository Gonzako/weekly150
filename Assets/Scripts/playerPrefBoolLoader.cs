using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class playerPrefBoolLoader : MonoBehaviour
{
    [SerializeField] string key;

    [System.Serializable]
    public class loaderEvent : UnityEvent<bool>{}

    public loaderEvent onStart = new loaderEvent();
    // Start is called before the first frame update
    void Start()
    {
        bool val = 1 == PlayerPrefs.GetInt(key);
        onStart.Invoke(val);
    }


}
