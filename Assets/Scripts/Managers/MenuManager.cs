using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void LoadMenuScene() => SceneManager.LoadScene("Menu");
   public void LoadLevelScene() => SceneManager.LoadScene("MainScene");
   public void LoadEndgameScene() => SceneManager.LoadScene("EndGame");
   public void CloseGame() => Application.Quit();
   
}
