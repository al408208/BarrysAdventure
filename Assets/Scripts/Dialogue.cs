using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string characterName;
    
    [Space]
    [Header("Dialogue")]
    [SerializeField] GameObject dialogueMask;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    
    [Space]
    [SerializeField, Range(0f, 0.1f)] float typingTime;
    

    ReadDataCVS rd;
    
    List<DialogueLine> dialogueLines;

    bool isPlayerInRange;
    bool didDialogueStart;
    int lineIndex;
    int dialogueNumber;
    int firstDialogueLineNumber;
    bool interactuable = true;
    public GameObject elemeto;

    // Start is called before the first frame update
    void Start()
    {
        rd = FindObjectOfType<ReadDataCVS>();
        dialogueLines = rd.GetDialogueLines();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactuable && isPlayerInRange && Input.GetButtonDown("Interaction"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();

            }
            else if (dialogueText.text == dialogueLines[firstDialogueLineNumber + lineIndex].text)
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[firstDialogueLineNumber + lineIndex].text;
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart  = true;
        dialoguePanel.SetActive(true);
        dialogueMask.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (firstDialogueLineNumber + lineIndex + 1< dialogueLines.Count
            && lineIndex < dialogueLines[firstDialogueLineNumber + lineIndex + 1].lineNumber)
        {
            StartCoroutine(ShowLine());
        }
        else 
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMask.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[firstDialogueLineNumber + lineIndex].text)
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (interactuable && collision.gameObject.CompareTag("Player"))
        {
            GetFirstDialogueLine();
            isPlayerInRange = true;
            dialogueMask.SetActive(true);
        }
    }

    private void GetFirstDialogueLine()
    {
        int i = 0;
        bool seguir = true;

        List<DialoguePair> ldp = rd.GetActiveDialogeLine();

        while (i < dialogueLines.Count && seguir)
        {
            if (dialogueLines[i].receptor == characterName)
            {
                foreach (DialoguePair pair in ldp)
                {
                    if (pair.receptor == characterName && pair.dialogueNumber == dialogueLines[i].dialogueNumber)
                    {
                        dialogueNumber = pair.dialogueNumber;
                        firstDialogueLineNumber = i;
                        seguir = false;
                        break;
                    }
                }
            }
            i++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMask.SetActive(false);          
        }
    }

    public void SetInteracuable(bool i)
    {
        interactuable = i;
    }

    public bool IsInteracuable() { return interactuable; }
}