using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{

    [SerializeField] ParticleSystem hoverPuff;
    
    public void emithoverPuff(int amount = 5)
    {
        hoverPuff.Emit(amount);
    }

}
