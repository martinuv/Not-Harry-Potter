using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlag : MonoBehaviour
{
    [SerializeField] float slowMoTime;
    [SerializeField] string sceneToLoad;

    private bool levelWon;
    private float originalSlowMoTime;

    void Start()
    {
        float originalSlowMoTime = slowMoTime;
    }

    void Update()
    {
        if (levelWon)
        {
            slowMoTime -= Time.deltaTime * 3;
            Time.timeScale = slowMoTime / 4;
        }

        if (levelWon && Time.timeScale < 0.1)
        {
            GameManager.LoadScene(sceneToLoad);
            Time.timeScale = 1;
            levelWon = false;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelWon = true;
        }
	}	
}
