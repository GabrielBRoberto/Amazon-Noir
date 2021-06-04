using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    //Use this for initialization
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueText.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("CutSceneInicial", true);

        dialogueText.gameObject.SetActive(true);

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
            EndDialogue();

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);

        animator.SetBool("CutSceneInicial", false);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            DisplayNextSentence();
        }
    }
}
