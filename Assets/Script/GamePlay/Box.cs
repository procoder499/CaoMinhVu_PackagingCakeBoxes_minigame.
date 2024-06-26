using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Box : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    public float swipeThreshold = 10f;
    public float moveDistance = 150f;
    public List<int> checkRoute;
    public  int index;
    public int count;
    public int indexCake;

    public static Box instance { get; private set; }
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                endTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        float horizontalMove = endTouchPosition.x - startTouchPosition.x;
        float verticalMove = endTouchPosition.y - startTouchPosition.y;

        if (Mathf.Abs(horizontalMove) > Mathf.Abs(verticalMove))
        {
            // Vuốt ngang
            if (Mathf.Abs(horizontalMove) > swipeThreshold)
            {
                if (horizontalMove > 0 /*&& transform.position.x < 1.75f*/)
                {
                    checkRoute[indexCake = Cake.instance.index] = 1;
                    checkRightSwipe();
                    // Vuốt sang phải
                    for (int i = 0; i < count; i++)
                    {
                        index++;
                        transform.position = new Vector2(transform.position.x + moveDistance, transform.position.y);
                    }
                    checkRoute[indexCake = Cake.instance.index] = 0;
                    // transform.position = new Vector2(transform.position.x + moveDistance, transform.position.y);
                }
                else if (horizontalMove < 0 /*&& transform.position.x > -1.75f*/)
                {
                    checkRoute[indexCake = Cake.instance.index] = 1;
                    checkLeftSwipe();
                    // Vuốt sang trái
                    for (int i = 0; i < count; i++)
                    {
                        index--;
                        transform.position = new Vector2(transform.position.x - moveDistance, transform.position.y);
                    }
                    checkRoute[indexCake = Cake.instance.index] = 0;
                    // transform.position = new Vector2(transform.position.x - moveDistance, transform.position.y);
                }
            }
        }
        else
        {
            // Vuốt dọc
            if (Mathf.Abs(verticalMove) > swipeThreshold)
            {
                if (verticalMove > 0 /*&& transform.position.y < 1.75f*/)
                {
                    // Vuốt lên
                    checkRoute[indexCake = Cake.instance.index] = 1;
                    checkAboveSwipe();
                    for (int i = 0; i < count; i++)
                    {
                        index -= 3;
                        transform.position = new Vector2(transform.position.x, transform.position.y + moveDistance);
                    }
                    checkRoute[indexCake = Cake.instance.index] = 0;
                    // transform.position = new Vector2(transform.position.x, transform.position.y + moveDistance);
                }
                else if (verticalMove < 0 /*&& transform.position.y > -1.75f*/)
                {
                    // Vuốt xuống
                    checkRoute[indexCake = Cake.instance.index] = 1;
                    checkBelowSwipe();
                    for (int i = 0; i < count; i++)
                    {
                        index += 3;
                        transform.position = new Vector2(transform.position.x, transform.position.y - moveDistance);
                    }
                    checkRoute[indexCake = Cake.instance.index] = 0;
                    // transform.position = new Vector2(transform.position.x, transform.position.y - moveDistance);
                }
            }
        }
    }
    private void checkRightSwipe()
    {
        count = 0;
        for (int i = index + 1; i <= index + 2; i++)
        {
            if (index >= 0 && index <= 2)
            {
                if (i <= 2 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else if (index >= 3 && index <= 5)
            {
                if (i <= 5 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else
            {
                if (i <= 8 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }

        }

    }
    private void checkLeftSwipe()
    {
        count = 0;
        for (int i = index - 1; i >= index - 2; i--)
        {
            if (index >= 0 && index <= 2)
            {
                if (i >= 0 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else if (index >= 3 && index <= 5)
            {
                if (i >= 3 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else
            {
                if (i >= 6 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }

        }

    }
    private void checkAboveSwipe()
    {
        count = 0;
        for (int i = index - 3; i >= index - 6; i -= 3)
        {
            if (index == 0 || index == 3 || index == 6)
            {
                if (i >= 0 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else if (index == 1 || index == 4 || index == 7)
            {
                if (i >= 1 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else
            {
                if (i >= 2 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }

        }

    }
    private void checkBelowSwipe()
    {
        count = 0;
        for (int i = index + 3; i <= index + 6; i += 3)
        {
            if (index == 0 || index == 3 || index == 6)
            {
                if (i <= 6 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else if (index == 1 || index == 4 || index == 7)
            {
                if (i <= 7 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }
            else
            {
                if (i <= 8 && checkRoute[i] == 0)
                {
                    count++;
                }
                else break;
            }

        }

    }

}
