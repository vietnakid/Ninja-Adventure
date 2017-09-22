using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public float moveSpeed;
    public int health, damge, armor;
    public float speed;

    public float direction;
    public Animator myAnimator;
    public Rigidbody2D myRigidbody;
    // Use this for initialization
    public void Awake () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        direction = 1;
    }
	
	// Update is called once per frame
	public void LateUpdate () {
	    //Die
        if (health <= 0 || transform.position.y <= -500)
        {
            health = 0;
            myAnimator.SetBool("dead", true);
            gameObject.layer = 8; // Layer: Dead
        }

        //Direction
        transform.localScale = new Vector3(direction,1,1);
    }

    public void TurnFace(float direction)
    {
        this.direction = direction;
        if (transform.FindChild("HealthBar") != null)
        {
            Transform healthBar = transform.FindChild("HealthBar");
            healthBar.localScale = new Vector3(direction * Mathf.Abs(healthBar.localScale.x), healthBar.localScale.y, healthBar.localScale.z);
        }
    }

    public void Attacked(int damge, float direction)
    {
        if (damge > armor)
        {
            health -= damge - armor;
            //transform.position += new Vector3(direction * (Mathf.Abs(damge) / 5), 0, 0);
            //transform.position += new Vector3(direction, 0, 0);
        }
        else
            health--;
        if (direction != 0)
            TurnFace(-direction);
    }

    public void Regenation(int damge)
    {
        if (damge > armor)
        {
            health += damge - armor;
        }
    }

    public void Attack()
    {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            myAnimator.SetTrigger("attack");
        }
    }


    public void Move(float force)
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            force = 0;
        myAnimator.SetFloat("speed", Mathf.Abs(force));
        force *= moveSpeed;
        myRigidbody.velocity = new Vector2(force, myRigidbody.velocity.y);
    }

    public GameObject bullet;
    public Transform bulletPos;
    public void Shoot()
    {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            myAnimator.SetTrigger("shoot");
        }
    }

    public void SpawnButtle()
    {
        if (direction == 1)
        {
            GameObject x = (GameObject)Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, -90));
            x.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed * 3;
        }
        else
        {
            GameObject x = (GameObject)Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, 90));
            x.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed * 3;

        }
    }
}
