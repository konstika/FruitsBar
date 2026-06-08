using UnityEngine;

public class ItemBoxInteraction : Interaction
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private string _tooltip = "Take a {0}";

    protected override bool CheckAction()
    {
        return HandStorageController.Instance.IsEmptyHand();
    }

    protected override void ChooseMessage()
    {
        itemName = _itemPrefab.GetComponent<Item>().Name;
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {

        HandStorageController.Instance.TakeItemInHand(Instantiate(_itemPrefab));
    }
}
