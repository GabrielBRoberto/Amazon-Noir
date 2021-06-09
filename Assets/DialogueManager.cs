using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public int cutScenes;

    private float currentTimer = 1;

    public bool lastCutscene;

    //Use this for initialization
    private void Start()
    {
        sentences = new Queue<string>();
        dialogueText.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetInteger("CutScenes", cutScenes);

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
        animator.SetInteger("CutScenes", cutScenes + 1);
        if (lastCutscene)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            if (currentTimer < 0)
            {
                DisplayNextSentence();
                currentTimer += 1;
            }
        }
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }

        if(cutScenes == 11)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
