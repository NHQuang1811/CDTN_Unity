using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public float attackCooldown;
    private bool isShooting = false;
    private float cooldownTimer = Mathf.Infinity;
    public Projectile projectilePrefab;
    public Transform firePoint;
    private void Update()
    {
        if (isShooting == true && cooldownTimer > attackCooldown && !DialogueManager.GetInstance().dialoguePlaying)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    public void isAttack()
    {
        isShooting = true;
    }
    public void isnotAttack()
    {
        isShooting = false;
    }
    private void Attack()
    {
        cooldownTimer = 0;
        Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        AudioManager.Instance.PlaySFX("FireBall");
    }
}
