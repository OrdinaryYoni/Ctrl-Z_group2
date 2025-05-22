using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    public Button interactButton;

    private string[] dialogueLines;
    private int currentLineIndex;

    void Start()
    {
        dialoguePanel.SetActive(false);
        nextButton.onClick.AddListener(ShowNextLine);
    }

    public void StartDialogue(string[] lines)
    {
        if (lines == null || lines.Length == 0) 
        {
            Debug.LogWarning("대사가 없습니다!");
            return;
        }

        dialogueLines = lines;
        currentLineIndex = 0;
        dialoguePanel.SetActive(true);
        ShowNextLine();
    }

    void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        interactButton.gameObject.SetActive(true);
    }
}
