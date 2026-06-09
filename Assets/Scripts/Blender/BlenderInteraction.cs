using UnityEngine;

public class BlenderInteraction : Interaction
{
    [SerializeField] private string _putActionName = "Put the {0} in the blender";
    [SerializeField] private string _takeActionName = "Pour the {0} into a glass";
    [SerializeField] private BlenderController _blenderController;
    private Action _action;
    enum Action
    {
        Put,
        Take
    }
    protected override bool CheckAction()
    {
        if ((HandStorageController.Instance.GetItem()?.GetComponent<FruitStateController>()?.GetFruitState() == FruitState.SlicesKinematic) && !_blenderController.WithDrink())
        {
            _action = Action.Put;
            return true;
        }
        else if ((HandStorageController.Instance.GetItem()?.tag == "Glass") && _blenderController.WithDrink())
        {
            _action = Action.Take;
            return true;
        }
        return false;
    }

    protected override void ChooseMessage()
    {
        if (_action == Action.Put) {
            tooltipMessage = _putActionName;
            itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
        }
        else if (_action == Action.Take)
        {
            tooltipMessage = _takeActionName;
            itemName = _blenderController.GetDrink().Name;
        }
    }

    protected override void TakeAction()
    {
        if (_action == Action.Put)
        {
            _blenderController.PutFruitInBlender(HandStorageController.Instance.ReleaseItemFromHand());
        }
        else if (_action == Action.Take)
        {
            HandStorageController.Instance.GetItem().GetComponent<DrinkController>().PourDrink(_blenderController.PourOutDrink());
        }
    }
}
