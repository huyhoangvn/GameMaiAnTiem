using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textFruits;
    private int countFruits = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fruits")
        {
            Destroy(collision.gameObject);
            countFruits++;
            textFruits.text =""+ countFruits;
        }
    }
}
