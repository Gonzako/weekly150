using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private FloatReference _time;
    

    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _time.Value.ToString("0.00");
    }
}
