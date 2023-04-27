using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    bool playerDetection = false;
    public CharacterController FPScontroller;
    public GameObject prompt;
    public Text dialogueText;
    public List<string> dialogue;
    public GameObject dialoguePanel;
    public Button option1Button;
    public Button option2Button;
    public string option1Scene;
    public string option2Scene;
    bool inDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false);
        dialoguePanel.SetActive(false);
        option1Button.onClick.AddListener(OnOption1Clicked);
        option2Button.onClick.AddListener(OnOption2Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetection && Input.GetButtonDown("Interact") && !inDialogue)
        {
            prompt.SetActive(false);
            dialoguePanel.SetActive(true);
            inDialogue = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(StartDialogue());
        }
    }

    IEnumerator StartDialogue()
    {
        // disable FPSController
        FPScontroller.enabled = false;

        for (int i = 0; i < dialogue.Count; i++)
        {
            dialogueText.text = dialogue[i];
            yield return new WaitForSeconds(1f);
            Debug.Log("stared dialogue");
        }
        dialoguePanel.SetActive(false);
        inDialogue = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // enable FPSController
        FPScontroller.enabled = true;
        Debug.Log("Dialogue ended");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            playerDetection = true;
            Debug.Log("Player entered NPC trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            playerDetection = false;
            inDialogue = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // enable FPSController
            FPScontroller.enabled = true;
            Debug.Log("Player exited NPC trigger");
        }
    }

    void OnOption1Clicked()
    {
        SceneManager.LoadScene(option1Scene);
    }
    void OnOption2Clicked()
    {
        SceneManager.LoadScene(option2Scene);
    }
}














