using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    [SerializeField] private GuestDialogController _guestDialogController;
    private AchievementManager _achievementManager = AchievementManager.Instance;


    private string[] _policeDialog = { "Good evening", "Вы ебать подозрительны", "Чем тут торгуете? А?" };
    private string[] _policeDialogBadEnd = { "Everything is clear", "I have to arrest you. Come with me.", "" };
    private string[] _policeDialogGoodEnd = { "I'll be back.", "Good evening", "" };
    private Dictionary<AchievementIndex, string> _achievementsRight = new Dictionary<AchievementIndex, string>();
    private Dictionary<AchievementIndex, string> _achievementsFail = new Dictionary<AchievementIndex, string>();

    [SerializeField] private int _minCorrectOrder = 3;
    private int _currentCorrectOrder = 0;

    private void Start()
    {
        _achievementsRight[AchievementIndex.Lemonade] = "Is it a good place? Yes, yes, of course";
        _achievementsRight[AchievementIndex.Tropical] = "This is a good luck wish... I suspect who it's from";
        _achievementsRight[AchievementIndex.Blood] = "Ah, that crazy guy was here. His presence doesn't improve your situation";
        _achievementsRight[AchievementIndex.PetWater] = "Pet friend? Were there any children here?";
        _achievementsRight[AchievementIndex.Strawberry] = "Real fruit? Yeah, where did you get it from these days?";

        _achievementsFail[AchievementIndex.Lemonade] = "Strange place? How do you explain that?";
        _achievementsFail[AchievementIndex.Tropical] = "These tips... I suspect who gave them to you";
        _achievementsFail[AchievementIndex.Blood] = "Ah, that crazy guy was here. His presence doesn't improve your situation";
        _achievementsFail[AchievementIndex.PetWater] = "Pet killer? But this is a direct accusation";
        _achievementsFail[AchievementIndex.Strawberry] = "Bad imitation? Of course, you don't know what you're selling here";

    }
    public void CreateDialog() {
        List<string> dialogList = new List<string>();
        dialogList.AddRange(_policeDialog);
        dialogList.AddRange(GetAchieveDialog());
        if (_currentCorrectOrder >= _minCorrectOrder)
        {
            dialogList.AddRange(_policeDialogGoodEnd);
        }
        else
        {
            dialogList.AddRange(_policeDialogBadEnd);
        }
        string[] dialog = dialogList.ToArray();
        _guestDialogController.CreateDialog(dialog);
    }

    private string[] GetAchieveDialog() {
        AchievementIndex[] indexes = (AchievementIndex[])Enum.GetValues(typeof(AchievementIndex));
        string[] dialog = new string[indexes.Length];
        for (int i = 0; i < indexes.Length; i++)
        {
            AchievementIndex index = indexes[i];
            dialog[i] = _achievementManager.GetAchievementState(index) ? _achievementsRight[index] : _achievementsFail[index];
            if (_achievementManager.GetAchievementState(index)) { _currentCorrectOrder++; }
        }
        return dialog;
    }
}
