using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boundary_destroy : MonoBehaviour
{
   
    int countBlue = 0;
    int countRed = 0;
    int countPurple = 0;
    int countGreen = 0;
	int score;
	int bluePoint;
	int redPoint;
	int purplePoint;
	int greenPoint;
	public Text scoreText;
	public GameObject restartbutton;

	int life;
	public Text lifeText;

    private void Start()
    {
		restartbutton.SetActive (false);
		score = 0;
		life = 5;
		bluePoint = 1;
		redPoint = 1;
		purplePoint = 1;
		greenPoint = 1;
		setScore ();
		setLife ();
    }

	void setScore()
	{
		scoreText.text = "Score: " + score.ToString ();
	}

	void setLife()
	{
		lifeText.text = "Lives: " + life.ToString ();
	}



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            countBlue--;
        }
        if (other.gameObject.CompareTag("Red"))
        {
            countRed--;
        }
        if (other.gameObject.CompareTag("Purple"))
        {
            countPurple--;
        }
        if (other.gameObject.CompareTag("Green"))
        {
            countGreen--;
        }

		if (life > 0 && other.gameObject.activeSelf) {
			life--;
		}
		Destroy(other.gameObject);

		setLife ();
		if (life == 0) {
			
			restartbutton.SetActive (true);
		}
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Blue"))
        {
            GameObject blue = collision.gameObject;
            Candy candyblue = blue.GetComponent<Candy>();

		//	if (candyblue.collideOnce == false)
        //  {
                countBlue++;
        //  }
			candyblue.collideOnce = true;


            if (countBlue == 3)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Blue");
                foreach (GameObject target in gameObjects)
                {
					if (target.GetComponent<Candy> ().collideOnce)
						target.SetActive (false);
                    //GameObject.Destroy(target);
                }
				score += bluePoint * 3;
				bluePoint *= 2;
                countBlue = 0;
				setScore ();
            }
        }
        if (collision.gameObject.CompareTag("Red"))
        {
            GameObject red = collision.gameObject;
            Candy candyred = red.GetComponent<Candy>();
			//if (candyred.collideOnce == false)
           // {
                countRed++;
           // }
			candyred.collideOnce = true;

            if (countRed == 3)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Red");
                foreach (GameObject target in gameObjects)
                {
					if (target.GetComponent<Candy>().collideOnce)
						target.SetActive (false);
						//GameObject.Destroy(target);
                }
				score += redPoint * 3;
				redPoint *= 2;
                countRed = 0;
				setScore ();
            }
        }
        if (collision.gameObject.CompareTag("Purple"))
        {
            GameObject purple = collision.gameObject;
            Candy candypurple = purple.GetComponent<Candy>();
		//	if (candypurple.collideOnce == false)
        //    {
                countPurple++;
        //    }
			candypurple.collideOnce = true;

            if (countPurple == 3)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Purple");
                foreach (GameObject target in gameObjects)
                {
					if (target.GetComponent<Candy>().collideOnce)
						target.SetActive (false);
						//GameObject.Destroy(target);
                }
				score += purplePoint * 3;
				purplePoint *= 2;
                countPurple = 0;
				setScore ();
            }
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            
            GameObject green = collision.gameObject;
            Candy candygreen = green.GetComponent<Candy>();
		//	if (candygreen.collideOnce == false)
        //    {
                countGreen++;
        //    }
			candygreen.collideOnce = true;

            if (countGreen == 3)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Green");
                foreach (GameObject target in gameObjects)
                {
					if (target.GetComponent<Candy>().collideOnce)
						target.SetActive (false);
						//GameObject.Destroy(target);
                }
				score += greenPoint * 3;
				greenPoint *= 2;
                countGreen = 0;
				setScore ();
            }
        }
    }
}




    


