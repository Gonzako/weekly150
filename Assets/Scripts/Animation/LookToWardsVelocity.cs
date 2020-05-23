using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToWardsVelocity : MonoBehaviour
{
    public Transform rotateTarget;
    public Rigidbody info;
    public float velocity;

    private void Update()
    {
        ///        headBone.localRotation = Quaternion.Slerp(
        ///  currentLocalRotation,
        ///  targetLocalRotation,
        ///  1 - Mathf.Exp(-headTrackingSpeed * Time.deltaTime)
        ///);
        ///
        if (info.velocity != Vector3.zero)
        {
            var currentLocalRot = rotateTarget.localRotation;
            //var targetLocalRotation = Quaternion.Euler(info.velocity);
            var ignoreY = info.velocity;
            ignoreY.y = 0;
            var targetLocalRotation = Quaternion.LookRotation(ignoreY, Vector3.up);

            rotateTarget.localRotation = Quaternion.Slerp(currentLocalRot, targetLocalRotation,
                1 - Mathf.Exp(-velocity * Time.deltaTime)); 
        }
    }

}
