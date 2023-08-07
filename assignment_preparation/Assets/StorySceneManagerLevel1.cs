using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySceneManagerLevel1 : MonoBehaviour
{
    public static int storyScenePart = 1;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        loadStoryScenePart(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.getFinished() && Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = 1;
            dialogueManager.closeCanvas();
        }
    }

    public void loadStoryScenePart(int storyScenePart)
    {
        Time.timeScale = 0;
        dialogueManager.loadDialogues("StoryScene" + storyScenePart);
    }
}
