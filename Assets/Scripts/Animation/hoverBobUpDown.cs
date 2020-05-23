using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class hoverBobUpDown : MonoBehaviour
{

    [SerializeField] Transform repositionTarget;
    [SerializeField] float halfDistance = 0.5f;
    [SerializeField] float upTime = 0.2f, downTime = 0.5f;

    public Ease upEs, downEs;
    public UnityEvent peak;
    public UnityEvent bottom;

    // Start is called before the first frame update
    void Start()
    {
        var downTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y -  halfDistance, downTime).SetEase(downEs);
        StartCoroutine(bobCycle(downTween));
    }

    IEnumerator bobCycle(Tween lastT)
    {
        yield return new WaitUntil(() => !lastT.IsPlaying());
        bottom.Invoke();
        var upTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y + 2 * halfDistance, upTime).SetEase(upEs);

        yield return new WaitUntil(() => !upTween.IsPlaying());
        peak.Invoke();
        var downTween = repositionTarget.DOLocalMoveY(repositionTarget.localPosition.y - 2 * halfDistance, downTime).SetEase(downEs);


        //Is yield return needed in this case?
        yield return StartCoroutine(bobCycle(downTween));
    }
}
