using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    [SerializeField] private PuzzleGame _puzzleGame;
    [SerializeField] private GameObject canvas;
    private List<PuzzleGame> puzzleList = new List<PuzzleGame>();
    private Vector2 startPosition = new Vector2(-7.00f, 3.56f);
    private Vector2 offset = new Vector2(1.5f, 1.5f);

    [SerializeField] private LayerMask collisionMask;
    private Ray rayUp,rayDown, rayLeft,rayRight;
    private RaycastHit hit;
    private BoxCollider2D _collider;
    private Vector3 colliderSize;
    private Vector3 colliderCenter;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPuzzle(14);
        SetStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }

    void SpawnPuzzle(int number)
    {
        for (int i = 0; i <= number; i++)
        {
            PuzzleGame puzzle = Instantiate(_puzzleGame, new Vector3(0f, 0f, 0f), Quaternion.identity) as PuzzleGame;
            puzzle.transform.localScale = Vector3.one;
            puzzle.transform.parent = canvas.transform;
            puzzleList.Add(puzzle);
        }
    }

    void SetStartPosition()
    {
        //First row
        puzzleList[0].transform.position = new Vector3(startPosition.x, startPosition.y, 0);
        puzzleList[0].transform.localScale = Vector3.one;
        puzzleList[1].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y, 0);
        puzzleList[1].transform.localScale = Vector3.one;
        puzzleList[2].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y, 0);
        puzzleList[2].transform.localScale = Vector3.one;
        
        //Second row
        puzzleList[3].transform.position = new Vector3(startPosition.x, startPosition.y - offset.y, 0);
        puzzleList[3].transform.localScale = Vector3.one;
        puzzleList[4].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - offset.y, 0);
        puzzleList[4].transform.localScale = Vector3.one;
        puzzleList[5].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - offset.y, 0);
        puzzleList[5].transform.localScale = Vector3.one;
        puzzleList[6].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - offset.y, 0);
        puzzleList[6].transform.localScale = Vector3.one;

        //Third row
        puzzleList[7].transform.position = new Vector3(startPosition.x, startPosition.y - (2 * offset.y), 0);
        puzzleList[7].transform.localScale = Vector3.one;
        puzzleList[8].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (2 * offset.y), 0);
        puzzleList[8].transform.localScale = Vector3.one;
        puzzleList[9].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y), 0);
        puzzleList[9].transform.localScale = Vector3.one;
        puzzleList[10].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (2 * offset.y), 0);
        puzzleList[10].transform.localScale = Vector3.one;

        //Fourth row
        puzzleList[11].transform.position = new Vector3(startPosition.x, startPosition.y - (3 * offset.y), 0);
        puzzleList[11].transform.localScale =Vector3.one;
        puzzleList[12].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (3 * offset.y), 0);
        puzzleList[12].transform.localScale = Vector3.one;
        puzzleList[13].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (3 * offset.y), 0);
        puzzleList[13].transform.localScale = Vector3.one;
        puzzleList[14].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (3 * offset.y), 0);
        puzzleList[14].transform.localScale = Vector3.one;
    }

    void MovePuzzle()
    {
        foreach (PuzzleGame puzzle in puzzleList)
        {
            puzzle.moveAmount = offset;

            if (puzzle.clicked)
            {
                _collider = puzzle.GetComponent<BoxCollider2D>();
                colliderSize = _collider.size;
                colliderCenter = _collider.bounds.center;

                float moveAmount = offset.x;
                float direction = Mathf.Sign(moveAmount);

                float x = (puzzle.transform.position.x + colliderCenter.x - colliderSize.x / 2) +
                          colliderSize.x / 2;
                float yUp = puzzle.transform.position.y + colliderCenter.y + (colliderSize.y / 2 * direction);
                float yDown = puzzle.transform.position.y + colliderCenter.y + (colliderSize.y / 2 * -direction);
                
                rayUp = new Ray(new Vector2(x, yUp), new Vector2(0, direction));
                rayDown = new Ray(new Vector2(x, yDown), new Vector2(0, -direction));
                
                //Draw Rays
                Debug.DrawRay(rayUp.origin, rayUp.direction);
                Debug.DrawRay(rayDown.origin, rayDown.direction);
                
                float y = (puzzle.transform.position.y + colliderCenter.y - colliderSize.y / 2) +
                          colliderSize.y / 2;
                float xRight = puzzle.transform.position.x + colliderCenter.x + (colliderSize.x / 2 * -direction);
                float xLeft = puzzle.transform.position.x + colliderCenter.x + (colliderSize.x / 2 * direction);
                
                rayLeft = new Ray(new Vector2(xLeft, y), new Vector2(-direction, 0));
                rayRight = new Ray(new Vector2(xRight, y), new Vector2(direction, 0));
                
                //Draw Rays
                Debug.DrawRay(rayLeft.origin, rayLeft.direction);
                Debug.DrawRay(rayRight.origin, rayRight.direction);


                if (!Physics.Raycast(rayUp, out hit, 1.0f, collisionMask) && !puzzle.moved && (puzzle.transform.position.y < startPosition.y))
                {
                    Debug.Log("Moved Up");
                    puzzle.goUp = true;
                }
                
                if (!Physics.Raycast(rayDown, out hit, 1, collisionMask) && !puzzle.moved && (puzzle.transform.position.y > (startPosition.y - 3 * offset.y)))
                {
                    Debug.Log("Moved Down");
                    puzzle.goDown = true;
                }
                
                if (!Physics.Raycast(rayLeft, out hit, 1, collisionMask) && !puzzle.moved && (puzzle.transform.position.x > startPosition.x))
                {
                    Debug.Log("Moved Left");
                    puzzle.goLeft = true;
                }
                
                if (!Physics.Raycast(rayRight, out hit, 1, collisionMask) && !puzzle.moved && (puzzle.transform.position.x < (startPosition.x + 3 * offset.x)))
                {
                    Debug.Log("Moved Right");
                    puzzle.goRight = true;
                }
                

                
            }
        }
    }
}
