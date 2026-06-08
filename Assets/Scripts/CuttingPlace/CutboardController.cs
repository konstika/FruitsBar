using UnityEngine;

public class CutboardController : MonoBehaviour
{
    [SerializeField] private Transform _fruitPoint;
    private GameObject _fruit = null;

    public void PutFruitInCutboard(GameObject fruit) {
        _fruit = fruit;
        _fruit.transform.position = _fruitPoint.position;
    }

    public GameObject ReleaseFruitFromCutboard() {
        GameObject fruit = _fruit;
        _fruit = null;
        return fruit;
    }

    public bool IsEmptyCutboard() {
        return _fruit is null;
    }

    public GameObject GetFruit() {
        return _fruit;
    }
}
