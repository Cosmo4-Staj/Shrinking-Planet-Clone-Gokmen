using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelStarted()
    {
        
    }

    public void OnLevelEnded() // Game Over?
    {
        Application.Quit();
    }

    public void OnLevelCompleted() // Loads the next level
    {
        
    }

    public void OnLevelFailed() // Loads the current scene back on collision with an obstacle.
    {
        
    }
}
