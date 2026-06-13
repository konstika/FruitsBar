using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class AchievementManager
{
    public static AchievementManager Instance = new AchievementManager();
    private Dictionary<AchievementIndex, bool> _achievements = new Dictionary<AchievementIndex, bool>();

    public event Action<AchievementIndex, bool> OnSetAchievement;

    private AchievementManager() {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) {return; }

        _achievements[AchievementIndex.Lemonade] = false;
        _achievements[AchievementIndex.Tropical] = false;
        _achievements[AchievementIndex.Blood] = false;
        _achievements[AchievementIndex.PetWater] = false;
        _achievements[AchievementIndex.Strawberry] = false;
    }

    public bool GetAchievementState(AchievementIndex achIndex) {
        return _achievements[achIndex];
    }

    public void SetAchievementState(AchievementIndex achievementIndex, bool state) {
        _achievements[achievementIndex] = state;
        OnSetAchievement.Invoke(achievementIndex, state);
    }
}

public enum AchievementIndex
{
    Lemonade,
    Tropical,
    Blood,
    PetWater,
    Strawberry
}
