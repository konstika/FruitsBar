using UnityEngine;

public class Guest
{
    private string[] _orderDialog;
    public string[] OrderDialog { get => _orderDialog; private set => _orderDialog = value; }

    private string[] _failOrderDialog;
    public string[] FailOrderDialog { get => _failOrderDialog; private set => _failOrderDialog = value; }

    private string[] _rightOrderDialog;
    public string[] RightOrderDialog { get => _rightOrderDialog; private set => _rightOrderDialog = value; }

    private Ingridient[] _neededIngr;
    private Ingridient[] _acceptIngr;

    public Guest(string[] orderDialog, string[] failOrderDialog,string[] rightOrderDialog, Ingridient[] neededIngr, Ingridient[] acceptIngr) {
        _orderDialog = orderDialog;
        _failOrderDialog = failOrderDialog;
        _rightOrderDialog = rightOrderDialog;
        _neededIngr = neededIngr;
        _acceptIngr = acceptIngr;
    }
    public bool CheckDrink(Drink drink)
    {
        return drink.CheckNeededIngridientsInDrink(_neededIngr) && drink.CheckAcceptIngridientsInDrink(_acceptIngr);
    }
}
