using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;
public class MenuManager : MonoBehaviour
{
   public void LoadMenuScene() => SceneManager.LoadScene((int) Levels.MainMenu);
   public void LoadLoadScreen() => SceneManager.LoadScene((int) Levels.LoadScreen);
   public void LoadLevelScene() => SceneManager.LoadScene((int) Levels.Level_1);
   public void LoadEndgameScene() => SceneManager.LoadScene((int) Levels.Defeat);
   public void CloseGame() => Application.Quit();
   
}
