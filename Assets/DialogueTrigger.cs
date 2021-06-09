using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isStartDialogue;

    public bool lastCutscene;

    public int triggerCutScene;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().cutScenes = triggerCutScene;
        FindObjectOfType<DialogueManager>().lastCutscene = lastCutscene;
    }

    private void Update()
    {
        if (isStartDialogue)
        {
            TriggerDialogue();
            isStartDialogue = false;
        }
        
    }
}
