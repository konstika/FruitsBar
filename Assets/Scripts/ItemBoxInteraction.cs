using UnityEngine;

public class ItemBoxInteraction : Interaction
{
    [SerializeField] private GameObject _itemPrefab;

    protected override bool CheckAction()
    {
        return HandStorageController.Instance.IsEmptyHand();
    }

    protected override void TakeAction()
    {

        HandStorageController.Instance.TakeItemInHand(Instantiate(_itemPrefab));
    }
}
