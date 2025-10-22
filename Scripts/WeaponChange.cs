using UnityEngine;

public class WeaponChange : MonoBehaviour
{

    public Player_Combat combat;
    public Player_bow bow;


    void Update()
    {
        if (Input.GetButtonDown("ChangeWeapon"))
        {
            combat.enabled = !combat.enabled;
            bow.enabled = !bow.enabled;
        }
    }
}
