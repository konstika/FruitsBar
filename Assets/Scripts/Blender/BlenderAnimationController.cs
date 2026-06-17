using System;
using UnityEngine;

public class BlenderAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _blenderAnimator;
    public event Action OnStopWorkingBlender;

    void Start()
    {
        _blenderAnimator = GetComponent<Animator>();
    }

    public void AnimateWorkBlender()
    {
        _blenderAnimator.SetTrigger("StartBlender");
    }

    public void OnStopBlender()
    {
        _blenderAnimator.SetTrigger("StopBlender");
        OnStopWorkingBlender.Invoke();
    }

    public void AnimatePourOut() {
        _blenderAnimator.SetTrigger("PourOut");
    }
}
