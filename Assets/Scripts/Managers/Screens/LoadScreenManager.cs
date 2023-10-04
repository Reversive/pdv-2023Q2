using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScreenManager : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _progressText;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync((int)Enums.Levels.Level_1);
        float progress = 0;
        op.allowSceneActivation = true;
        while (!op.isDone)
        {
            progress = op.progress;
            _progressBar.fillAmount = progress;
            _progressText.text = $"{progress * 100} %";
            yield return null;
        }
    }
}
