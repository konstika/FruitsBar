using System;
using UnityEngine;

public class TrashAnimationController : MonoBehaviour
{
    private Animator _trashAnimator;
    private AudioSource _trashAudioSource;
    public event Action OnEndAnimation;
    public event Action OnCanFall;

    private void Start()
    {
        _trashAnimator = GetComponent<Animator>();
        _trashAudioSource = GetComponent<AudioSource>();
    }
    public void AnimateTrash() {
        _trashAnimator.SetTrigger("OpenTrash");
        _trashAudioSource.Play();
    }

    public void OnOpenTrash() {
        OnCanFall.Invoke();
    }

    public void OnCloseTrash() {
        OnEndAnimation.Invoke();
    }
}
