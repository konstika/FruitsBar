using UnityEngine;

public class ItemPutInteraction : Interaction
{
    [SerializeField] private GameObject _item;
    protected override bool CheckAction()
    {
        return true;
    }

    protected override void TakeAction()
    {
        HandStorageController.Instance.TakeItemInHand(_item);
    }
}
