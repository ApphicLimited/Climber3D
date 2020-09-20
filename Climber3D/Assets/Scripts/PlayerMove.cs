using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    public bool hand = false;
    public GameObject righthand, Lefthand;
    

    public bool jumping = false;



    public bool zipliyor;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getir();
        if (Input.GetMouseButtonDown(0))
        {

        }

    }
    public void rightmove()
    {
        righthand.transform.DOMove(new Vector3(righthand.transform.position.x, righthand.transform.position.y + 1, righthand.transform.position.z), 0.4f).OnComplete(righthandback);
        righthand.GetComponent<Animation>().Play("SagKolNew");
    }
    public void leftmove()
    {
        Lefthand.transform.DOMove(new Vector3(Lefthand.transform.position.x, Lefthand.transform.position.y + 1, Lefthand.transform.position.z), 0.4f).OnComplete(lefthandback);
        Lefthand.GetComponent<Animation>().Play("SolKolNew");
    }
    public void lefthandback()
    {
        Lefthand.transform.DOLocalMove(new Vector3(Lefthand.transform.localPosition.x, 0, Lefthand.transform.localPosition.z), 0.2f);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 0.2f).OnComplete(()=>jumping=false);

    }
    public void righthandback()
    {
        righthand.transform.DOLocalMove(new Vector3(righthand.transform.localPosition.x, 0, righthand.transform.localPosition.z), 0.2f);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 0.2f);
    }
    public void jumpDoubleHand()
    {

        righthand.transform.DOMove(new Vector3(righthand.transform.position.x, righthand.transform.position.y + 2, righthand.transform.position.z), 0.3f).OnComplete(righthandback);
        Lefthand.transform.DOMove(new Vector3(Lefthand.transform.position.x, Lefthand.transform.position.y + 2, Lefthand.transform.position.z), 0.3f).OnComplete(lefthandback);
        righthand.GetComponent<Animation>().Play("SagKolNew");
        Lefthand.GetComponent<Animation>().Play("SolKolNew");
    }
    public void getir()
    {

        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
                jumping = true;
                jumpDoubleHand();


            }
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

                Debug.Log("down swipe");


            }
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");



            }
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

                Debug.Log("right swipe");



            }


            if (!jumping)
            {
                if (hand)
                {
                    print("Sag el");
                    rightmove();
                }
                else
                {
                    print("sol el");
                    leftmove();
                }
                hand = !hand;
            }
        }
    }

}
