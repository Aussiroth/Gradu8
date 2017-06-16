using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour {

    public int scoreToGive;

    private AudioSource coinSound;

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();//Slightly diff from regular GetComponent
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);//disable gameObject after being picked up
            
            //this if condition is to prevent skipping of coin sounds when multiple coins are picked really fast
            if (coinSound.isPlaying) 
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }
        }
    }
}
