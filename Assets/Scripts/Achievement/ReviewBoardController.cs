using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReviewBoardController : MonoBehaviour
{
    private TextMeshProUGUI[] _textFields;
    private AchievementManager _achievementManager = AchievementManager.Instance;
    private Dictionary<AchievementIndex, string> _achievementsRightReview = new Dictionary<AchievementIndex, string>();  
    private Dictionary<AchievementIndex, string> _achievementsFailReview = new Dictionary<AchievementIndex, string>();
    private int _currentAchieveNumber = 0;
    void Start()
    {
        _achievementsRightReview[AchievementIndex.Lemonade] = "Good place";
        _achievementsRightReview[AchievementIndex.Tropical] = "Good luck in business!";
        _achievementsRightReview[AchievementIndex.Blood] = "Interesting";
        _achievementsRightReview[AchievementIndex.PetWater] = "Pet friend";
        _achievementsRightReview[AchievementIndex.Strawberry] = "Real fruits";

        _achievementsFailReview[AchievementIndex.Lemonade] = "Strange place";
        _achievementsFailReview[AchievementIndex.Tropical] = "Work on the idea";
        _achievementsFailReview[AchievementIndex.Blood] = "Not interesting";
        _achievementsFailReview[AchievementIndex.PetWater] = "Pet killer";
        _achievementsFailReview[AchievementIndex.Strawberry] = "Bad imitation";

        _textFields = GetComponentsInChildren<TextMeshProUGUI>();
        _achievementManager.OnSetAchievement += DisplayReview;
    }

    private void DisplayReview(AchievementIndex achievementIndex, bool state) {
        if (_currentAchieveNumber < _textFields.Length) {
            _textFields[_currentAchieveNumber].text = state ? _achievementsRightReview[achievementIndex] : _achievementsFailReview[achievementIndex];
            _currentAchieveNumber++;
        }
    }
}

