using NUnit.Framework;
using UnityEngine;

public class FruitStateController : MonoBehaviour
{
    private FruitState _state = FruitState.Full;
    [SerializeField] private GameObject _fullFruit;
    [SerializeField] private GameObject _slicesFruit;

    private void Start()
    {
        _state = FruitState.Full;
        _fullFruit.SetActive(true);
        _slicesFruit.SetActive(false);
    }

    public FruitState GetFruitState() { 
        return _state;
    }

    public void Cut() {
        _state = FruitState.SlicesGravity;
        _fullFruit.SetActive(false);
        _slicesFruit.SetActive(true);
    }

    public void GravityOff() {
        if (_state == FruitState.SlicesGravity)
        {
            _state = FruitState.SlicesKinematic;
            Rigidbody[] slicesRigidbody = _slicesFruit.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody sliceRigidbody in slicesRigidbody)
            {
                sliceRigidbody.isKinematic = true;
                sliceRigidbody.useGravity = false;
            }
        }
    }
}

public enum FruitState
{
    Full,
    SlicesGravity,
    SlicesKinematic
}
