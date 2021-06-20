using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public blockSpawner blockSpawner;
    public TextMeshProUGUI screenText;
    public TextMeshProUGUI scoreText;
    public PlayerMovement playerMovement;
    private GameObject[] spawnedBlocks;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScore;
    private int currentScore;
    public AudioSource theme;
    public AudioSource beat;
    void Start()
    {
        StartCoroutine("startGame");    
    }
    IEnumerator startGame(){
        screenText.text = "Falling in 3s";
        yield return new WaitForSeconds(1f);
        screenText.text = "Falling in 2s";
        yield return new WaitForSeconds(1f);
        screenText.text = "Falling in 1s";
        yield return new WaitForSeconds(1f);
        beat.mute = true;
        beat.playOnAwake = false;
        theme.Play();
        screenText.enabled = false;
        blockSpawner.startFalling();
        playerMovement.startEngines();
    }
    private void Update() {
        if(playerMovement.gameOver){
            endGame();
        }else{
            currentScore = playerMovement.score;
            scoreText.text = "score : " + currentScore;
        }
        
    }
    private void endGame(){
        spawnedBlocks = GameObject.FindGameObjectsWithTag("block");
        foreach (GameObject block in spawnedBlocks)
        {
            block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        blockSpawner.isRunning = false;
        gameOverScreen.SetActive(true);
        gameOverScore.text = "score : " + currentScore;

    }
    public void restartGame(){
        SceneManager.LoadScene("Falling Blocks");
    }
    public void quitGame(){
        SceneManager.LoadScene("Main Menu");
    }
}
