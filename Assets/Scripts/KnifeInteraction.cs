using UnityEngine;

public class KnifeInteraction : Interaction
{
    [SerializeField] private CutboardController _cutboardController;

    protected override bool CheckAction()
    {
        return (_cutboardController.GetFruit()?.GetComponent<FruitStateController>()?.GetFruitState() == FruitState.Full);
    }

    protected override void TakeAction()
    {
        _cutboardController.GetFruit().GetComponent<FruitStateController>().Cut();
    }
}
