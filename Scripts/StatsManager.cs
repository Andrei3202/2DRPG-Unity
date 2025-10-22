using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public TMP_Text healthText;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackTime;
    public float knockbackForce;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        healthText.text ="HP: " + currentHealth + "/" + maxHealth;
    }
    public void UpdateDamage(int amount)
    {
        damage += amount;
    }
    public void UpdateSpeed(int amount)
    {
        speed += amount;
    }
    public void UpdateStun(float amount)
    {
        stunTime += amount;
    }
    public void UpdateKnockTime(float amount)
    {
        knockbackTime += amount;
    }
    public void UpdateKnockForce(float amount)
    {
        knockbackForce += amount;
    }
}
