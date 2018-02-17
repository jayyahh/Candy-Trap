using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_face : MonoBehaviour {

    public GameObject OurObject; // the object you want to rotate. 

    public float RotationTime = 3f; // In seconds

    public float TouchSpeed;
    public float ClickSpeed; 


    void Update()
    {
        // For click
        if (Input.mousePosition.x < Screen.width / 2)
        {
            StopAllCoroutines();
            StartCoroutine(RotateLeft());
        }
        else if (Input.mousePosition.x > Screen.width / 2)
        {
            StopAllCoroutines();
            StartCoroutine(RotateRight());
        }

        // For tap
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                StopAllCoroutines();
                StartCoroutine(RotateLeft(touch));
            }
            else if (touch.position.x > Screen.width / 2)
            {
                StopAllCoroutines();
                StartCoroutine(RotateRight(touch));
            }
        }
    }

    IEnumerator RotateLeft()
    {
        while (Input.GetMouseButton(0))
        {
            OurObject.transform.Rotate(0, 0, Time.deltaTime * ClickSpeed * 360);
            yield return 0;
        }
    }
    IEnumerator RotateRight()
    {
        while (Input.GetMouseButton(0))
        {
            OurObject.transform.Rotate(0, 0, Time.deltaTime * ClickSpeed * -360);
            yield return 0;
        }
    }

    IEnumerator RotateLeft(Touch touch)
    {
        while (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            OurObject.transform.Rotate(0, 0, Time.deltaTime * TouchSpeed * 360);
            yield return 0;
        }
    }
    IEnumerator RotateRight(Touch touch)
    {
        while (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            OurObject.transform.Rotate(0, 0, Time.deltaTime * TouchSpeed * -360);
            yield return 0;
        }
    }
}
