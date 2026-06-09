using UnityEngine;

public abstract class DispenserController : MonoBehaviour
{
    [SerializeField] private Transform _place;
    protected GameObject item;

    public enum ModeDispenser
    {
        Water,
        Ice
    }

    public void PutItemInPlace(GameObject i) {
        item = i;
        item.transform.position = _place.position;
    }

    public bool IsEmptyDispenser() { 
        return item is null;
    }

    public GameObject GetItem() {
        return item;
    }

    public GameObject ReleaseItemFromDispenser() { 
        GameObject i = item;
        item = null;
        return i;
    }

    public abstract void AddIngridient();
}
