using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ParticleSystem explore = Instantiate(explode, transform.position, transform.rotation);
            explode.Play();
        }
        else if (collision.gameObject.CompareTag("GameOver"))
        {
            Destroy(gameObject);
        }
    }
}
