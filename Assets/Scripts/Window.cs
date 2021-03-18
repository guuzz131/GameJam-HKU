using UnityEngine;

public class Window : MonoBehaviour, ScareObject
{
    public string targetName { get; set; }
    public string objectName;

    public AudioClip scareSound;
    public MeshRenderer closedWindowModel;

    private bool isClosed;

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
        if (!isClosed)
        {
            closedWindowModel.enabled = true;
            isClosed = true;
        }
        else
        {
            closedWindowModel.enabled = false;
            isClosed = false;
        }
    }
}
