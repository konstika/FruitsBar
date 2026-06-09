using UnityEngine;

public class DispenserInteraction : Interaction
{
    [SerializeField] private DispenserController.ModeDispenser _mode;
    private Action _action;
    [SerializeField] private DispenserController _dispenserController;
    
    [SerializeField] private string _takeTooltip = "Take the {0}";
    [SerializeField] private string _putTooltip = "Put the {0} in the {1} dispenser";
    enum Action { 
        Take,
        Put
    }
    protected override bool CheckAction()
    {
        if (HandStorageController.Instance.GetItem()?.tag == "Glass" && _dispenserController.IsEmptyDispenser()) {
            if (_mode == DispenserController.ModeDispenser.Ice && HandStorageController.Instance.GetItem().GetComponent<DrinkController>().IsEmpty()) { return false; }
            _action = Action.Put;
            return true;
        }
        else if (HandStorageController.Instance.IsEmptyHand() && !_dispenserController.IsEmptyDispenser())
        {
            _action = Action.Take;
            return true;
        }
        return false;
    }

    protected override void ChooseMessage()
    {
        if (_action == Action.Put) {
            if (_mode == DispenserController.ModeDispenser.Ice)
            {
                tooltipMessage = string.Format(_putTooltip, "{0}", "ice");
            }
            else if (_mode == DispenserController.ModeDispenser.Water)
            {
                tooltipMessage = string.Format(_putTooltip, "{0}", "water");
            }
            itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
        }
        if (_action == Action.Take)
        {
            tooltipMessage = _takeTooltip;
            itemName = _dispenserController.GetItem().GetComponent<Item>().Name;
        }
    }

    protected override void TakeAction()
    {
        if (_action == Action.Put)
        {
            _dispenserController.PutItemInPlace(HandStorageController.Instance.ReleaseItemFromHand());
        }
        if (_action == Action.Take)
        {
            HandStorageController.Instance.TakeItemInHand(_dispenserController.ReleaseItemFromDispenser());
        }
    }
}
