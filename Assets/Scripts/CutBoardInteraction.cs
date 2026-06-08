using UnityEngine;

public class CutBoardInteraction : Interaction
{
    [SerializeField] private CutboardController _cutboardController;
    private Action _action;
    [SerializeField] string _putActionName = "Put it on the cutting board";
    [SerializeField] string _takeActionName = "Take it";
    enum Action { 
        Put,
        Take
    }

    protected override bool CheckAction()
    {
        GameObject item = HandStorageController.Instance.GetItem();
        if (item != null && item.CompareTag("Fruit") && _cutboardController.IsEmptyCutboard()) {
            _action = Action.Put;
            _tooltipMessage = _putActionName;
            return true;
        }
        else if (!_cutboardController.IsEmptyCutboard()) {
            _action = Action.Take;
            _tooltipMessage = _takeActionName;
            return true;
        }
        return false;
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
