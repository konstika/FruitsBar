using UnityEngine;

public class CutBoardInteraction : Interaction
{
    [SerializeField] private CutboardController _cutboardController;
    private Action _action;
    [SerializeField] private string _putActionName = "Put the {0} on the cutting board";
    [SerializeField] private string _takeActionName = "Take the {0}";
    enum Action { 
        Put,
        Take
    }

    protected override bool CheckAction()
    {
        GameObject item = HandStorageController.Instance.GetItem();
        if (item != null && item.CompareTag("Fruit") && _cutboardController.IsEmptyCutboard()) {
            _action = Action.Put;
            return true;
        }
        else if (!_cutboardController.IsEmptyCutboard()) {
            _action = Action.Take;
            return true;
        }
        return false;
    }

    protected override void ChooseMessage()
    {
        if (_action == Action.Put)
        {
            tooltipMessage = _putActionName;
            itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
        }
        else if (_action == Action.Take)
        {
            tooltipMessage = _takeActionName;
            itemName = _cutboardController.GetFruit().GetComponent<Item>().Name;
        }
    }

    protected override void TakeAction()
    {
        if (_action == Action.Put)
        {
            GameObject fruit = HandStorageController.Instance.ReleaseItemFromHand();
            _cutboardController.PutFruitInCutboard(fruit);
        }
        else if (_action == Action.Take)
        {
            GameObject fruit = _cutboardController.ReleaseFruitFromCutboard();
            if (fruit.GetComponent<FruitStateController>().GetFruitState() == FruitState.SlicesGravity)
            {
                fruit.GetComponent<FruitStateController>().GravityOff();
            }
            HandStorageController.Instance.TakeItemInHand(fruit);
        }

    }
}
