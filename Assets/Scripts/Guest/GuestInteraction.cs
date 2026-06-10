using UnityEngine;

public class GuestInteraction : Interaction
{
    [SerializeField] private GuestController _guestController;
    [SerializeField] private string _tooltip = "Serve the {0}";
    protected override bool CheckAction()
    {
        return (HandStorageController.Instance.GetItem()?.GetComponent<DrinkController>().Drink != null && _guestController.State == GuestController.StateGuest.WaitingOrder);
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = _tooltip;
        itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
    }

    protected override void TakeAction()
    {
        _guestController.TakeDrink(HandStorageController.Instance.ReleaseItemFromHand());
    }
}
