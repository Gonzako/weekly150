using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{

    [SerializeField] private FloatReference _killcount;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _killcount.Value = FindObjectsOfType<AIManager>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _killcount.Value.ToString("0");
    }
}
