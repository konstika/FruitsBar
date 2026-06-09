using UnityEngine;

public class SpiceInteraction : Interaction
{
    [SerializeField] private Ingridient _ingridient;
    [SerializeField] private string _nameIngridient;
    [SerializeField] private string _tooltipt = "Add {0} to the {1}";
    [SerializeField] private  float _maxInteractionDistance = 2f;
    protected override bool CheckAction()
    {
        return HandStorageController.Instance.GetItem()?.GetComponent<DrinkController>()?.Drink != null
            && Vector3.Distance(HandStorageController.Instance.GetItem().transform.position, transform.position) < _maxInteractionDistance;
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = string.Format(_tooltipt, _nameIngridient, HandStorageController.Instance.GetItem().GetComponent<Item>().Name);
    }

    protected override void TakeAction()
    {
        HandStorageController.Instance.GetItem().GetComponent<DrinkController>().AddIngridient(_ingridient, _nameIngridient);
    }
}
