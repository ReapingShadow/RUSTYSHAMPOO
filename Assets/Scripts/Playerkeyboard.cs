using UnityEngine;
using System.Collections;

public class Playerkeyboard : MonoBehaviour {

    public Animator anim;
    public PlayerManager pm;
    public Renderer rend;
    public GameObject sword;

    private float AttackNum = 0;
    private float durration = 20.0f;
    private Vector3 currentPos;
    private Quaternion rotation;
    public bool Switch= false;
    //public Transform resetPoint;
    public bool blocking = false;
    public AudioSource Audio;
    public AudioClip[] hitSounds;
    public bool Dead = false;
    public bool attacking = false;

    public float sensitivityX;
    private float prevX;
    public float sensitivityY;

    public GameObject Cam;
    void Start () {
        if (pm.InputID == 0)
        {
            anim = gameObject.GetComponentInChildren<Animator>();
            //Add sword to gameobject.
            //
        }
        else
            Destroy(this);
    }

    // Update is called once per frame
    void Update () {
        if (!Dead)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            anim.SetFloat("InputX", x);
            anim.SetFloat("InputZ", z);
            KeyboardNumSwitch();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("Run", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Attack(AttackNum);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("AttackSwitch", false);
                
                StartCoroutine(waitforattack());
                //SwordAttack.SetActive(false);
            }
            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("Block", true);
                blocking = true;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("Block", false);
                blocking = false;
                //SwordAttack.SetActive(false);
            }

            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            transform.localEulerAngles = new Vector3(0, rotationX, 0);

            /* if (attacking == false && Switch == false)
            {
                Debug.Log("NotAttacking");
                Cam.transform.rotation = Quaternion.Euler(21, rotationX, 0);
                rotation = Cam.transform.rotation;
                currentPos = Cam.transform.position;
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
            float lerp = Mathf.Lerp(0, 1, Time.deltaTime / durration);
            rend.material.SetFloat("_SliceAmount", lerp);
            anim.SetBool("Dead", true);

            Debug.Log("you died");
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
    void KeyboardNumSwitch()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            AttackNum = 1;
            
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            AttackNum = 2;
            
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            AttackNum = 3;
           
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            AttackNum = 4;
            
        }
    }
}
