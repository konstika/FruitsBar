using UnityEngine;

abstract public class Interaction : MonoBehaviour
{
    [SerializeField] protected string _tooltipMessage;

    abstract protected bool CheckAction();
    abstract protected void TakeAction();
    private void OnMouseEnter()
    {
        if (CheckAction())
        {
            MessageShower.Instance.ShowMessage(_tooltipMessage);
        }
    }

    private void OnMouseExit()
    {
        MessageShower.Instance.HideMessage();
    }

    private void OnMouseDown()
    {
        if (CheckAction()) {
            TakeAction();
            MessageShower.Instance.HideMessage();
            if (CheckAction())
            {
                MessageShower.Instance.ShowMessage(_tooltipMessage);
            }
        }
    }
}
