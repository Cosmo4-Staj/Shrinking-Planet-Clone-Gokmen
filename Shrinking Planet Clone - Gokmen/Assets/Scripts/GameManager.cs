using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    public GameObject objectToSpawnPrefab;
    public GameObject deathPanel;
	public float spawnDistance = 20f;
    public GameObject scoreTextING;
    public GameObject scoreTextUI;
    public GameObject joystick;
    PlanetManager planetManager;
    #endregion

    void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        deathPanel.SetActive(false); // deactivates end game panel
        StartCoroutine(SpawnObjects()); // constantly spawns falling stars
        planetManager = FindObjectOfType<PlanetManager>();
    }

    void Update()
    {
        scoreTextING.GetComponent<TextMeshProUGUI>().SetText("O " + Mathf.RoundToInt(planetManager.GetScale()).ToString());
    }

    public void OnLevelStarted()
    {
        SceneManager.LoadScene(1);
    }

    public void OnLevelEnded() // Game Over?
    {
        Application.Quit();
    }

    public void OnLevelCompleted() // Loads the next level
    {
        
    }

    public void GoToMenu() // Loads the menu
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevelFailed() // Loads the current scene back on collision with an obstacle.
    {
        scoreTextUI.GetComponent<TextMeshProUGUI>().SetText("SCoRE: " + Mathf.RoundToInt(planetManager.GetScale()).ToString() + "m");
        scoreTextING.GetComponent<TMP_Text>().enabled = false;
        joystick.SetActive(false);
        Invoke("SetDeathPanelActive", 0.8f);
        planetManager.shrinkSpeed += 0.05f;
    }

    private void SetDeathPanelActive()
    {
        deathPanel.SetActive(true);
    }

    IEnumerator SpawnObjects() // constantly spawns falling stars
    {
        Vector3 planetPosition = Random.onUnitSphere * 20f;
		Instantiate(objectToSpawnPrefab, planetPosition, Quaternion.identity);

		yield return new WaitForSeconds(1f);

		StartCoroutine(SpawnObjects());
    }
}
