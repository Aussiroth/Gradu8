using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class JellyManager : MonoBehaviour {

    private List<Jelly> jellies = new List<Jelly>();
    public GameObject jellyPrefab;

    private float lastSpawn;
    private float deltaSpawn = 0.5f;
    //private float deltaSpawn = Random.Range(1.0f,3.0f); //will result in melon spam

    //public static JellyManager Instance { set; get;} //create an instance of the JellyManager since JellyManager is not static

    public Transform trail;
    public GameObject spawnPoint;
    public bool isPaused;

    //private const float REQUIRED_SLICEFORCE = 0.0f;
    //private Vector3 lastMousePos;
    private Collider2D[] jelliesCols;
   
    //UI variables
  //  private int score;
    private int lifepoint;
  //  public Text scoreText;
    public Image[] lifepoints;

    private void Awake()
    {
      //  Instance = this;
    }

    private void Start()
    {
        jelliesCols = new Collider2D[0];
        //isPaused = false;
    }

    private void NewGame()
    {
      //  score = 0;
        lifepoint = 3;
        isPaused = false;
    }

    private void Update()
    {
        Debug.Log(isPaused);
        if(isPaused)
            return;
 
        if(Time.time - lastSpawn > deltaSpawn)
        {
            Jelly j = GetJelly();
            
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
                foreach(Collider2D c2 in thisFrameJelly)
                {
                    for(int i = 0; i < jelliesCols.Length; i++)
                    {
                        if(c2 == jelliesCols[i])
                        {
                            c2.GetComponent<Jelly>().Slice();
                        }
                    }
                }
             // }
             //lastMousePos = Input.mousePosition;
                jelliesCols = thisFrameJelly;
           
        }
    }

    /*public void IncrementScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = score.ToString();
    }*/

    private Jelly GetJelly()
    {
        Jelly j = jellies.Find(x => !x.IsActive);

        if(j == null)
        {
            j = Instantiate(jellyPrefab).GetComponent<Jelly>();
            jellies.Add(j);
        }

        return j;
    }

}
