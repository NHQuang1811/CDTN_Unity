using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public void OnClick()
    {
        dialogueManager.ContinueStory();
    }
}
