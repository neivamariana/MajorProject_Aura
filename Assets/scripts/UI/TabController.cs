using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TabController : MonoBehaviour 
{
    public Image[] tabImages;
    public GameObject[] pages;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //menu will always open on the first page X)
        ActivateTab(0);
        //arrays always start at 0 not 1 so 0 is the first page 


    }

    public void ActivateTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
            

        }
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;

    }

}
