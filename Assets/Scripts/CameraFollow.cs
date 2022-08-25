using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float camSpeed;
    public float minX, maxX, minY, maxY;
    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newPos = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * camSpeed);
            float ClampX = Mathf.Clamp(newPos.x, minX, maxX);
            float ClampY = Mathf.Clamp(newPos.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
