using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wife : MonoBehaviour
{
    // Start is called before the first frame update
    public Text orange;
    public Text apple;
    public Text banana;
    public Text watermelon;
    private DialogueManager dialogueManager;
    private bool isGameOver;
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        isGameOver = false;
    }
    private void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (int.Parse(watermelon.text) > 0)
            {
                watermelon.text = "0";
                FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(6);
                isGameOver = true;
            }
            else if (int.Parse(apple.text) > 0)
            {
                apple.text = "0";
                FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(3);
            }
            else if (int.Parse(banana.text) > 0)
            {
                banana.text = "0";
                FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(4);
            }
            else if (int.Parse(orange.text) > 0)
            {
                orange.text = "0";
                FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(5);
            }
            else
            {
                FindObjectOfType<StorySceneManagerLevel1>().loadStoryScenePart(7);
            }
        }
    }
}
