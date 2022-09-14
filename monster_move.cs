using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class monster_move : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public int monsterSpeed = 2000;
    bool randBool;
    float startTime;
    MoveInfo moveInfo;
    public int delayTime=2;
    // Yeonwoo_move yeonwooMove
    yeonwoo_move yeonwoo;
    public bool gameOver = false;



    public struct MoveInfo
    {
        public int timeLimit;
        public bool direction;
    }


    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        defaultMoveSelect();
        yeonwoo = GameObject.Find("Yeonwoo").GetComponent<yeonwoo_move>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(yeonwoo.hideState){
            monstersFindMove();
        }else{
            monstersTrackingMove();
        }
        
    }


    void monstersTrackingMove(){
        float yeonwooX=yeonwoo.transform.position.x;
        float backdooX=transform.position.x;
        //왼쪽
        if(yeonwooX<backdooX){
            transform.Translate(new Vector3(-monsterSpeed * Time.deltaTime,0,0));
        }else if(yeonwooX>backdooX){//오른쪽
            transform.Translate(new Vector3(monsterSpeed * Time.deltaTime,0,0));
        }
    }


    void monstersFindMove()
    {
        // 소요시간
        float timeTaken = Time.time - startTime ;
        //소요시간 이동허용시간 보다 크고 딜레이 시간보다 작으면 아무행동 안함
        if (timeTaken > moveInfo.timeLimit & timeTaken < moveInfo.timeLimit+delayTime){
            return;
        }else if(timeTaken > moveInfo.timeLimit+delayTime ){ //걸린시간이 딜레이타임이랑 이동허용시간을 더한시간보다 크면 랜덤 이동방향, 랜덤 이동시간 다시할당
            startTime = Time.time;
            defaultMoveSelect();

        }else{//소요시간이 이동허용시간 보다 작을때  움직임
            move();
        }
    }

    void move(){
        if (moveInfo.direction){
            transform.Translate(new Vector3(monsterSpeed * Time.deltaTime,0,0));
        }
        else{
            transform.Translate(new Vector3(-monsterSpeed * Time.deltaTime,0,0));
        }
    }

    void defaultMoveSelect()
    {
        moveInfo.timeLimit=Random.Range(2,5);
        moveInfo.direction=(Random.value > 0.5f);
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        print(other.gameObject.name);
        if (other.gameObject.name == "Yeonwoo")
        {
            if (yeonwoo.hideState){
                Debug.Log("잡아먹기 실패");
            }else {
                Debug.Log("Game Over");
                gameOver = true;
            }
            
        }
    }

}
