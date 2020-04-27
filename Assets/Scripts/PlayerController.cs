using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject gameover;
    public GameObject Main;
    public Main main;
    private Animator anim;
    private bool canAttack = true;
    public bool isDead;

    private float timeStamp;

    void Start () {
        main = Main.GetComponent<Main>();
        anim = GetComponent<Animator>();
        anim.SetInteger("AnimState", 0);
    }

        void Update () {

        if (timeStamp <= Time.time)
        {
            if (canAttack == true)
            {
                if (Input.touchCount > 0){

                    Touch touch = Input.GetTouch(0);
                    Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch_Pos.x < 0){

                        anim.SetInteger("AnimState", Random.Range(1, 4));
                        timeStamp = Time.time + 0.365f;

                    } 
                    if (touch_Pos.x > 0){

                        anim.SetInteger("AnimState", Random.Range(11, 14));
                        timeStamp = Time.time + 0.365f;
                    }

                }

            }

        }
    }

/*
	void Update () {
        if (timeStamp <= Time.time)
        {
            if (canAttack == true)
            {
                if (Input.GetKeyDown(KeyCode.A) == true)
                {
                    anim.SetInteger("AnimState", Random.Range(1, 4));

                    timeStamp = Time.time + 0.365f;
                    //Imported Cooldown Code
                }
                if (Input.GetKeyDown(KeyCode.D) == true)
                {
                    anim.SetInteger("AnimState", Random.Range(11, 14));

                    timeStamp = Time.time + 0.365f;
                    //Imported Cooldown Code
                }
                if (Input.GetKeyDown(KeyCode.K) == true)
                {
                    anim.SetInteger("AnimState", 100);
                }
            }
        }
    }
    */

    public void Struck()
    {
        canAttack = false;
        anim.SetInteger("AnimState", 100);
        gameover.SetActive(true);
        main.GameOver();
        //Added by GMR. Sets variable isDead to true. The enemies check this. You'd want to set this false again if you didn't reload the scene. Depends how you handle game overs. In this game, it doesn't matter.
        isDead = true;
    }

    public void SetStanding()
    {
        anim.SetInteger("AnimState", 0);
    }
}