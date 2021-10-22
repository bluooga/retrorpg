using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public bool menuOpen = false;
    public GameObject playerMenu;
    public Button autoSelected;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerMenuToggle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerMenuToggle()
    {
        if (menuOpen)
        {
            autoSelected = playerMenu.transform.GetChild(0).GetComponent<Button>();
            playerMenu.SetActive(true);
            autoSelected.Select();
        }
        else
        {
            playerMenu.SetActive(false);
        }
    }
    public void StatsMenuOpen()
    {

    }

}
