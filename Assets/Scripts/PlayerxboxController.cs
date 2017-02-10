using UnityEngine;
using System.Collections;

public class PlayerxboxController : MonoBehaviour {
    public Animator anim;
    public PlayerManager pm;
    public Renderer rend;
    public GameObject sword;

    private float AttackNum = 0;
    private float durration = 20.0f;
    private Vector3 currentPos;
    private Quaternion rotation;
    public bool Switch = false;
    public Transform resetPoint;
    public bool blocking = false;

    public AudioSource Audio;
    public AudioClip[] hitSounds;

    public bool Dead = false;
    public bool attacking = false;

    public float sensitivityX;
    private float prevX;
    public float sensitivityY;

    public GameObject Cam;
    void Start()
    {
        if (pm.InputID == 1)
        {
            
            anim = gameObject.GetComponentInChildren<Animator>();
          
            //Add sword to gameobject.
            //
        }
        else
            Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            //Debug.Log(attacking);
            //ps4 leftstick x axis is x axis ...rest at 0
            float x = Input.GetAxis("LXAxis");
            //ps4 leftstick y axis is 3rd axis ...rest at 0
            float z = Input.GetAxis("LYAxis");
            //ps4 right trigger rest at -1 axis at 6
           // Debug.Log(Input.GetButtonDown("L3"));
            


            anim.SetFloat("InputX", x);
            anim.SetFloat("InputZ", z);

            
            ControllerSwitch();

            if (Input.GetButtonDown("L3"))
            {
                anim.SetBool("Run", true);
            }
            else if (Input.GetButtonUp("L3"))
            {
                anim.SetBool("Run", false);
            }
            if ((Input.GetButtonDown("RightBumper")))
            {
                Attack(AttackNum);
            }
            else if ((Input.GetButtonUp("RightBumper")))
            {
                
         
                StartCoroutine(waitforattack());
                anim.SetBool("AttackSwitch", false);
                //SwordAttack.SetActive(false);
            }
            if (Input.GetButtonDown("LeftBumper"))
            {
                anim.SetBool("Block", true);
                Debug.Log("gaybox_Block");
                blocking = true;
            }
            else if (blocking && Input.GetButtonUp("LeftBumper"))
            {
                anim.SetBool("Block", false);
                Debug.Log("xbox_Block");
                blocking = false;
            }
            //float rotationX = transform.localEulerAngles.y + Input.GetAxis("RightStickX") * sensitivityX;
            //transform.localEulerAngles = new Vector3(0, rotationX, 0);
           /* if (attacking == false && Switch == false)
            {
                Debug.Log("NotAttacking");
                //Cam.transform.rotation = Quaternion.Euler(21, rotationX, 0);
                //rotation = Cam.transform.rotation;
                //currentPos = Cam.transform.position;
                //prevX = rotationX;


            }

            else if (attacking == true)
            {
                //Debug.Log (currentPos);
                Cam.transform.rotation = rotation;
                Cam.transform.position = currentPos;
                Debug.Log("Attacking");
                //Debug.Log ("TestThis");
                //Debug.Log (Cam.transform.position);
            }
            if (!attacking && Switch == true)
            {
                Debug.Log("SwitchCheck");

                Cam.transform.position = resetPoint.position;
                Cam.transform.rotation = resetPoint.rotation;
                Switch = false;
            }*/
        }
        else if (Dead)
        {

            float lerp = Mathf.Lerp(0, 1, Time.time / durration);
            rend.material.SetFloat("_SliceAmount", lerp);
            anim.SetBool("Dead", true);
        }
    }

    void Attack(float attack)
    {
        
        anim.SetBool("AttackSwitch", true);
        Audio.PlayOneShot(hitSounds[(int)attack], .5f);
        anim.SetFloat("Attack", attack);
        sword.SetActive(true);
        attacking = true;
        Switch = true;
        //SwordAttack.SetActive(true);
    }
    IEnumerator waitforattack()
    {
       
        yield return new WaitForSeconds(2);
        
        attacking = false;
        sword.SetActive(false);

    }
    void ControllerSwitch()
    {

        if (Input.GetButtonDown("A"))
        {
            Debug.Log("X");
            AttackNum = 1;
        }
        else if (Input.GetButtonDown("B"))
        {
            Debug.Log("O");
            AttackNum = 2;
        }
        else if (Input.GetButtonDown("X"))
        {
            Debug.Log("Square");
            AttackNum = 3;
        }
        else if (Input.GetButtonDown("Y"))
        {
            Debug.Log("Triangle");
            AttackNum = 4;
        }
    }
}
