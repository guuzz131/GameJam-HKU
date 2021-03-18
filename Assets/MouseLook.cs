using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngleY = 80.0f;
    public float clampAngleX = 80.0f;
    public LayerMask hidelayer;
    private float rotY = 0.0f;
    private float rotX = 0.0f; 

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        //rotX = Mathf.Clamp(rotX, -clampAngleY, clampAngleY);
        //rotY = Mathf.Clamp(rotY, -clampAngleX, clampAngleX);
        Quaternion localRotation = Quaternion.Euler(rotX + transform.parent.transform.rotation.x, rotY + transform.parent.transform.rotation.y, 0.0f);
        transform.rotation = localRotation;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, hidelayer))
            {
                transform.parent.transform.position = hit.collider.transform.position;
                transform.parent.transform.rotation = hit.collider.transform.rotation;
            }
        }
    }
}
