using UnityEngine;

public class TrashInteraction : Interaction
{
    [SerializeField] private TrashController _trashController;
    [SerializeField] private string _tooltip = "Throw away the {0}";
    [SerializeField] private float _maxActionDistance = 1f;
    protected override bool CheckAction()
    {
        return (!HandStorageController.Instance.IsEmptyHand() && (Vector3.Distance(HandStorageController.Instance.GetItem().transform.position, transform.position) < _maxActionDistance)
            && _trashController.IsEmpty);
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = _tooltip;
        itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
    }

    protected override void TakeAction()
    {
        _trashController.ThrowAway(HandStorageController.Instance.ReleaseItemFromHand());
    }
}
