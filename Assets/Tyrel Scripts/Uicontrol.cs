using UnityEngine;
 
public class Uicontrol : MonoBehaviour

{

    public Transform target; // The target object to follow

    public float minXRotation = 0f; // Minimum x-axis rotation

    public float maxXRotation = 0f; // Maximum x-axis rotation
 
    void LateUpdate()

    {

        // Ensure the target object is not null

        if (target == null)

            return;
 
        // Set the position to match the target object's position

        transform.position = target.position;
 
        // Get the current rotation of the target object

        Quaternion targetRotation = target.rotation;
 
        // Convert the rotation to Euler angles

        Vector3 eulerAngles = targetRotation.eulerAngles;
 
        // Clamp the rotation on the x-axis

        float clampedXRotation = ClampAngle(eulerAngles.x, minXRotation, maxXRotation);
 
        // Apply the clamped rotation

        transform.rotation = Quaternion.Euler(clampedXRotation, eulerAngles.y, eulerAngles.z);

    }
 
    // Helper function to clamp an angle between a minimum and maximum value

    float ClampAngle(float angle, float min, float max)

    {

        if (angle < -360f)

            angle += 360f;

        if (angle > 360f)

            angle -= 360f;

        return Mathf.Clamp(angle, min, max);

    }

}
