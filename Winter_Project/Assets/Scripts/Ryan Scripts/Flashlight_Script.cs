using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Script : MonoBehaviour
{
    public GameObject Light;
    public float RotationSpeed;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationZ);
        Light.transform.rotation = Quaternion.Lerp(Light.transform.rotation, targetRotation, Time.deltaTime + RotationSpeed);
    }
}
