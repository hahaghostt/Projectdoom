using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzle : MonoBehaviour
{
    public GameObject redBook;
    public GameObject blueBook;
    public GameObject greenBook;
    public GameObject redSlot;
    public GameObject blueSlot;
    public GameObject greenSlot;
    public GameObject placeHereText;
    public GameObject key;
    public GameObject pickupText;

    bool hasRedBook = false;
    bool hasBlueBook = false;
    bool hasGreenBook = false;
    public bool inReach = false;
    int booksPlaced = 0;

    List<GameObject> placedBooks = new List<GameObject>();

    void Start()
    {
        placeHereText.SetActive(false);
        key.SetActive(false);
        pickupText.SetActive(false);
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            if (redBook != null && redBook.activeSelf)
            {
                if (redBook.GetComponent<book>() != null && redBook.GetComponent<book>().pickedUp) // check if red book has been picked up
                {
                    hasRedBook = true;
                    placedBooks.Add(redBook);
                    redBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Red book has been placed");
                }
            }
            else if (blueBook != null && blueBook.activeSelf)
            {
                if (blueBook.GetComponent<book>() != null && blueBook.GetComponent<book>().pickedUp) // check if blue book has been picked up
                {
                    hasBlueBook = true;
                    placedBooks.Add(blueBook);
                    blueBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Blue book has been placed");
                }
            }
            else if (greenBook != null && greenBook.activeSelf)
            {
                if (greenBook.GetComponent<book>() != null && greenBook.GetComponent<book>().pickedUp) // check if green book has been picked up
                {
                    hasGreenBook = true;
                    placedBooks.Add(greenBook);
                    greenBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Green book has been placed");
                }
            }
            else
            {
                Debug.Log("No book found!");
            }
        }

        if (booksPlaced == 3 && placedBooks[0] == redBook && placedBooks[1] == blueBook && placedBooks[2] == greenBook)
        {
            placeHereText.SetActive(false);
            key.SetActive(true);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            if (redBook.activeSelf || blueBook.activeSelf || greenBook.activeSelf)
            {
                pickupText.SetActive(true);

            }
            else if (hasRedBook && redSlot.activeSelf)
            {
                placeHereText.SetActive(true);

            }
            else if (hasBlueBook && blueSlot.activeSelf)
            {
                placeHereText.SetActive(true);
            }
            else if (hasGreenBook && greenSlot.activeSelf)
            {
                placeHereText.SetActive(true);
            }
            else
            {
                Debug.Log("No object found!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickupText.SetActive(false);
            placeHereText.SetActive(false);

        }
    }
}
