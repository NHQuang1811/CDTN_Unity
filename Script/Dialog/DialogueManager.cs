using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialog UI")]
    [SerializeField] private GameObject dialoguePannel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    public bool dialoguePlaying { get; private set; }
    private static DialogueManager instance;
    private const string SPEAKER_TAG = "speaker";
    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.LogWarning("Found more than one Dialog Manager in the scene ");
    //    }
    //    instance = this;
    //}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        dialoguePlaying = false;
        dialoguePannel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices) 
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        if(dialoguePlaying)
        {
            return;
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Time.timeScale = 0f;
        currentStory = new Story(inkJSON.text);
        dialoguePlaying = true;
        dialoguePannel.SetActive(true);
        ContinueStory();
    }
    private void ExitDialogueMode()
    {
        Time.timeScale = 1f;
        dialoguePlaying = false;
        dialoguePannel.SetActive(false);
        dialogueText.text = "";
    }
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2 ) 
            {
                Debug.Log("Tag could not be approriately pared: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue; 
                    break;
                default:
                    Debug.LogWarning("Tag name not include: " + tag);
                    break;
            }
        }
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count > choices.Length)
        {
            Debug.Log("More choice given than UI can support ");
        }
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        dialogueText.text = currentStory.Continue();
    }
}
