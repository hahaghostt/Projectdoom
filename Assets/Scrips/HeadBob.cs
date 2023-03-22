using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] float bobFrequency = 2f;
    [SerializeField] float bobAmplitude = 0.1f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] FPSController fpsController;

    float bobTimer = 0f;
    float bobStepCounter = 0f;

    void Update()
    {
        if (fpsController.IsMoving()) // check if the player is moving
        {
            // Calculate head bob amount based on timer and frequency/amplitude settings
            float bobAmount = Mathf.Sin(bobTimer) * bobAmplitude;

            // Apply head bob to camera transform
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, bobAmount, cameraTransform.localPosition.z);

            // Increment timer and step counter
            if (bobStepCounter >= Mathf.PI * 2)
            {
                bobStepCounter = 0;
            }
            else
            {
                bobStepCounter += bobFrequency * Time.deltaTime;
            }

            bobTimer = bobStepCounter;
        }
        else // player is not moving, reset head bob
        {
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, 0f, cameraTransform.localPosition.z);
            bobTimer = 0f;
            bobStepCounter = 0f;
        }
    }
}
