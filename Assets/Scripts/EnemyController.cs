using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    //public GameObject Player;
    //public PlayerController other;
    public PlayerController Player;
    public GameObject Main;
    public Main mainother;
	private Animator anim;
	private int enemyType;
	public bool killable = false;

    private float timeStamp;

    void Start () {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        GameObject Main = GameObject.Find("Main");
        mainother = Main.GetComponent<Main>();
        //enemyType = 8;
    }

	void Update () {
        if (timeStamp <= Time.time)
        {
            if (Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.D) == true)
            {

                timeStamp = Time.time + 0.365f;
                //Imported Cooldown Code

                if (killable == true)
                {
                    if (enemyType == 1 || enemyType == 3 || enemyType == 5 || enemyType == 6 || enemyType == 7)
                    {
                        if (Input.GetKeyDown(KeyCode.A) == true)
                        {
                            //Debug.Log("<<<");
                            anim.SetInteger("EnemyAnimState", enemyType + 50);
                            mainother.score = mainother.score + 1;
                            mainother.UpdateScore();
                        }
                    }
                    if (enemyType == 2 || enemyType == 4 || enemyType == 8)
                    {
                        if (Input.GetKeyDown(KeyCode.D) == true)
                        {
                            //Debug.Log(">>>");
                            anim.SetInteger("EnemyAnimState", enemyType + 50);
                            mainother.score = mainother.score + 1;
                            mainother.UpdateScore();
                        }
                    }
                }
            }
        }
	}
/*
	void Update(){
        if (timeStamp <= Time.time)
        {
            if (Input.touchCount > 0){

                 Touch touch = Input.GetTouch(0);
                 Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);

                 if(touch_Pos.x < 0 || touch_Pos.x > 0){

                     timeStamp = Time.time + 0.365f;


                     if(killable == true)
                     {
                         if (enemyType == 1 || enemyType == 3 || enemyType == 5 || enemyType == 6 || enemyType == 7)
                         {
                             if(touch_Pos.x < 0){

                                 //Debug.Log("<<<");
                                 anim.SetInteger("EnemyAnimState", enemyType + 50);
                                 mainother.score = mainother.score + 1;
                                 mainother.UpdateScore();

                             }

                         }
                         if (enemyType == 2 || enemyType == 4 || enemyType == 8)
                         {
                             if(touch_Pos.x > 0)
                             {
                                  //Debug.Log(">>>");
                                  anim.SetInteger("EnemyAnimState", enemyType + 50);
                                  mainother.score = mainother.score + 1;
                                  mainother.UpdateScore();

                             }

                         }
                     }
                     
                 }

            }

        }

    }
*/

    public void SetType() {
        anim = GetComponent<Animator>();
        enemyType = Random.Range(1, 9);
        anim.SetInteger("EnemyAnimState", enemyType);
    }

	public void Vulnerable()
	{
        Debug.Log("Enemy is killable.");
		killable = true;
	}

	public void StruckPlayer()
	{
        Debug.Log("Enemy attempted to strike.");
        killable = false;
        //Added by GMR. If the player isn't dead, try and call the Struck function. If he is dead, then don't call it, will throw a NullRef because the player doesn't exist.
        if(!Player.isDead)
		    Player.Struck();
	}

	public void Complete()
	{
		Destroy(GetComponent<Animator>());
		Destroy(gameObject);
	}
}