using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 1f;
    public float leftRightRange = 2f;
    public float rotationSpeed = 1f;

    Vector3 startingPosition;
    bool goingRight = true;

    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
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
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startingPosition.x - leftRightRange)
            {
                goingRight = true;
                targetRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}