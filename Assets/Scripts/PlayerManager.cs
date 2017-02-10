using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float weaponID;
    public float InputID;
    public float CharacterID;
    public GameObject player;
    public float health;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public PlayerInterface PlayerInterface;
    public Rigidbody rbody;
    float ForwardVel = 2;
    float forwardInput, SideWaysInput, turnInput;
    // Use this for initialization
    public void Awake()
    {
        playerInput = new PlayerInput(this);
        player = this.gameObject;
        
        
    }
    void Start()
    {
        PlayerInterface = playerInput;
        rbody = player.GetComponentInChildren<Rigidbody>();
    }
    void Update()
    {
        PlayerInterface.UpdateInput();
        Move();

    }
    public void Move()
    {
        if(InputID == 0)
        {
           // forwardInput = Input.GetAxis("Vertical");
            
            //rbody.velocity = transform.forward * forwardInput * ForwardVel;
            
        }
        if(InputID == 1)
        {
            //forwardInput = Input.GetAxis("LYAxis");

            //rbody.velocity = transform.forward * forwardInput * ForwardVel;
        }
    }
}
