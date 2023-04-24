//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NPC : MonoBehaviour
//{
   // public GameObject player;
   // public GameObject prompt;
  //  public string[] conversation;
 //   public string[] option;
 //   public GameObject scenes;

   // bool inRange;
 //   bool talking;
 //   int conversationIndex;
//    int optionIndex;

    // Start is called before the first frame update
 //   void Start()
  //  {
  //      inRange = false;
 //       talking = false;
  //      conversationIndex = 0;
  //      optionIndex = -1;
 //       prompt.SetActive(false);
 //   }

    // Update is called once per frame
  //  void //Update()
  //  {
  //     if (!talking && inRange && Input.GetKeyUp(KeyCode.E))
    //    {
    //        talking = true;
    //        player.GetComponent<FPSController>().enabled = false;
    //        prompt.SetActive(false);
    //        Debug.Log(conversation[conversationIndex]);
   //         conversationIndex++;
   //     }
  //      else if (talking && Input.GetKeyDown(KeyCode.Alpha1))
   //     {
            // select option 1
   //         optionIndex = 0;
   //         EndConversation();
   //     }
    //    else if (talking && Input.GetKeyDown(KeyCode.Alpha2))
   //     {
            // select option 2
    //        optionIndex = 1;
   //         EndConversation();
    //    }
        
   //     void OnTriggerEnter(Collider other)
     //   {
   //        if (other.gameObject == player)
     //      {
     //           inRange = true;
     //           prompt.SetActive(true);
     //      }
    //    }
        
       // void OntriggerExit(Collider other)
      //  {
        //    if (other.gameObject == player) 
        //    {
        //        inRange = false;
       //         prompt.SetActive(false);
        //    }
      //  }
       // void EndConversation()
      //  {
      //      talking = false;
     //       player.GetComponent<FPSController>().enabled = true;
     //       if (optionIndex >= 0)
      //      {
                // change scene based on selected option
      //          scenes[optionIndex].SetActive(true);
       //         gameObject.SetActive(false);
     //       }
      //      else if (conversationIndex < conversation.Length)
     //       {
                // continue conversation with next message
     //           Debug.Log(conversation[conversationIndex]);
     //           conversationIndex++;
       //     }
       //     else
      //      {
                // end conversation
         //       prompt.SetActive(false);
        //    }
   //     }
  //  }



















  //  }






//}

//}
