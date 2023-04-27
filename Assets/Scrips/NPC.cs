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
    public List<AudioClip> audioClips; 
    public GameObject dialoguePanel;
    public Button option1Button;
    public Button option2Button;
    public string option1Scene;
    public string option2Scene;
    bool inDialogue = false;
    bool dialogueCompleted = false;

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
        if (playerDetection && Input.GetButtonDown("Interact") && !inDialogue && !dialogueCompleted)
        {
            prompt.SetActive(false);
            dialoguePanel.SetActive(true);
            dialogueText.enabled = true;
            inDialogue = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(StartDialogue());
        }
        if (dialogueCompleted)
        {
            prompt.SetActive(false);
            dialoguePanel.SetActive(false);
            dialogueText.enabled = false;
        }
    }

    IEnumerator StartDialogue()
    {
        FPScontroller.enabled = false;

        for (int i = 0; i < dialogue.Count; i++)
        {
            dialogueText.text = dialogue[i];
            GetComponent<AudioSource>().PlayOneShot(audioClips[i]); 
            yield return new WaitForSeconds(audioClips[i].length); 
            if (i == dialogue.Count - 1)
            {
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                yield return new WaitUntil(() => option1Button.gameObject.activeSelf == false && option2Button.gameObject.activeSelf == false);
                break;
            }
            yield return new WaitUntil(() => Input.GetButtonDown("Interact"));
        }

        dialoguePanel.SetActive(false);
        inDialogue = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        FPScontroller.enabled = true;
        Debug.Log("Dialogue ended");
        dialogueCompleted = true;
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

            if (!dialogueCompleted)
            {
                dialoguePanel.SetActive(false);
                dialogueText.enabled = false;
            }

            playerDetection = false;
            inDialogue = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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







