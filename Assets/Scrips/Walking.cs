using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 1f;
    public float leftRightRange = 2f;
    public float rotationSpeed = 1f;

    public GameObject promptPrefab;

    Vector3 startingPosition;
    bool goingRight = true;
    bool isTurning = false;
    GameObject prompt;

    Quaternion targetRotation;

    void Start()
    {
        startingPosition = transform.position;
        CreatePrompt();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startingPosition.x + leftRightRange)
            {
                goingRight = false;
                targetRotation = Quaternion.Euler(0f, 180f, 0f);
                isTurning = true;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startingPosition.x - leftRightRange)
            {
                goingRight = true;
                targetRotation = Quaternion.Euler(0f, 0f, 0f);
                isTurning = true;
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (isTurning)
        {
            if (!prompt.activeSelf)
            {
                prompt.SetActive(true);
            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }

    void CreatePrompt()
    {
        if (prompt != null)
        {
            Destroy(prompt);
        }
        prompt = Instantiate(promptPrefab, transform);
        prompt.transform.localPosition = Vector3.up * 2f;
        prompt.transform.localRotation = Quaternion.identity;
        prompt.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PromptTrigger"))
        {
            isTurning = false;
            prompt.SetActive(false);
            CreatePrompt();
            isTurning = true;
        }
    }
}