using System;
using UnityEngine;

public class TrashAnimationController : MonoBehaviour
{
    private Animator _trashAnimator;
    public event Action OnEndAnimation;
    public event Action OnCanFall;

    private void Start()
    {
        _trashAnimator = GetComponent<Animator>();
    }
    public void AnimateTrash() {
        _trashAnimator.SetTrigger("OpenTrash");
    }

    public void OnOpenTrash() {
        OnCanFall.Invoke();
    }

    public void OnCloseTrash() {
        OnEndAnimation.Invoke();
    }
}
