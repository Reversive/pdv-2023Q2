using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void ButtonPlayPressed() => Invoke("LoadEndgameScene", 3f);
   private void LoadEndgameScene() => SceneManager.LoadScene(0);
}
