using UnityEngine;
using TMPro;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] string[] dialogueLines;
    int dialogueIndex = 0;

    public void NextDialogueLine()
    {
        dialogueIndex++;
        dialogueText.text = dialogueLines[dialogueIndex];

    }
}
