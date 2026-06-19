using System;
using UnityEngine;

public class BlenderAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _blenderAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _workBlenderAudio;
    [SerializeField] private AudioClip _pouringAudio;

    public event Action OnStopWorkingBlender;

    void Start()
    {
        _blenderAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void AnimateWorkBlender()
    {
        _blenderAnimator.SetTrigger("StartBlender");
        _audioSource.clip = _workBlenderAudio;
        _audioSource.Play();
    }

    public void OnStopBlender()
    {
        _blenderAnimator.SetTrigger("StopBlender");
        OnStopWorkingBlender.Invoke();
    }

    public void AnimatePourOut() {
        _blenderAnimator.SetTrigger("PourOut");
        _audioSource.clip = _pouringAudio;
        _audioSource.Play();
    }
}
