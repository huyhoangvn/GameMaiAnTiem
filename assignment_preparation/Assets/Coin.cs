using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
/*    public LayerMask ground;*/
/*    private BoxCollider2D box;*/
    private Rigidbody2D rb;
    public int coinPlus = 1;
    public GameObject coinPrefab;
    public GameObject bullet;
    void Start()
    {
/*        box = GetComponent<BoxCollider2D>();*/
        rb = GetComponent<Rigidbody2D>();
        for(int i = 1; i <= coinPlus; i++)
        {
/*            GameObject go = Instantiate((GameObject)Resources.Load("Prefab/Coin", typeof(GameObject)), new Vector3(transform.position.x, transform.position.y + i, 0), Quaternion.identity);*/
            GameObject go = Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + i, 0), Quaternion.identity);
            go.SendMessage("NoDuplication");
            //Or use Invoke("function", params) is also the same
        }
        GameObject bulletForward = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Rigidbody2D rb1 = bulletForward.GetComponent<Rigidbody2D>();
        rb1.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }

    public void NoDuplication()
    {
        coinPlus = 0;
    }

    // Update is called once per frame
    void Update()  
    {
/*        if (Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down    , 0.1f, ground).collider)
        {
            //Use in case you need to know if the coin hit the ground or not
        }*/
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletForward = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Rigidbody2D rb1 = bulletForward.GetComponent<Rigidbody2D>();
            rb1.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    //To check if the coin hit the ground or not when using trigger
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6){
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }*/
}
