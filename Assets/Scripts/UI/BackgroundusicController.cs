using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BackgroundusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayMusic("game1");
    }

    public void PlayMusic(string name)
    {
        var sources = GetComponents<AudioSource>();
        // var result = sources.FirstOrDefault(item => item.clip.name == "game1");
        var result = sources.FirstOrDefault(item => item.clip.name == "game1");
        result.Stop();
        result = sources.FirstOrDefault(item => item.clip.name == name);
        result.Play();


    }

}
