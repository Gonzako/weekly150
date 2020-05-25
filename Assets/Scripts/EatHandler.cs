using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatHandler : MonoBehaviour
{

    [SerializeField] private KeyCode _eatKey;
    [SerializeField] private Transform _eatPosition;
    [SerializeField] private float _eatRadius;
    [SerializeField] private LayerMask _eatable;

    // Update is called once per frame
    void Update()
    {
        if (true/*Input.GetKeyDown(_eatKey)*/)
        {
            Collider[] eatableTargets = Physics.OverlapSphere(_eatPosition.position, _eatRadius, _eatable);
            if(eatableTargets.Length > 0)
            {
                eatableTargets[0].GetComponent<IEatable>().Kill();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_eatPosition.position, _eatRadius);
    }
}
