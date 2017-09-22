using UnityEngine;
using System.Collections;

public class Player : Character {
    
    public float jumpHeight = 4f;

    private bool isOnGround;
    public bool IsOnGround
    {
        get
        {
            return isOnGround;
        }

        set
        {
            isOnGround = value;
        }
    }

    private float move, moveOnPhone;

    public int energy, knife, propertyPoint, money, experience, level, power;
    //private int health, damge, armor,
    //public float speed;

    private GameObject mainData;
    private CharacterData characterData;

    

    // Use this for initialization
    void Start () {
        mainData = GameObject.Find("MainData");
        characterData = mainData.GetComponent<CharacterData>();
        health = characterData.getHealth();
        damge = characterData.getDamage();
        armor = characterData.getArmor();
        energy = characterData.getEnergy();
        knife = characterData.getInventory(3);
        propertyPoint = characterData.getPropertyPoint();
        money = characterData.getMoney();
        experience = characterData.getExperience();
        level = characterData.getLevel();
        power = characterData.getPower();
        speed = characterData.getSpeed();
        InvokeRepeating("RegenEnergyHealth", 4, 4);

        //myAnimator.speed = speed;
        
        

        moveSpeed = 10 + ((speed - 1) * 2);
	}
	
	// Update is called once per frame
	void Update () {
        //Speed
        if (
                myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Throw") ||
                myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack") ||
                myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play_JumpThrow") ||
                myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play_JumpAttack")
           )
        {
            myAnimator.speed = speed;
        }
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run"))
            myAnimator.speed = moveSpeed / 10;

        //Sync
        characterData.setInventory(3, knife);

        //Move
        move = Input.GetAxis("Horizontal") + moveOnPhone;
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            move = 0;
        if (move > 0) direction = 1;
        if (move < 0) direction = -1;

        //Get down quicker
        if (myRigidbody.velocity.y < 0)
            myRigidbody.velocity += Vector2.down*0.5f;


        //Attack
        if (Input.GetButtonDown("Attack"))
        {
            if (myRigidbody.velocity.y > 0)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            Attack();
        }

        //Throw Knife
        if (Input.GetButtonDown("Throw"))
        {
            if (myRigidbody.velocity.y > 0)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            Shoot();
        }

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Kameha
        if (Input.GetButtonDown("Kameha"))
        {
            if (myRigidbody.velocity.y > 0)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,0);
            Kameha();
        }

        //Use Health Potion
        if (Input.GetButtonDown("UseHealthPotion"))
        {
            UseHealthPotion();
        }

        if (Input.GetButtonDown("UseManaPotion"))
        {
            UseManaPotion();
        }

        myAnimator.SetFloat("jumpDown", myRigidbody.velocity.y);
        myAnimator.SetBool("onGround", isOnGround);
    }

    void FixedUpdate()
    {
        Move(move);

        //ReSpwan if fail down
        if (transform.position.y <= -10)
        {
            health -= (characterData.getHealth() / 10);
            transform.position = Vector3.zero;
        }

        //GetLevel
        if (experience >= characterData.getExpOfLevel(level))
        {
            level++;
            propertyPoint += 1;
        }


        //Constance Health and mana
        if (energy > characterData.getEnergy())
            energy = characterData.getEnergy();

        if (health > characterData.getHealth())
            health = characterData.getHealth();
    }

    void RegenEnergyHealth()
    {
        energy += characterData.getEnergy() / 50;
        health += characterData.getHealth() / 50;
    }

    public void Attack()
    {
        if (energy > 0)
        {
            base.Attack();
        }
    }

    public void Jump()
    {
        if (isOnGround && energy >= 2)
        {
            energy -= 2;
            myAnimator.SetTrigger("jump");
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpHeight);
        }
    }

    public void Shoot()
    {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack") && (knife > 0) && (energy >= 5))
        {
            energy -= 5;
            knife--;
            base.Shoot();
        }
    }
    public GameObject kameha;
    public void Kameha()
    {
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack") && (energy >= 10))
        {
            energy -= 10;
            myAnimator.SetTrigger("attack");
            if (direction == 1)
            {
                GameObject x = (GameObject)Instantiate(kameha, bulletPos.position, Quaternion.Euler(0, 0, -90));
                x.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed * 1.5f;
            }
            else
            {
                GameObject x = (GameObject)Instantiate(kameha, bulletPos.position, Quaternion.Euler(0, 0, 90));
                x.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed * 1.5f;

            }
        }
    }

    public void UseHealthPotion()
    {
        if (characterData.getInventory(1) > 0 && health < characterData.getHealth())
        {
            characterData.setInventory(1, characterData.getInventory(1) - 1);
            health += 50;
        }
    }

    public void UseManaPotion()
    {
        if (characterData.getInventory(2) > 0 && energy < characterData.getEnergy())
        {
            characterData.setInventory(2, characterData.getInventory(2) - 1);
            energy += 50;
        }
    }


    public void MoveOnPhone(float moveButton)
    {
        moveOnPhone = moveButton;
    }

    public void Dead()
    {
        SenceManagement x = mainData.GetComponent<SenceManagement>();
        x.LoadScenes("_StartScene");
    }


    public GameObject playerAttackRange;
    public void ActiveAttack()
    {
        energy--;
        GameObject x = (GameObject) Instantiate(playerAttackRange, transform.position + Vector3.right * (direction * 1.9f), Quaternion.identity);
        x.transform.parent = transform;
        /*
        foreach (Transform child in transform)
            if (child.gameObject.CompareTag("PlayerWeapon"))
                child.gameObject.SetActive(true);
                */
    }

    public void DeActiveAttack()
    {

        foreach (Transform child in transform)
            if (child.gameObject.CompareTag("PlayerWeapon"))
                Destroy(child.gameObject);
                //child.gameObject.SetActive(false);
    }




    public void Sync(int mapLevel)
    {
        characterData.setLevel(level);
        characterData.setMoney(money);
        characterData.setPropertyPoint(propertyPoint);
        characterData.setExperience(experience);
        if (mapLevel + 1 > characterData.getMapPassed())
            characterData.setMapPassed(mapLevel + 1);


        GameObject.Find("MainData").GetComponent<SenceManagement>().LoadScenes("_StartScene");
    }
}
