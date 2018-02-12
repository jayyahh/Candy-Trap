using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_face : MonoBehaviour {
    /*
    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mp;
        dir -= (Vector3)transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < transform.eulerAngles.z || angle > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
*/
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
    /*
    public float speed = 10;
    private Quaternion startingRotation;

    void Start()
    {
        //save the starting rotation
        startingRotation = this.transform.rotation;
    }

    void Update()
    {
        //return back to the starting rotation
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(0));
        }

        //go to 90 degrees with right arrow
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(90));
        }

        //go to -90 degrees with left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(-90));
        }

    }

    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, rotationAmount, 0) * startingRotation;

        while (this.transform.rotation != finalRotation)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime * speed);
            yield return 0;
        }
    }
    */
}
