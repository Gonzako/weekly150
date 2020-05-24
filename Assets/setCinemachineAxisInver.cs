using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class setCinemachineAxisInver : MonoBehaviour
{
    CinemachineFreeLook cam;
    private void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
    }

    public void setYAxisInvert(bool val)
    {
        cam.m_YAxis.m_InvertInput = val;
    }
    
    public void setXAxisInvert(bool val)
    {
        cam.m_XAxis.m_InvertInput = val;
    }
}
