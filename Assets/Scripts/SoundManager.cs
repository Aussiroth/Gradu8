using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource jellyBurst;
    public AudioSource blacklyBurst;
    public AudioSource bellyBurst;
    public AudioSource gellyBurst;
    public AudioSource rellyBurst;
    public AudioSource bombBurst;
    public AudioSource birdSound;

    public AudioSource dragonRoar;

    public AudioSource fullAttackBurst;
	
	void Start () {
      
    }
	
	public void JellyHitSound(int number)
    {
        if (number == 1)
        {
            if (jellyBurst.isPlaying)
            {
                jellyBurst.Stop();
                jellyBurst.Play();
            }
            else
            {
                jellyBurst.Play();
            }

            if (birdSound.isPlaying)
            {
                birdSound.Stop();
                birdSound.Play();
            }
            else
            {
                birdSound.Play();
            }
        }

        if (number == 2)
        {
            if (blacklyBurst.isPlaying)
            {
                blacklyBurst.Stop();
                blacklyBurst.Play();
            }
            else
            {
                blacklyBurst.Play();
            }

            if (birdSound.isPlaying)
            {
                birdSound.Stop();
                birdSound.Play();
            }
            else
            {
                birdSound.Play();
            }
        }

        if (number == 3)
        {
            if (bellyBurst.isPlaying)
            {
                bellyBurst.Stop();
                bellyBurst.Play();
            }
            else
            {
                bellyBurst.Play();
            }

            if (birdSound.isPlaying)
            {
                birdSound.Stop();
                birdSound.Play();
            }
            else
            {
                birdSound.Play();
            }
        }

        if (number == 4)
        {
            if (gellyBurst.isPlaying)
            {
                gellyBurst.Stop();
                gellyBurst.Play();
            }
            else
            {
                gellyBurst.Play();
            }

            if (birdSound.isPlaying)
            {
                birdSound.Stop();
                birdSound.Play();
            }
            else
            {
                birdSound.Play();
            }
        }

        if (number == 5)
        {
            if (rellyBurst.isPlaying)
            {
                rellyBurst.Stop();
                rellyBurst.Play();
            }
            else
            {
                rellyBurst.Play();
            }

            if (birdSound.isPlaying)
            {
                birdSound.Stop();
                birdSound.Play();
            }
            else
            {
                birdSound.Play();
            }
        }
    }

    public void BombHitSound()
    {
        if (bombBurst.isPlaying)
        {
            bombBurst.Stop();
            bombBurst.Play();
        }
        else
        {
            bombBurst.Play();
        }

        if (birdSound.isPlaying)
        {
            birdSound.Stop();
            birdSound.Play();
        }
        else
        {
            birdSound.Play();
        }
    }

    public void DragonRoar()
    {
        dragonRoar.Play();
    }

    public void DragonMute()
    {
        dragonRoar.Stop();
    }

    public void FullAttackSound()
    {
        fullAttackBurst.Play();
    }

}
