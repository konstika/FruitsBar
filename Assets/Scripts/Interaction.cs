using UnityEngine;

abstract public class Interaction : MonoBehaviour
{
    protected string tooltipMessage;
    protected string itemName;

    abstract protected bool CheckAction();
    abstract protected void TakeAction();
    abstract protected void ChooseMessage();
    private void ComposeMessage() {
        tooltipMessage = string.Format(tooltipMessage, itemName);
    }

    private void CheckMessage() {
        if (CheckAction())
        {
            ChooseMessage();
            ComposeMessage();
            MessageShower.Instance.ShowMessage(tooltipMessage);
        }
    }
    private void OnMouseEnter()
    {
        CheckMessage();
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
            CheckMessage();
        }
    }
}
