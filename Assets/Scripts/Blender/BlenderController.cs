using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BlenderController : MonoBehaviour
{
    private Drink _drink = null;
    private List<GameObject> _fruits = new List<GameObject>();
    [SerializeField] private Transform _fruitPoint;
    [SerializeField] private Renderer _drinkRender;

    public bool WithDrink() {
        return _drink is not null;
    }

    public bool WithFruits() { 
        return _fruits.Count > 0;
    }

    public void PutFruitInBlender(GameObject fruit) {
        _fruits.Add(fruit);
        fruit.transform.position = _fruitPoint.position;
    }

    public void MakeDrink() {
        List<Fruit> fruits = new List<Fruit>();
        foreach (GameObject fruit in _fruits) {
            fruits.Add(fruit.GetComponent<Fruit>());
            Destroy(fruit);
        }
        _drink = new Drink(fruits, _drinkRender, 0.5f);
        _fruits.Clear();
    }

    public Drink GetDrink()
    {
        return _drink;
    }

    public Drink PourOutDrink() {
        Drink drink = _drink;
        _drink = null;
        _drinkRender.material.SetFloat("_Filling", 0f);
        return drink;
    }
}
