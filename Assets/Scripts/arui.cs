using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class arui : MonoBehaviour
{
    [SerializeField] private Slider _sizeslide;
    [SerializeField] private Slider _speedslide;
    [SerializeField] private Slider _rotateslide;

    public Animator animator;
 
    public GameObject model;
    string prevscene = op.prevscene;
    // Start is called before the first frame update
    void Start()
    {
        string optionname = op.optionname;
        string prevscene = op.prevscene;

        Debug.Log(name);
        model.GetComponent<Animator>().Play(optionname);

        _speedslide.onValueChanged.AddListener((s)=>{
            animator.speed = s;
        });

        _sizeslide.onValueChanged.AddListener((v)=>{
            model.transform.localScale = new Vector3(v,v,v);
        });

        _rotateslide.onValueChanged.AddListener((r)=>{
            model.transform.eulerAngles = new Vector3(0,r,0);
        });
        
    }

    public void back(){
        SceneManager.LoadScene(prevscene);
    }


    public void size(){

    }


}
