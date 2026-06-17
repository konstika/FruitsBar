using System;
using UnityEngine;

public class DrinkAnimationController : MonoBehaviour
{

    [SerializeField] private Animator _blenderAnimator;
    public event Action OnStopPouring;

    void Start()
    {
        _blenderAnimator = GetComponent<Animator>();
    }

    public void AnimatePour()
    {
        _blenderAnimator.SetTrigger("Pour");
    }

    public void OnEndAnimationPouring() {
        OnStopPouring.Invoke();
    }
}
