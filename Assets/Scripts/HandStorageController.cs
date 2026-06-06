using Unity.VisualScripting;
using UnityEngine;

public class HandStorageController : MonoBehaviour
{
    public static HandStorageController Instance;
    private GameObject _item;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) { Destroy(gameObject); }
        _item = null;
    }

    public bool IsEmptyHand() { return _item is null; }

    public GameObject GetItem() { return _item; }

    public void TakeItemInHand(GameObject item) { 
        _item = item;
        _item.transform.SetParent(transform, true);
        _item.transform.localPosition = Vector3.zero;
    }

    public GameObject ReleaseItemFromHand() {
        _item.transform.SetParent(null);
        GameObject item = _item;
        _item = null;
        return item;
    }
}
