using UnityEngine;

public class IceDispenserController : DispenserController
{
    [SerializeField] private GameObject _prefabIce;

    public override void AddIngridient()
    {
        item.GetComponent<DrinkController>().AddIngridient(Instantiate(_prefabIce));
    }
}
