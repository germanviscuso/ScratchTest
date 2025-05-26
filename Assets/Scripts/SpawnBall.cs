using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float force = 5.0f;

    private void Update()
    {  
        // Right Controller Trigger
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            SpawnAndThrowBall(controllerPosition, controllerRotation, controllerRotation * Vector3.forward);
        }
        
        // Left Controller Trigger
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
            SpawnAndThrowBall(controllerPosition, controllerRotation, controllerRotation * Vector3.forward);
        }

        // // Left Hand Pinch Gesture (Index Finger)
        // if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LHand))
        // {
        //     if (OVRInput.GetControllerPositionTracked(OVRInput.Controller.LHand))
        //     {
        //         Vector3 handPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
        //         Quaternion handRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand);
        //         Vector3 throwDirection = handRotation * Vector3.up;
        //         SpawnAndThrowBall(handPosition, handRotation, throwDirection);
        //     }
        // }

        // // Right Hand Pinch Gesture (Index Finger)
        // if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand))
        // {
        //     if (OVRInput.GetControllerPositionTracked(OVRInput.Controller.RHand))
        //     {
        //         Vector3 handPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RHand);
        //         Quaternion handRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand);
        //         Vector3 throwDirection = handRotation * Vector3.down;
        //         SpawnAndThrowBall(handPosition, handRotation, throwDirection);
        //     }
        // }
    }

    private void SpawnAndThrowBall(Vector3 spawnPosition, Quaternion spawnRotation, Vector3 throwDirection)
    {
        if (ballPrefab == null)
        {
            Debug.LogError("Ball prefab is not assigned in the SpawnBall script.");
            return;
        }

        GameObject spawnedBall = Instantiate(ballPrefab, spawnPosition, spawnRotation);
        Rigidbody rigidbody = spawnedBall.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.linearVelocity = throwDirection * force;
        }
        else
        {
            Debug.LogWarning("Spawned ball does not have a Rigidbody component.");
        }
    }
}