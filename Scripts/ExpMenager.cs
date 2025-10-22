using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ExpMenager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    public static event Action<int> OnLevelUp;
    private void Start()
    {
        UpdateUI();
    }
    public void GainExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    public void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
        OnLevelUp?.Invoke(3);
    }
    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }

    public void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperience;
    }
    public void OnDiseable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperience;
    }
}
