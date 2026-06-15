using System;
using UnityEngine;

public class Guest
{
    public AchievementIndex Achievement { get; private set; }  
    public string[] OrderDialog { get; private set; }

    public string[] FailOrderDialog { get; private set; }

    public string[] RightOrderDialog { get; private set; }

    public GuestFaces FacesSprites { get; private set; }

    private Ingridient[] _neededIngr;
    private Ingridient[] _acceptIngr;

    public Guest(AchievementIndex achievement, string[] orderDialog, string[] failOrderDialog,string[] rightOrderDialog, GuestFaces facesSprites, Ingridient[] neededIngr, Ingridient[] acceptIngr) {
        Achievement = achievement;
        OrderDialog = orderDialog;
        FailOrderDialog = failOrderDialog;
        RightOrderDialog = rightOrderDialog;
        FacesSprites = facesSprites;
        _neededIngr = neededIngr;
        _acceptIngr = acceptIngr;
    }
    public bool CheckDrink(Drink drink)
    {
        return drink.CheckNeededIngridientsInDrink(_neededIngr) && drink.CheckAcceptIngridientsInDrink(_acceptIngr);
    }
}

[Serializable]
public class GuestFaces {
    public Sprite orderFace;
    public Sprite rightFace;
    public Sprite failFace;
}
