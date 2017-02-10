using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {
    private PlayerManager p1;
    private PlayerManager p2;
    public GameObject prefab1S;
    public GameObject prefab1T;
    public GameObject prefab2S;
    public GameObject prefab2T;
    public GameObject SpawnP1;
    public GameObject SpawnP2;
    private bool Spawned1;
    private bool Spawned2;
    // Use this for initialization
    void Start ()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>();
        p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerManager>();
    }

    void PlayerSpawn1()
    {
        if (p1.weaponID == 0)
        {
            if (p1.CharacterID == 0)
            {
                GameObject newObject = Instantiate(prefab1S, SpawnP1.transform.position, SpawnP1.transform.rotation);
                newObject.transform.parent = SpawnP1.transform;
                Spawned1 = true;
            }
            else if (p1.CharacterID == 1)
            {
                GameObject newObject = Instantiate(prefab2S, SpawnP1.transform.position, SpawnP1.transform.rotation);
                newObject.transform.parent = SpawnP1.transform;
                Spawned1 = true;
            }
        }
        else if (p1.weaponID == 1)
        {
            if (p1.CharacterID == 0)
            {
                GameObject newObject = Instantiate(prefab1T, SpawnP1.transform.position, SpawnP1.transform.rotation);
                newObject.transform.parent = SpawnP1.transform;
                Spawned1 = true;
            }
            else if (p1.CharacterID == 1)
            {
                GameObject newObject = Instantiate(prefab2T, SpawnP1.transform.position, SpawnP1.transform.rotation);
                newObject.transform.parent = SpawnP1.transform;
                Spawned1 = true;
            }

        }
    }
    void PlayerSpawn2()
    { if (p2.weaponID == 0)
        {
            if (p2.CharacterID == 0)
            {
                GameObject newObject = Instantiate(prefab1S, SpawnP2.transform.position, SpawnP2.transform.rotation);
                newObject.transform.parent = SpawnP2.transform;
                Spawned2 = true;
            }
            else if (p2.CharacterID == 1)
            {
                GameObject newObject = Instantiate(prefab2S, SpawnP2.transform.position, SpawnP2.transform.rotation);
                newObject.transform.parent = SpawnP2.transform;
                Spawned2 = true;
            }
        }
        else if (p2.weaponID == 1)
        {
            if (p2.CharacterID == 0)
            {
                GameObject newObject = Instantiate(prefab1T, SpawnP2.transform.position, SpawnP2.transform.rotation);
                newObject.transform.parent = SpawnP2.transform;
                Spawned2 = true;
            }
            else if (p2.CharacterID == 1)
            {
                GameObject newObject = Instantiate(prefab2T, SpawnP2.transform.position, SpawnP2.transform.rotation);
                newObject.transform.parent = SpawnP2.transform;
                Spawned2 = true;
            }

        }
    }
    void Update()
    {

        //P1
        if(Spawned1 != true)
            PlayerSpawn1();

        //////////////////////P2
        if (Spawned2 != true)
            PlayerSpawn2();

    }
}
