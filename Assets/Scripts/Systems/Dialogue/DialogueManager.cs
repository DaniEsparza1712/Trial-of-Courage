using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public RectTransform dialogueBox;
    public RectTransform pauseRect;
    public RectTransform controlsBox;
    public RectTransform optionsBox;
    public RectTransform content;
    public GameObject optionObject;
    public Button dialogueButton;
    public Animator dialogueAnimator;
    public DialogueTrigger currentTrigger;
    public TMP_Text charName;
    public TMP_Text dialogueText;
    [HideInInspector]
    public List<DialogueSentence> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new List<DialogueSentence>();
    }

    public void ShowDialogue(Dialogue dialogue, string objName){
        dialogueAnimator.SetBool("OnScreen", true);
        EventSystem.current.SetSelectedGameObject(dialogueButton.gameObject);
        pauseRect.gameObject.SetActive(false);
        controlsBox.gameObject.SetActive(false);
        sentences.Clear();

        foreach(DialogueSentence sentence in dialogue.dialogues){
            sentences.Add(sentence);
        }
        charName.text = objName;
        NextSentece();
    }
    public void NextSentece(){
        if(sentences.Count > 0){
            DialogueSentence dialogueSentence = sentences[0];
            sentences.RemoveAt(0);

            if(dialogueSentence.choices.Length > 0){
                Debug.Log("More than one choice");
                optionsBox.gameObject.SetActive(true);
                dialogueButton.gameObject.SetActive(false);

                int counter = 0;
                foreach(DialogueChoice choice in dialogueSentence.choices){
                    CreateOptionButton(choice, counter);
                    counter++;
                }
            }
            else{
                optionsBox.gameObject.SetActive(false);
                dialogueButton.gameObject.SetActive(true);
                EventSystem.current.SetSelectedGameObject(dialogueButton.gameObject);
            }
            string sentence = dialogueSentence.sentence;

            StopAllCoroutines();
            StartCoroutine(ShowSentence(sentence));
            int dialogueIndex = currentTrigger.GetDialogueIndex(dialogueSentence);
            if(dialogueIndex != -1){
                currentTrigger.eventHolders[dialogueIndex].unityEvent.Invoke();
            }
        }
        else{
            EndDialogue();
        }
    }
    public IEnumerator ShowSentence(string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue(){
        dialogueAnimator.SetBool("OnScreen", false);
        EventSystem.current.SetSelectedGameObject(null);
        controlsBox.gameObject.SetActive(true);
        pauseRect.gameObject.SetActive(true);
        dialogueButton.gameObject.SetActive(false);

        GameObject.Find("Player").GetComponent<PlayerMachine>().ChangeTo("Idle");
        currentTrigger.endEvent.Invoke();
    }

    void CreateOptionButton(DialogueChoice choice, int optionIndex){
        GameObject optionButton = Instantiate(optionObject);
        optionButton.transform.SetParent(content);
        optionButton.transform.localScale = Vector3.one;


        OptionBox optionBox = optionButton.GetComponent<OptionBox>();
        optionBox.text.text = choice.choice;
        optionBox.dialogueChoiceData = choice;
        optionBox.dialogueManager = this;
        if(optionIndex == 0)
            EventSystem.current.SetSelectedGameObject(optionButton);
    }

    public void ClearOptions(){
        foreach(Transform optionTransform in content){
            Destroy(optionTransform.gameObject);
        }
    }
}
