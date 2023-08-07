using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textFruitsApple;
    private int countFruitsApple = 0;
    public Text textFruitsOrange;
    private int countFruitsOrange = 0;
    public Text textFruitsBanana;
    private int countFruitsBanana = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Apple")
        {
            Destroy(collision.gameObject);
            countFruitsApple++;
            textFruitsApple.text =""+ countFruitsApple;
        }
        if (collision.gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            countFruitsOrange++;
            textFruitsOrange.text = "" + countFruitsOrange;
        }
        if (collision.gameObject.tag == "Banana")
        {
            Destroy(collision.gameObject);
            countFruitsBanana++;
            textFruitsBanana.text = "" + countFruitsBanana;
        }
    }
}
