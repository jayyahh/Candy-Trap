using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_face : MonoBehaviour {

    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mp;
        dir -= (Vector3)transform.position;
        //vector -= (Vector3)transform.position;
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 vector = Input.GetTouch(0).position;
        //vector -= screenPos;
        //mp -= screenPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        if (angle < transform.eulerAngles.z || angle > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
