using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject objectToSpawnPrefab;
	public float spawnDistance = 20f;
    public GameObject scoreTextING;
    PlanetManager planetManager;

    void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(SpawnObjects());
        planetManager = FindObjectOfType<PlanetManager>();

    }

    

    // Update is called once per frame
    void Update()
    {
        scoreTextING.GetComponent<TextMeshProUGUI>().SetText("O " + Mathf.RoundToInt(planetManager.GetScale()).ToString());
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
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    IEnumerator SpawnObjects()
    {
        Vector3 planetPosition = Random.onUnitSphere * 20f;
		Instantiate(objectToSpawnPrefab, planetPosition, Quaternion.identity);

		yield return new WaitForSeconds(1f);

		StartCoroutine(SpawnObjects());
    }
}
