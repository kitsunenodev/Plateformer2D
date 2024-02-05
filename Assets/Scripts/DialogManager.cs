using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogText;
    public static DialogManager instance;

    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("there is more than one instance of DialogManager in the scene");
            return;
        }

        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
    }
}
