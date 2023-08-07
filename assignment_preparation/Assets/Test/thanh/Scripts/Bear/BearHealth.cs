using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 3;
    //private Health playerHealth;
    private Animator anim;
    public SpriteRenderer sprite;
    private int count = 0;
    public GameObject effect;
    float currentHealth;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        //  playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(10);
            Instantiate(effect, GameObject.FindWithTag("Bear").transform.position, GameObject.FindWithTag("Bear").transform.localRotation);
        }


    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        count += 1;
        anim.SetBool("Die", true);
        GetComponent<Collider2D>().enabled = false;
        Instantiate(effect, GameObject.FindWithTag("Bear").transform.position, GameObject.FindWithTag("Bear").transform.localRotation);
        this.enabled = false;
    }
    private void Deativate()
    {
        gameObject.SetActive(false);
    }
}
