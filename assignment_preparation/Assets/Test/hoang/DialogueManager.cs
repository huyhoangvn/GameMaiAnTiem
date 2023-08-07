using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue[] currentDialog;
    private GameObject storyObject;
    private int currentIndex;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI storyDialog;
    public UnityEngine.UI.Image characterImage;
    public UnityEngine.UI.Image storyImage;
    public TextMeshProUGUI continuesBtn;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        currentDialog = null;
        currentIndex = 0;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialog == null)
        {
            return;
        }
        //Update Stoty By Time
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentDialog.Length == currentIndex+1)
            {
                closeCanvas();
            } else
            {
                loadNextDialog();
            }
        }
    }

    public void loadNextDialog()
    {
        canvas.SetActive(true);
        if (currentDialog != null)
        {
            currentIndex++;
            setScene();
        }
    }

    public void setScene()
    {
        characterName.text = currentDialog[currentIndex].name;
        storyDialog.text = currentDialog[currentIndex].sentences;
        characterImage.sprite = currentDialog[currentIndex].characterSprite;
        storyImage.sprite = currentDialog[currentIndex].storySprite;
    }

    public void loadDialogues(string storyName)
    {
        storyObject = GameObject.Find(storyName);
        currentDialog = (Dialogue[]) storyObject.GetComponent<DialogueTrigger>().getDialogues().Clone();
        if (currentDialog != null)
        {
            currentIndex = 0;
            setScene();
        }
        canvas.SetActive(true);
    }

    public void closeCanvas()
    {
        canvas.SetActive(false);
    }

    public void openCanvas()
    {
        if (currentDialog == null)
        {
            return;
        }
        canvas.SetActive(true);
    }
}
