using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneManager : MonoBehaviour
{
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.loadDialogues("StoryScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.getFinished() && Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(2);
        }
    }
}
