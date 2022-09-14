using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeonwoo_move : MonoBehaviour
{  
    Rigidbody2D rigid;
    int playerSpeed = 2500;
    public bool hideState;
    public float maxBreathGage=500;
    public float breathGage=500;
    public float breathPerSec=0.1f;
    bool isHide=true;

    
    // Start is called before the first frame update
    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.Space) & isHide==true){
            hideState = true;
            playerSpeed = 1000;
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
            breathGage=breathGage-breathPerSec;
            //숨이 0.3 밑으로 떨어지면 충전 다할때까지 기술 사용x
            if(breathGage<0.3){
                isHide = false;
                transform.localScale = new Vector3(1f, 1f, 0);
                playerSpeed = 2500;
                hideState = false;
            }
        }else if (Input.GetKeyUp(KeyCode.Space) & breathGage > 0){
            hideState = false;
            playerSpeed = 2500;
            transform.localScale = new Vector3(1f, 1f, 0);
        }else{
            if(maxBreathGage>breathGage){
                breathGage=breathGage+breathPerSec;
                //숨이 300이상 차면 기술 사용 가능
                if(breathGage>300){
                isHide = true;
            }
            }
            
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime,0,0));
        }
        
    }
}