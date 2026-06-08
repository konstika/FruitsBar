using UnityEngine;

public class TableInteraction : Interaction
{
    [SerializeField] private string _tooltip = "Put the {0} on the table";
    protected override bool CheckAction()
    {
        return !HandStorageController.Instance.IsEmptyHand();
    }

    protected override void ChooseMessage()
    {
        itemName = HandStorageController.Instance.GetItem().GetComponent<Item>().Name;
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.CompareTag("Table")) {
                GameObject item = HandStorageController.Instance.ReleaseItemFromHand();
                item.transform.position = hit.point;
            }
        }
    }
}
