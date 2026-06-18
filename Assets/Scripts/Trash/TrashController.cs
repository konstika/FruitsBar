using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private TrashAnimationController _trashAnimationController;
    [SerializeField] private Transform _rubbishPlace;
    [SerializeField] private Transform _rubbishTargetPlace;
    [SerializeField] private float _fallSpeed = 10f;
    private GameObject _item = null;
    private bool falling = false;
    public bool IsEmpty {
        get { return _item == null; }
        private set { }
    }

    private void Start()
    {
        _trashAnimationController.OnCanFall += FallItem;
        _trashAnimationController.OnEndAnimation += DestroyRubbish;
    }

    private void Update()
    {
        if (falling)
        {
            _item.transform.position = Vector3.Lerp(_item.transform.position, _rubbishTargetPlace.position, Time.deltaTime * _fallSpeed);
            if (Vector3.Distance(_item.transform.position, _rubbishTargetPlace.position) < 0.01f)
            {
                falling = false;
            }
        }
    }

    public void ThrowAway(GameObject item) {
        _item = item;
        _trashAnimationController.AnimateTrash();
        _item.transform.position = _rubbishPlace.position;
    }

    private void FallItem() {
        falling = true;
    }

    private void DestroyRubbish() { 
        Destroy( _item );
        _item = null;
    }
}
