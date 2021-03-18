using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour, ScareObject
{
    public string targetName { get; set; }
    public string objectName;

    public AudioClip scareSound;

    void Start()
    {
        targetName = objectName;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            ActivateObject();
        }
    }

    public void ActivateObject()
    {
        AudioSource.PlayClipAtPoint(scareSound, transform.position);
    }
}
