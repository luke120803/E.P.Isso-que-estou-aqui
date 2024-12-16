using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
public class DialogueManager_01 : MonoBehaviour
{
    public Animator ChatBox;
    public Text dialogueText;
    private Queue<string> sentences;

    public Dialogue_01 dialogue;
///////////////////////////////////////////
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void TriggerDialogue (){
        StartDialogue(  dialogue);
    }
    ///////////////////////////////////////////
    public void StartDialogue(Dialogue_01 dialogue)
    {
        ChatBox.SetBool("chat", true);
 
        sentences.Clear();
 
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    ///////////////////////////////////////////  
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
///////////////////////////////////////////
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f); // VELOCIDADE DO TEXTO
        }
    }
///////////////////////////////////////////
    public	void EndDialogue()
    {
        ChatBox.SetBool("chat", false);
    }

}