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
    public GameObject talkText;
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
        talkText.SetActive(false);
        option1Button.onClick.AddListener(OnOption1Clicked);
        option2Button.onClick.AddListener(OnOption2Clicked);
        dialogueText.gameObject.SetActive(false); // Disable dialogue text on Start
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
        talkText.SetActive(false);

        for (int i = 0; i < dialogue.Count; i++)
        {
            dialogueText.gameObject.SetActive(true); // Enable dialogue text before displaying each line
            dialogueText.text = dialogue[i];
            bool wait = true;
            while (wait)
            {
                if (Input.GetButtonDown("Interact"))
                {
                    wait = false;
                    Debug.Log("Pressed E");
                }
                yield return null;
            }
            dialogueText.gameObject.SetActive(false); // Disable dialogue text after displaying each line
        }

        // Display the buttons after the last line of dialogue
        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);

        // Wait for the player to choose an option
        bool optionChosen = false;
        while (!optionChosen)
        {
            yield return null;
        }

        // Disable the buttons after the player has chosen an option
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);

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
            talkText.SetActive(true);
            playerDetection = true;
            Debug.Log("Player entered NPC trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            talkText.SetActive(false);
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
        Debug.Log("Good");
    }

    void OnOption2Clicked()
    {
        SceneManager.LoadScene(option2Scene);
        Debug.Log("Evil");
    }

}













