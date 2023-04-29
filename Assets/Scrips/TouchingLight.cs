using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchingLight : MonoBehaviour
{
    public int sceneBuildNumber;
    public LayerMask wallLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            // Check if the line between the light and the player intersects with any walls
            Vector3 lightDir = transform.position - other.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(other.transform.position, lightDir, out hit, lightDir.magnitude, wallLayer))
            {
                // If there is a wall between the light and the player, do nothing
                return;
            }
            SceneManager.LoadScene(sceneBuildNumber);
        }
    }
}