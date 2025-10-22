using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;

        switch (skillName)
        {
            case "Max Health Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "Max Health 2":
                StatsManager.Instance.UpdateMaxHealth(2);
                break;
            case "MaxHealth3":
                StatsManager.Instance.UpdateMaxHealth(3);
                break;
            case "Speed":
                StatsManager.Instance.UpdateSpeed(1);
                break;
            case "Stun":
                StatsManager.Instance.UpdateStun(.3f);
                break;
            case "KnockForce":
                StatsManager.Instance.UpdateKnockForce(20);
                break;
            case "KnockbackTime":
                StatsManager.Instance.UpdateKnockTime(.0f);
                break;
            case "Damage increase":
                StatsManager.Instance.UpdateDamage(1);
                break;
            case "Damage2":
                StatsManager.Instance.UpdateDamage(2);
                break;
            case "Damage3":
                StatsManager.Instance.UpdateDamage(3);
                break;
            default:
                Debug.LogWarning("Unknown skill:" + skillName);
                break;
        }
    }    
}
