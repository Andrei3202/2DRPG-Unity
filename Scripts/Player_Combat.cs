using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Animator anim;

    public float cooldown = 1;
    private float timer;
    public Transform attackPoint;
    
    public LayerMask enemyLayer;
   

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("IsAttacking", true);


            timer = cooldown;
        }
    }

    public void DealDamage()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0) {
            if (enemies[0].isTrigger)
            {
                return;
            }
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.Instance.damage);
            enemies[0].GetComponent<Enemy_Knockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime);
        }
    }

    public void finishAttacking()
    {
        anim.SetBool("IsAttacking",false);
    }
}
