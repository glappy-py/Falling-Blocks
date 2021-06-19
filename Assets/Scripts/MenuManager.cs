using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("Falling Blocks");
    }
    
    public void exitGame(){
        Application.Quit();
    }

}
