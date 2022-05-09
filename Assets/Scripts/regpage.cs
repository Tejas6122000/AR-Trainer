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

public class regpage : MonoBehaviour
{

    public TMP_InputField nameinput;
    public TMP_InputField emailinput;
    public TMP_InputField passwordinput;
    // public GameObject message;
    public FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    public DatabaseReference reference;
    public DatabaseReference dbref;


    public class User {
        public string username;
        public string email;

        public User() {
        }

        public User(string username, string email) {
            this.username = username;
            this.email = email;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        auth = FirebaseAuth.DefaultInstance;
        reference=FirebaseDatabase.DefaultInstance.RootReference;

        if(auth.CurrentUser!= null){
            SceneManager.LoadScene("home");

        }else{
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void validatedata(){
        string name = nameinput.text;
        string email = emailinput.text;
        string password = passwordinput.text;

        if (name=="")
        {
            // message.GetComponent<Text>().text = "Name Field is empty";
            Debug.Log("Name Field is empty");
        }
        else if (email=="")
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
            // Debug.Log("hua");
            createUser(name,email,password); 
        }

       
    }

    public void createUser(string name,string email,string password){
        
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ", newUser.UserId);
            updateData(email,name);
        });                

    }

    public void updateData(string email, string name){

        dbref = reference.Child("users");
        user=FirebaseAuth.DefaultInstance.CurrentUser;
        User newuser = new User(name,email);
        string json = JsonUtility.ToJson(newuser);
        dbref.Child(user.UserId).SetRawJsonValueAsync(json);
        auth.SignOut();
        logpage();
    }


    public void logpage(){
        SceneManager.LoadScene("Login");
    }

}
