using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFollow : MonoBehaviour
{
    public GameObject target;
    public float distance = 15.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;
        float target_z = target.transform.position.z;

        this.transform.position = new Vector3(target_x, target_y + distance, target_z);
    }
}
