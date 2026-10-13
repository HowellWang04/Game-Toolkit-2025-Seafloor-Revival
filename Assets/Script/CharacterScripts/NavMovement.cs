using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
public class NavMovement : MonoBehaviour
{
    public Animator animator;
    public Grid grid;
    SelectableObject input;
    Vector3 vector, mouse;
    NavMeshAgent agent;
    float beforex;
    int x, y;
    public bool AfterMove=false,CanMove=true;
    public SpriteRenderer sr;
    //int test=0;
    public bool isMoving()
    {
        if (agent.velocity.magnitude > 0F)
        {
            return true;
        }
        else return false;
    }
    public bool Arrive()
    {
        //Debug.Log(Tiletest.Instance.worldtocell(transform.position));
        //Debug.Log(new Vector3Int(x,y));
        if(Tiletest.Instance.worldtocell(transform.position)==new Vector3Int(x,y))
            return true;
        else return false;
    }
    public bool CanReach(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();
        bool hasPath = agent.CalculatePath(targetPosition, path);

        // 路径必须完整才代表能走到
        return hasPath && path.status == NavMeshPathStatus.PathComplete;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        input = GetComponent<SelectableObject>();
        agent = GetComponent<NavMeshAgent>();
        sr=GetComponent<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving())
        {
            if (beforex >= transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        beforex = transform.position.x;
        animator.SetBool(name = "running", isMoving());
        //动画状态检测

        if (Arrive()&&AfterMove)
        {
            AfterMove=false;
            if (GlobalData.arrayData[x + 500, y + 500] != null)
            {
                GlobalData.arrayData[x + 500, y + 500].ArriveBehavior(this);
            }
        }

        if (input.selected && Input.GetMouseButtonDown(1)&&CanMove)
        {
            mouse = Input.mousePosition;
            mouse.z = 1;

            vector = Camera.main.ScreenToWorldPoint(mouse);

            if (CanReach(vector))
            {
                AfterMove = true;
                agent.SetDestination(vector);

                x = Tiletest.Instance.GetMouseCell().x;
                y = Tiletest.Instance.GetMouseCell().y;
                if (GlobalData.arrayData[x+500, y+500] != null)
                    GlobalData.arrayData[x + 500 , y + 500].GotoBehavior(this);
                //GlobalData.BianLi();
                Debug.Log(x + " " + y);
            }
            else
            {
                Debug.Log("目标点无法到达");
            }
            //GlobalData.arrayData[test, 0] = Tiletest.Instance.GetMouseCell();
            //test++;
            //GlobalData.BianLi();
        }
        
    }
}