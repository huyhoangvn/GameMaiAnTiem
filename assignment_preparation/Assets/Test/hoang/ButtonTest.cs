using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public void clickButton(string name)
    {
        FindObjectOfType<DialogueManager>().loadDialogues(name);
    }
}
