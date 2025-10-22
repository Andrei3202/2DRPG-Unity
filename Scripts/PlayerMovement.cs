using System.Collections;
using UnityEditor.Tilemaps;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator animator;
    private bool isKnockedBack;
    public bool isShooting;
    public Player_Combat player_Combat;

    private void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    }
    void FixedUpdate()
    {
        if (isShooting)
        {
            rb.velocity = Vector2.zero;
        }
        else if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            animator.SetFloat("horizontal", Mathf.Abs(horizontal));
            animator.SetFloat("vertical", Mathf.Abs(vertical));
            rb.velocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy,float force,float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCooldown(stunTime));
    }

    IEnumerator KnockbackCooldown(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity=Vector2.zero;
        isKnockedBack = false;
    }
}
