using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource soundEffect;
    public AudioClip clickSoundGood;
    public AudioClip clickSoundBad;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(string type)
    {
        if (type == "Good")
        {
            soundEffect.PlayOneShot(clickSoundGood, 0.6f);
        }
        else
        {
            soundEffect.PlayOneShot(clickSoundBad, 0.6f);
        }

    }
}
