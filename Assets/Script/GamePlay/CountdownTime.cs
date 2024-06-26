using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTime : MonoBehaviour
{
    private Text txt;

    public float startTime = 45f;
    private float currentTime;
    public GameObject panelGamePlay;
    public GameObject panelGameFailed;

    void Start()
    {
        txt = GetComponent<Text>();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            txt.text = currentTime.ToString();
        }
        else
        {
            panelGamePlay.SetActive(false);
            panelGameFailed.SetActive(true);
        }
    }
}
