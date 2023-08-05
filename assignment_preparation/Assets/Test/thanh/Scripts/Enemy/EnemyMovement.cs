using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public Transform currentPosition;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 5f;
    public float damage = 2f;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPosition = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPosition.position - transform.position;
        if (currentPosition == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);

        }
        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && (currentPosition == pointB.transform))
        {
            Flip();
            currentPosition = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && (currentPosition == pointA.transform))
        {
            Flip();
            currentPosition = pointB.transform;
        }
    }
    private void Flip()
    {
        Vector3 flipx = transform.localScale;
        flipx.x *= -1;
        transform.localScale = flipx;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("Va cham player");
        }
    }
}
