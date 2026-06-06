using TMPro;
using UnityEngine;

public class MessageShower : MonoBehaviour
{
    public static MessageShower Instance;
    [SerializeField] private TextMeshProUGUI _messageTMP;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) { Destroy(gameObject);}
    }

    private void Start()
    {
        _messageTMP.enabled = false;
    }

    public void ShowMessage(string message) { 
        _messageTMP.text = message;
        _messageTMP.enabled = true;
    }

    public void HideMessage() {
        _messageTMP.enabled = false;
    }
}
