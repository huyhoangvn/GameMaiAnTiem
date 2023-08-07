using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentHealth;
    public float maxHealth = 100f;
    public GameObject effect;
    public GameObject health;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth > 0f)
        {
            Instantiate(effect, transform.position, Quaternion.identity);

        }
        if (currentHealth < 0f)
        {
            gameObject.SetActive(false);
            Invoke("Die", 0.3f);
        }
    }
    public void Die()
    {
        Instantiate(health, transform.position, Quaternion.identity);
        
    }
    
}
