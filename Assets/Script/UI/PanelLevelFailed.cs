using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelLevelFailed : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public int currentLv;
    public GameObject Bg1;
    public GameObject Bg2;
    public GameObject panelMain;
    public GameObject panelGamePlay;
    public GameObject panelGameFailed;

    public Button btnHome;
    void Start()
    {
        currentLv = Cake.instance.currentLv;
        btnHome.onClick.AddListener(Home);
    }
    private void Home()
    {
        panelMain.SetActive(true);
        Bg1.SetActive(true);
        Bg2.SetActive(false);
        panelGamePlay.SetActive(false);
        panelGameFailed.SetActive(false);
    }

}
