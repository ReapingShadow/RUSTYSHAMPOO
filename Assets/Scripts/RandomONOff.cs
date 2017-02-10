using UnityEngine;
using System.Collections;

public class RandomONOff : MonoBehaviour {

    public AudioSource Audio;
    public AudioClip[] clips;
    public GameObject prefab;
    private bool Played = false;
    public float duration = 2.0f;
    public float Switch;
    public int ClipNum = 0;
  
	void Update ()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        Switch = Mathf.Lerp(0, 30f, lerp);
        if (Switch <= 6f )
        {
            prefab.SetActive(false);
            Played = false;
            
        }
        else
        {
            prefab.SetActive(true);
            if (!Played)
            {
                Audio.PlayOneShot(clips[ClipNum], .1f);
                Played = true;
            }
        }
    }


}
