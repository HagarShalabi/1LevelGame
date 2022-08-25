using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera c;
    public float ZoomSpeed;
    public KeyCode button;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(button))
            c.orthographicSize = Mathf.Lerp(c.orthographicSize, 1, Time.deltaTime * ZoomSpeed);
        else
            c.orthographicSize = Mathf.Lerp(c.orthographicSize, 3, Time.deltaTime * ZoomSpeed);
    }
}
