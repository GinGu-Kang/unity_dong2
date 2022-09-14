using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject hero;
    Transform heroLocation;
    Transform backdooLocation;
    monster_move backdoo;
    // Monster_move monster_move;

    // Start is called before the first frame update
    void Start()
    {
        heroLocation = hero.transform;
        backdoo = GameObject.Find("Backdoo").GetComponent<monster_move>();
        backdooLocation = backdoo.transform;
    }

    // Update is called once per frame
    
    void LateUpdate()
    {
        
        if(!backdoo.gameOver){
            transform.position = new Vector3(heroLocation.position.x,transform.position.y,transform.position.z);
        }else{
            //게임오버시 백두야차 포커싱
            transform.position = new Vector3(backdooLocation.position.x,transform.position.y,transform.position.z);
        }
        
    }
}
