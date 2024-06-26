using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevelCompleted : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public int currentLv;
    public GameObject Bg1;
    public GameObject Bg2;
    public GameObject panelMain;
    public GameObject panelGamePlay;
    public GameObject panelGameCompleted;

    public Button btnHome;
    public Button btnNext;
    void Start()
    {
        currentLv = Cake.instance.currentLv;
        btnHome.onClick.AddListener(Home);
        btnNext.onClick.AddListener(Next);
    }
    private void Home()
    {
        panelMain.SetActive(true);
        Bg1.SetActive(true);
        Bg2.SetActive(false);
        panelGamePlay.SetActive(false);
        panelGameCompleted.SetActive(false);
    }
    private void Next()
    {
        panelGameCompleted.SetActive(false);
        list[currentLv].gameObject.SetActive(false);
        list[currentLv+1].gameObject.SetActive(true);
    }
}
