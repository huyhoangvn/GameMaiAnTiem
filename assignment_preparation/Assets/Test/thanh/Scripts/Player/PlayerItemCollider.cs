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
    public Text textFruitsWatermelon;
    private int countFruitsWatermelon = 0;
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
            FindObjectOfType<AudioManager>().Play("pickup");
            Destroy(collision.gameObject);
            countFruitsApple++;
            textFruitsApple.text =""+ countFruitsApple;
        }
        if (collision.gameObject.tag == "Orange")
        {
            FindObjectOfType<AudioManager>().Play("pickup");
            Destroy(collision.gameObject);
            countFruitsOrange++;
            textFruitsOrange.text = "" + countFruitsOrange;
        }
        if (collision.gameObject.tag == "Banana")
        {
            FindObjectOfType<AudioManager>().Play("pickup");
            Destroy(collision.gameObject);
            countFruitsBanana++;
            textFruitsBanana.text = "" + countFruitsBanana;
        }
        if (collision.gameObject.tag == "Watermelon")
        {
            FindObjectOfType<AudioManager>().Play("pickup");
            Destroy(collision.gameObject);
            countFruitsWatermelon++;
            textFruitsWatermelon.text = "" + countFruitsWatermelon;
            FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(2);
        }
    }
}
