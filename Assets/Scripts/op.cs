using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class op : MonoBehaviour
{
    // Start is called before the first frame update
    public static string optionname="idle";
    public static string prevscene="home";
    void Start()
    {
        
    }


    public void bclick()
    {

        optionname =  EventSystem.current.currentSelectedGameObject.name;
        prevscene = SceneManager.GetActiveScene().name;
        Debug.Log(optionname);
        SceneManager.LoadScene("arscreen");

    }

}
