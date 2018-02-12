
using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Generator : MonoBehaviour
{
    public Camera cam;
    public GameObject[] candies;
    public GameObject restartButton;

    private float maxWidth;
    private float maxHeight;

    private void Start()
    {
        if (cam == null)
            cam = Camera.main;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float candyWidth = candies[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - candyWidth;

        Vector3 targetHeight = cam.ScreenToWorldPoint(upperCorner);
        float candyHeight = candies[0].GetComponent<Renderer>().bounds.extents.y;
        maxHeight = targetHeight.y - candyHeight;

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(1.0f);

        while (!restartButton.activeSelf)
        {
            GameObject candy1 = candies[Random.Range(0, 4)];
            GameObject candy2 = candies[Random.Range(0, 4)];
            GameObject candy3 = candies[Random.Range(0, 4)];
            GameObject candy4 = candies[Random.Range(0, 4)];

            Vector3 spawnPosition1 = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                maxHeight,
                0.0f);
            Quaternion spawnRotation = Quaternion.identity;

            Vector3 spawnPosition2 = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            -maxHeight,
            0.0f);

            Vector3 spawnPosition3 = new Vector3(
            maxWidth,
            Random.Range(-maxHeight, maxHeight),
            0.0f);

            Vector3 spawnPosition4 = new Vector3(
            -maxWidth,
            Random.Range(-maxHeight, maxHeight),
            0.0f);


            Instantiate(candy1, spawnPosition1, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
            Instantiate(candy2, spawnPosition2, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
            Instantiate(candy3, spawnPosition3, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
            Instantiate(candy4, spawnPosition4, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
        }
    }
}
