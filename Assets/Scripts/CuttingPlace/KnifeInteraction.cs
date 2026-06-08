using UnityEngine;
using static UnityEditor.Progress;

public class KnifeInteraction : Interaction
{
    [SerializeField] private CutboardController _cutboardController;
    [SerializeField] private string _tooltip = "Cut {0}";

    protected override bool CheckAction()
    {
        return (_cutboardController.GetFruit()?.GetComponent<FruitStateController>()?.GetFruitState() == FruitState.Full);
    }

    protected override void ChooseMessage()
    {
        itemName = _cutboardController.GetFruit().GetComponent<Item>().Name;
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {
        _cutboardController.GetFruit().GetComponent<FruitStateController>().Cut();
    }
}
