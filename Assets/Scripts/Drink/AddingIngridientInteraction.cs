using UnityEngine;

public class AddingIngridientInteraction : Interaction
{
    [SerializeField] private DrinkController _drinkController;
    [SerializeField] private string _tooltip = "Add {0} to the {1}";
    protected override bool CheckAction()
    {
        GameObject ingridient = HandStorageController.Instance.GetItem();
        return (ingridient?.GetComponent<FruitStateController>()?.GetFruitState() == FruitState.SlicesKinematic && !_drinkController.IsEmpty());
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = string.Format(_tooltip, HandStorageController.Instance.GetItem().GetComponent<Item>().Name, _drinkController.Name);
    }

    protected override void TakeAction()
    {
        _drinkController.AddIngridient(HandStorageController.Instance.ReleaseItemFromHand());
    }
}
