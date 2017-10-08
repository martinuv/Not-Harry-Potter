using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource fireWhoosh;
    [SerializeField] AudioSource freeze;
    [SerializeField] AudioSource death;

    private static SoundController sfx;

    void Awake()
    {
        if (sfx)
        {
            Destroy(this);
        }
        else
        {
            sfx = this;
            DontDestroyOnLoad(sfx);
        }
    }

    public static void PlayWhoosh()
    {
        sfx.fireWhoosh.Play();
    }

    public static void PlayFreeze()
    {
        sfx.freeze.Play();
    }

    public static void PlayDeath()
    {
        sfx.death.Play();
    }
}
