using UnityEngine;

public class ItemBoxInteraction : Interaction
{
    [SerializeField] private GameObject _item;

    protected override bool CheckAction()
    {
        return HandStorageController.Instance.IsEmptyHand();
    }

    protected override void TakeAction()
    {
        HandStorageController.Instance.TakeItemInHand(_item);
    }
}
