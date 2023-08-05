using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthbar;
    public Image colorFill;
    public float maxHealth = 10;
    public GameObject effectDie;
    public float iFramesDuration;
    public int numberOfflashes;
    private SpriteRenderer spriteRend;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        healthbar.value = maxHealth;
        colorFill.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K)) {
            healthbar.value -= 2;
            
        }
        else*/
        if (Input.GetKeyDown(KeyCode.L))
        {
            healthbar.value += 2;
            Debug.Log(healthbar.value);
            if (healthbar.value <= 6)
            {
                Debug.Log("Mau Vang r nhe:))");
                colorFill.color = Color.yellow;

            }
            if (healthbar.value <= 2)
            {
                Debug.Log("Die r nhe:))");
                colorFill.color = Color.red;
            }
            if (healthbar.value >= maxHealth)
            {
                colorFill.color = Color.green;

            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            TakeDamage(5f);
        }
        if (collision.gameObject.tag == "River")
        {
            TakeDamage(10f);
        }
    }
    public void TakeDamage(float damage)
    {
        healthbar.value -= damage;
        StartCoroutine(Invunerability());

        if (healthbar.value <= 6)
        {
            Debug.Log("Mau Vang r nhe:))");
            colorFill.color = Color.yellow;

        }
        if (healthbar.value <= 2)
        {
            Debug.Log("Mau do:))");
            colorFill.color = Color.red;
        }
        if (healthbar.value <= 0)
        {
            Debug.Log("Die r nhe:))");
            gameObject.SetActive(false);
            
            Instantiate(effectDie, transform.position, Quaternion.identity);
        }
    }

    /////neu va cham vao quai thi bao do mau
    private IEnumerator Invunerability()
    {
        ////??????????????????????
        Physics2D.IgnoreLayerCollision(10, 7, true);
        ///invunerability
        for (int i = 0; i < numberOfflashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));

        }
        Physics2D.IgnoreLayerCollision(10, 7, false);
    }
    ///dam vao bay
  
}
