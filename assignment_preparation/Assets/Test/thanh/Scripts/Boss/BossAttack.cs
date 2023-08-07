using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 4;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }*/
    }
    public void Attack()
    {
        if (!FindObjectOfType<AudioManager>().IsPLaying("bear"))
        {
            FindObjectOfType<AudioManager>().Play("bear");
        }
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

        }
        /*        gameObject.GetComponent<PlayerHealth>().TakeDamage(2f);*/
       // Debug.Log("ATTATATATATAT");
    }
}
