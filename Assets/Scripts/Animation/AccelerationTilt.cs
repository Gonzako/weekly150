using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTilt : MonoBehaviour
{

    [SerializeField] Rigidbody info;
    [SerializeField] Transform rotateTarget;
    [SerializeField] float velocity = 10;

    private void LateUpdate()
    {
        var ignoreY = info.velocity;
        ignoreY.y = rotateTarget.localRotation.eulerAngles.y;

        var desiredTilt = Quaternion.Euler(ignoreY);
        
        var oldLocalRot = rotateTarget.localRotation;

        rotateTarget.localRotation = Quaternion.Slerp(oldLocalRot, desiredTilt,
            1 - Mathf.Exp(-velocity * Time.deltaTime));
    }

}
