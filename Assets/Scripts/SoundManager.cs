using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource coinSound;
    public AudioSource deathSound;
    public AudioSource jumpSound;

    public AudioSource jellyBurst;
    public AudioSource blacklyBurst;
    public AudioSource bellyBurst;
    public AudioSource gellyBurst;
    public AudioSource rellyBurst;
    public AudioSource bombBurst;

    public AudioSource birdSound;
    public AudioSource birdAfterEffect;

    public AudioSource dragonRoar;
    public AudioSource dragonKill;

    public AudioSource fullAttackBurst;

    public AudioSource damageSound;
    public AudioSource timeHack;
	
	void Start () {
      
    }

    public void CoinBling()
    {
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

    public void DeathSound()
    {
        deathSound.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
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

            if (birdSound.isPlaying || birdAfterEffect.isPlaying)
            {
                birdSound.Stop();
                //birdAfterEffect.Stop();
                birdSound.Play();
                birdAfterEffect.Play();
            }
            else
            {
                birdSound.Play();
                birdAfterEffect.Play();
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

            if (birdSound.isPlaying || birdAfterEffect.isPlaying)
            {
                birdSound.Stop();
                //birdAfterEffect.Stop();
                birdSound.Play();
                birdAfterEffect.Play();
            }
            else
            {
                birdSound.Play();
                birdAfterEffect.Play();
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

            if (birdSound.isPlaying || birdAfterEffect.isPlaying)
            {
                birdSound.Stop();
                //birdAfterEffect.Stop();
                birdSound.Play();
                birdAfterEffect.Play();
            }
            else
            {
                birdSound.Play();
                birdAfterEffect.Play();
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

            if (birdSound.isPlaying || birdAfterEffect.isPlaying)
            {
                birdSound.Stop();
                //birdAfterEffect.Stop();
                birdSound.Play();
                birdAfterEffect.Play();
            }
            else
            {
                birdSound.Play();
                birdAfterEffect.Play();
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

            if (birdSound.isPlaying || birdAfterEffect.isPlaying)
            {
                birdSound.Stop();
                //birdAfterEffect.Stop();
                birdSound.Play();
                birdAfterEffect.Play();
            }
            else
            {
                birdSound.Play();
                birdAfterEffect.Play();
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

        if (birdSound.isPlaying || birdAfterEffect.isPlaying)
        {
            birdSound.Stop();
            //birdAfterEffect.Stop();
            birdSound.Play();
            birdAfterEffect.Play();
        }
        else
        {
            birdSound.Play();
            birdAfterEffect.Play();
        }
    }

    public void DragonRoar()
    {
        if (dragonRoar.isPlaying)
        {

        }
        else
        {
            dragonRoar.Play();
        }
    }

    public void DragonMute()
    {
        dragonRoar.Stop();
    }

    public void DragonKill()
    {
        dragonKill.Play();
    }

    public void FullAttackSound()
    {
        fullAttackBurst.Play();
    }

    public void DamageSound()
    {
        damageSound.Play();
    }

    public void TimeHackStart()
    {
        timeHack.Play();
    }

    public void TimeHackStop()
    {
        timeHack.Stop();
    }

}
