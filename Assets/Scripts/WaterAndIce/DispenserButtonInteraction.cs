using UnityEngine;

public class DispenserButtonInteraction : Interaction
{
    [SerializeField] private DispenserController _dispenserController;
    [SerializeField] private string _tooltip = "Add {0} to the glass";

    protected override bool CheckAction()
    {
        return !_dispenserController.IsEmptyDispenser();
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {
        _dispenserController.AddIngridient();
    }
}
