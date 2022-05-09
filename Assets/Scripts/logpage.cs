using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class logpage : MonoBehaviour
{

    public TMP_InputField emailinput;
    public TMP_InputField passwordinput;
    public FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    public DatabaseReference reference;
    public DatabaseReference dbref;


    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        if(auth.CurrentUser!= null){
            SceneManager.LoadScene("home");
            

        }else{
            // SceneManager.LoadScene("Home");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void validatelogindata(){
        string email = emailinput.text;
        string password = passwordinput.text;

        
        if (email=="")
        {
            // message.GetComponent<Text>().text = "Email Field is empty";
            Debug.Log("Email Field is empty");

        }
        else if (password=="")
        {
            // message.GetComponent<Text>().text = "Password Field is empty";
            Debug.Log("Password Field is empty");
        }
        else
        {
            Debug.Log(email);
            Debug.Log(password);
            loginUser(email,password); 
        }

       
    }




    public void loginUser(string email,string password){
        
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0}", newUser.UserId);
            SceneManager.LoadScene("home");
        });                

    }    



    public void regpage(){
        SceneManager.LoadScene("Register");
    }
}
