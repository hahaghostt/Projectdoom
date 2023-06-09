using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public GameObject redPickup;
    public GameObject bluePickup;
    public GameObject greenPickup;

    public AudioSource placeIn;
    public AudioSource finish;
    public AudioSource wrong;

    public string myColour;

    bool hasRedBook = false;
    bool hasBlueBook = false;
    bool hasGreenBook = false;
    public bool inReach = false;
    static int booksPlaced = 0;

    List<GameObject> placedBooks = new List<GameObject>();

    void Start()
    {
        placeHereText.SetActive(false);
        key.SetActive(false);
        pickupText.SetActive(false);
    }

    void Update()
    {

        // Debug.Log(redBook == null);
        //Debug.Log(redBook.activeInHierarchy);

        if (inReach && Input.GetButtonDown("Interact"))
        {
            Debug.Log("interacted");
            if (redBook.activeInHierarchy && redBook.activeSelf && myColour == "Red")
            {
                if (redPickup.GetComponent<book>() != null && redPickup.GetComponent<book>().pickedUp) // check if red book has been picked up
                {
                    hasRedBook = true;
                    placedBooks.Add(redBook);
                    redBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Red book has been placed");
                    placeIn.Play();
                }
            }
            else if (blueBook.activeInHierarchy && blueBook.activeSelf && myColour == "Blue" && redSlot.GetComponent<BookPuzzle>().hasRedBook)
            {
                if (bluePickup.GetComponent<book>() != null && bluePickup.GetComponent<book>().pickedUp) // check if blue book has been picked up
                {
                    hasBlueBook = true;
                    placedBooks.Add(blueBook);
                    blueBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Blue book has been placed");
                    placeIn.Play();
                }
            }
            else if (greenBook.activeInHierarchy && greenBook.activeSelf && myColour == "Green" && blueSlot.GetComponent<BookPuzzle>().hasBlueBook)
            {
                if (greenPickup.GetComponent<book>() != null && greenPickup.GetComponent<book>().pickedUp) // check if green book has been picked up
                {
                    hasGreenBook = true;
                    placedBooks.Add(greenBook);
                    greenBook.SetActive(false);
                    booksPlaced++;
                    Debug.Log("Green book has been placed");
                    placeIn.Play();
                }
            }
            else
            {
                Debug.Log("No book found!");
                wrong.Play();
            }
        }

        if (booksPlaced == 3)
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