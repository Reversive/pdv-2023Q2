using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Streetlight : MonoBehaviour
{
    
    [SerializeField] private Light _light;

    private double timer;

    private void setTimer()
    {
        timer = Random.Range(1,5);
    }
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        setTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            setTimer();
            _light.enabled = !_light.enabled;
        }

    }
}
