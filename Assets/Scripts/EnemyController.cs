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
	private bool killable = false;

    private float timeStamp;

    void Start () {
        //Added by GMR. More comments inside.
        if (!PlayerController.isDead)
        {
            //This is very redundant. Additionally, by declaring the type of variable before, you're hiding the declared variable above. Here's what I would do:
            Player = GameObject.Find("Player").GetComponent<PlayerController>();
            //And then rename the "other" variable to "Player", and ditch the original "Player" variable. Cheers.

            //GameObject Player = GameObject.Find("Player");
            //other = Player.GetComponent<PlayerController>();
        }
        GameObject Main = GameObject.Find("Main");
        mainother = Main.GetComponent<Main>();
		anim = GetComponent<Animator>();
        //enemyType = 8;
		enemyType = Random.Range(1, 9);
		anim.SetInteger("EnemyAnimState", enemyType);
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
                            Debug.Log("<<<");
                            anim.SetInteger("EnemyAnimState", enemyType + 50);
                            mainother.score = mainother.score + 1;
                            mainother.UpdateScore();
                        }
                    }
                    if (enemyType == 2 || enemyType == 4 || enemyType == 8)
                    {
                        if (Input.GetKeyDown(KeyCode.D) == true)
                        {
                            Debug.Log(">>>");
                            anim.SetInteger("EnemyAnimState", enemyType + 50);
                            mainother.score = mainother.score + 1;
                            mainother.UpdateScore();
                        }
                    }
                }
            }
        }
	}

	public void Vulnerable()
	{
		killable = true;
	}

	public void StruckPlayer()
	{
        killable = false;
        //Added by GMR. If the player isn't dead, try and call the Struck function. If he is dead, then don't call it, will throw a NullRef because the player doesn't exist.
        if(!PlayerController.isDead)
		Player.Struck();
	}

	public void Complete()
	{
		Destroy(GetComponent<Animator>());
		Destroy(gameObject);
	}
}