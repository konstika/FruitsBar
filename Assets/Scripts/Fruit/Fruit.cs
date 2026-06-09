using UnityEngine;

public class Fruit: Item
{
    [SerializeField] private Ingridient _fruitType;
    public Ingridient FruitType
    {
        get => _fruitType;
        private set => _fruitType = value;
    }

    [SerializeField] private Color _color;
    public Color Color
    {
        get => _color;
        private set => _color = value;
    }
}