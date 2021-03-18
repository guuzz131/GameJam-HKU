using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, ScareObject
{
    public string targetName { get; set; }
    public string objectName;
    public float flikkerTime;

    public Light pointLight;

    void Start()
    {
        targetName = objectName;
        pointLight.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ActivateObject();
        }
    }

    public void ActivateObject()
    {
        StartCoroutine(flikkerLight());
    }

    IEnumerator flikkerLight()
    {
        Debug.Log("Done");
        pointLight.enabled = false;
        yield return new WaitForSeconds(flikkerTime);
        pointLight.enabled = true;
        yield return new WaitForSeconds(flikkerTime);
        pointLight.enabled = false;
        yield return new WaitForSeconds(flikkerTime);
        pointLight.enabled = true;
    }
}
