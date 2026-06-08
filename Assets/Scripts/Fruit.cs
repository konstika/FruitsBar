using UnityEngine;

public class Fruit: MonoBehaviour
{
    [SerializeField] private Ingridient _fruitType;
    public Ingridient FruitType
    {
        get => _fruitType;
        private set => _fruitType = value;
    }

    [SerializeField] private string _name;
    public string Name { 
        get => _name;
        private set => _name = value;
    }
    [SerializeField] private Color _color;
    public Color Color
    {
        get => _color;
        private set => _color = value;
    }
}