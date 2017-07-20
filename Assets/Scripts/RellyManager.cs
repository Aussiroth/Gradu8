﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class RellyManager : MonoBehaviour {

    private List<Relly> jellies = new List<Relly>();
    public GameObject jellyPrefab;

    private float lastSpawn;
    private float deltaSpawn;
    //private float deltaSpawn = Random.Range(1.0f,3.0f); //will result in melon spam

    public Transform trail;
    public GameObject spawnPoint;
    public bool isPaused;
  
    //private const float REQUIRED_SLICEFORCE = 0.0f;
    //private Vector3 lastMousePos;
    private Collider2D[] jelliesCols;

    private void Start()
    {
        jelliesCols = new Collider2D[0];
        isPaused = false;
    }

    private void Update()
    {
        if (isPaused)
            return;

        deltaSpawn = Random.Range(3.0f, 5.0f);
        if (Time.time - lastSpawn > deltaSpawn)
        {
            Relly j = GetJelly();

            j.LaunchJelly(Random.Range(5.0f, 5.0f), Random.Range(-3.0f, 3.0f), spawnPoint.transform.position);
            lastSpawn = Time.time;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))// || CrossPlatformInputManager.GetButton("Fire1")) ---> under testing, two ways of controlling slash
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1;
            trail.transform.position = pos;

            Collider2D[] thisFrameJelly = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Jelly"));
            // if((Input.mousePosition - lastMousePos).sqrMagnitude > REQUIRED_SLICEFORCE)
            //  {	
            foreach (Collider2D c2 in thisFrameJelly)
            {
                for (int i = 0; i < jelliesCols.Length; i++)
                {
                    if (c2 == jelliesCols[i])
                    {
                        c2.GetComponent<Relly>().Slice();
                       
                    }
                }
            }
            // }
            //lastMousePos = Input.mousePosition;
            jelliesCols = thisFrameJelly;

        }
    }

    private Relly GetJelly()
    {
        Relly j = jellies.Find(x => !x.IsActive);

        if (j == null)
        {
            j = Instantiate(jellyPrefab).GetComponent<Relly>();
            jellies.Add(j);
        }

        return j;
    }
}