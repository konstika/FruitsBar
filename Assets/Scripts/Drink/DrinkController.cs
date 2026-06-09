using UnityEngine;

public class DrinkController : Item
{
    private Drink _drink;
    [SerializeField] private Renderer _render;
    [SerializeField] private float _baseFilling = 0.8f;
    [SerializeField] private Transform _fruitPlace;

    public Drink Drink
    {
        get { return _drink; }
        set
        {
            _drink = value;
            _render.material.SetColor("_ColorSide", _drink.Color);
            _render.material.SetColor("_ColorTop", Color.Lerp(_drink.Color, Color.black, 0.5f));
            _render.material.SetFloat("_Filling", _baseFilling);
        }
    }

    public void PourDrink(Drink drink, float filling = -1)
    {
        _drink = drink;
        if (filling == -1) { filling = _baseFilling; }
        UpdateMaterialDrink(filling);
        Name = _drink.Name;
    }

    public void ClearGlass()
    {
        _drink = null;
        _render.material.SetFloat("_Filling", 0f);
    }

    public void UpdateMaterialDrink(float filling = -1)
    {
        if (filling == -1) { filling = _baseFilling; }
        _render.material.SetColor("_ColorSide", _drink.Color);
        _render.material.SetColor("_ColorTop", Color.Lerp(_drink.Color, Color.black, 0.5f));
        _render.material.SetFloat("_Filling", filling);
    }

    public void AddIngridient(GameObject fruit) {
        AddIngridient(fruit.GetComponent<Fruit>().FruitType, fruit.GetComponent<Fruit>().Name);
        fruit.transform.SetParent(_fruitPlace, true);
        fruit.transform.localPosition = Vector3.zero;
    }

    public void AddIngridient(Ingridient ingridient, string name)
    {
        _drink.AddNoDrinkIngridient(ingridient, name);
        Name = _drink.Name;
    }

    public bool IsEmpty() {
        return _drink is null;
    }
}
