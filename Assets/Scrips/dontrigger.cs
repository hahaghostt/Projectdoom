using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dontrigger : MonoBehaviour
{
    public Text textComponent;
    public Image Panel;
    public string[] lines;
    public float textSpeed;
    public bool isRunning;

    private int index;


    void Start()
    {
        textComponent.text = string.Empty;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRunning == true)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && isRunning == false)
        {
            isRunning = true;
            Panel.gameObject.SetActive(true);
            StartDialouge();

        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
