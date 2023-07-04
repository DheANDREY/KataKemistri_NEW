using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_Controller : MonoBehaviour
{
    public AudioSource sfx;
    public static sound_Controller instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    public AudioClip klikOK;
    public void sfxKlik()
    {
        sfx.PlayOneShot(klikOK);
    }
    public AudioClip sfxSalah;
    public void sfxJawSalah()
    {
        sfx.PlayOneShot(sfxSalah);
    }
    public AudioClip sfxBenar;
    public void sfxJawBenar()
    {
        sfx.PlayOneShot(sfxBenar);
    }
}
