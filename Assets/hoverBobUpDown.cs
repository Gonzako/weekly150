using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class hoverBobUpDown : MonoBehaviour
{

    [SerializeField] Transform repositionTarget;
    [SerializeField] float halfDistance = 0.5f;
    [SerializeField] float upTime = 0.2f, downTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        var downTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y -  halfDistance, downTime).SetEase(Ease.InOutSine);
        StartCoroutine(bobCycle(downTween));
    }

    IEnumerator bobCycle(Tween lastT)
    {
        yield return new WaitUntil(() => !lastT.IsPlaying());
        var upTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y + 2 * halfDistance, upTime).SetEase(Ease.InOutSine);

        yield return new WaitUntil(() => !upTween.IsPlaying());
        var downTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y - 2 * halfDistance, downTime).SetEase(Ease.InOutSine);


        //Is yield return needed in this case?
        yield return StartCoroutine(bobCycle(downTween));
    }
}
