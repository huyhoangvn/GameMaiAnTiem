using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public LayerMask enemyMask;
    private float damageAttack = 20f;
    public Transform pointAttack;
    private float attackRange = 0.5f;
    private float nextTime = 0f;
    private float timeAttack = 1f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Attack();
                nextTime = Time.time + 1f / timeAttack;

            }
        }
        
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(pointAttack.position, attackRange,enemyMask);
        foreach(Collider2D enemy in hit)
        {
            Debug.Log("Attack: "+ enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(110f);
        }
    }
    private void OnDrawGizmos()
    {
        if (pointAttack == null)
            return;
        Gizmos.DrawWireSphere(pointAttack.position, attackRange);
    }
}
