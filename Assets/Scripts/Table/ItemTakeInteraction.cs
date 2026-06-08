using UnityEngine;

public class IteTakeInteraction : Interaction
{
    [SerializeField] private GameObject _item;
    [SerializeField] private string _tooltip = "Take the {0}";
    protected override bool CheckAction()
    {
        return HandStorageController.Instance.IsEmptyHand();
    }

    protected override void ChooseMessage()
    {
        itemName = _item.GetComponent<Item>().Name;
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {
        HandStorageController.Instance.TakeItemInHand(_item);
    }
}
