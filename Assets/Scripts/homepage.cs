using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class homepage : MonoBehaviour
{

    public FirebaseAuth auth;



    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        if(auth.CurrentUser== null){
            SceneManager.LoadScene("Login");

        }else{
            // SceneManager.LoadScene("Home");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

    public void scenechange(){
        string scenename = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(scenename);
    }



    public void logout(){
        auth.SignOut();
        SceneManager.LoadScene("Login");
    }
}
