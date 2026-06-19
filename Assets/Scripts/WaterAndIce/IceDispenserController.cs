using UnityEngine;

public class IceDispenserController : DispenserController
{
    [SerializeField] private GameObject _prefabIce;
    [SerializeField] private Transform _icePlace;

    public override void AddIngridient()
    {
        item.GetComponent<DrinkController>().AddIngridient(Instantiate(_prefabIce), _icePlace);
        _dispenserAudioSource.Play();
    }
}
