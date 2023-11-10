using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEAsBugFixer : MonoBehaviour
{
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;
    [SerializeField] Transform topWall;
    [SerializeField] Transform bottomWall;
    [SerializeField] Transform background;
    private void Awake()
    {
        SetWallsPos();
        SetWallsScale();
        SetBackgroundScale();
    }

    void SetWallsPos()
    {
        leftWall.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect, leftWall.position.y, 0);
        rightWall.position = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, rightWall.position.y, 0);
        topWall.position = new Vector3(topWall.position.x, Camera.main.orthographicSize - 0.3f, 0);
        bottomWall.position = new Vector3(bottomWall.position.x, -Camera.main.orthographicSize - 1, 0);
    }

    void SetWallsScale()
    {
        topWall.localScale = new Vector3(2 * Camera.main.orthographicSize * Camera.main.aspect, topWall.localScale.y, 1);
        bottomWall.localScale = new Vector3(2 * Camera.main.orthographicSize * Camera.main.aspect, bottomWall.localScale.y, 1);
    }

    void SetBackgroundScale()
    {
        float scale = Camera.main.orthographicSize * Camera.main.aspect > Camera.main.orthographicSize ?
            Camera.main.orthographicSize * Camera.main.aspect / 6.6f :
            Camera.main.orthographicSize / 5;
        background.localScale = new Vector3(scale * background.localScale.x,scale * background.localScale.y, 1);
    }
}
