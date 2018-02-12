using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blue") ||
            collision.gameObject.CompareTag("Purple") ||
            collision.gameObject.CompareTag("Green") ||
            collision.gameObject.CompareTag("Red"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
    