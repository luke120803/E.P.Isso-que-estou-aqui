using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ADICIONE ESSE SCRIPT NO GAMEOBJECT QUE VOCÊ QUER QUE ATIVE A CAIXA DE DIALOGO
public class EnterChat_01 : MonoBehaviour
{
    public Animator ChatBox;
////////////////////////////////////////////////////////
    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag =="NPC"){
            FindObjectOfType<DialogueManager_01>().TriggerDialogue ();
            ChatBox.SetBool("chat", true);
        }
    }
////////////////////////////////////////////////////////
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag =="NPC"){
            ChatBox.SetBool("chat", false);

        }
    }     

}