using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelSelectLevel : MonoBehaviour
{
    public GameObject panelSelecLevel;
    public GameObject panelMain;
    public GameObject panelGamePlay;
    public GameObject Bg1;
    public GameObject Bg2;
    public GameObject LV1;
    public GameObject LV2;
    public GameObject LV3;

    public Button btnBack;
    public Button btnLv1;
    public Button btnLv2;
    public Button btnLv3;
    void Start()
    {
        btnBack.onClick.AddListener(Back);
        btnLv1.onClick.AddListener(lv1);
        btnLv2.onClick.AddListener(lv2);
        btnLv3.onClick.AddListener(lv3);
    }

    private void Back()
    {
        panelSelecLevel.SetActive(false);
        panelMain.SetActive(true);
        Bg1.SetActive(true);
        Bg2.SetActive(false);
    }
    private void lv1()
    {
        panelSelecLevel.SetActive(false);
        LV1.SetActive(true);
        panelGamePlay.SetActive(true);
    }
    private void lv2()
    {
        panelSelecLevel.SetActive(false);
        LV2.SetActive(true);
        panelGamePlay.SetActive(true);
    }
    private void lv3()
    {
        panelSelecLevel.SetActive(false);
        LV3.SetActive(true);
        panelGamePlay.SetActive(true);
    }
}
