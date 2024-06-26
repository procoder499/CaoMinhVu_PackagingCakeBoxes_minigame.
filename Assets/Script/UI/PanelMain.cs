using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMain : MonoBehaviour
{
    public GameObject panelSelecLevel;
    public GameObject panelMain;
    public GameObject Bg1;
    public GameObject Bg2;
    public Button btnPlay;
    void Start()
    {
        btnPlay.onClick.AddListener(playClicked);
    }

    private void playClicked()
    {
        panelSelecLevel.SetActive(true);
        panelMain.SetActive(false);
        Bg1.SetActive(false);
        Bg2.SetActive(true);
    }
    void Update()
    {
        
    }
}
