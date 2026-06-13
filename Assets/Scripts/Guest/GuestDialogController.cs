using System;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuestDialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageTMP;
    [SerializeField] private Image _nextArrowImage;
    private Canvas _canvas;
    private string[] _dialog;
    private int _currentMessageNumber;
    private bool _createdInFrame = true;

    public event Action OnDialogEnd;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        if (Math.Abs(Camera.main.transform.eulerAngles.y) < 1)
        {
            _canvas.enabled = true;
        }
        else if(_canvas.enabled){
            _canvas.enabled = false;
        }
        if (Input.GetMouseButtonDown(0) && !_createdInFrame && _canvas.enabled) {
            ToNextMessage();
        }
        _createdInFrame = false;
    }

    public void CreateDialog(string[] dialog) { 
        _dialog = dialog;
        _currentMessageNumber = 0;
        _nextArrowImage.enabled = true;
        _createdInFrame = true;
        ToNextMessage();
    }
    public void ToNextMessage() {
        if (_dialog == null) {return; }
        if (_currentMessageNumber < _dialog.Length)
        {
            _messageTMP.text = _dialog[_currentMessageNumber];
            _currentMessageNumber++;
            if (_currentMessageNumber == _dialog.Length ){
                _nextArrowImage.enabled = false;
                OnDialogEnd.Invoke();
            }
        }
    }
}
