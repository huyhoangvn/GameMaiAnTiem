using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentHealth;
    public float maxHealth = 100f;
    public GameObject effect;

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
        if(currentHealth < 0f)
        {
            Die();
        }
    }
    public void Die()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    
}
