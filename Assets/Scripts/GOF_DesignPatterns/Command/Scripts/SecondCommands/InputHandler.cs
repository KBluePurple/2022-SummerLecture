using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject playerObject;
    Animator animator;
    Command keyQ, keyW, keyE, upArrow;

    Stack<Command> undoStack = new Stack<Command>();

    private void Start()
    {
        animator = playerObject.GetComponent<Animator>();

        keyQ = new PerformJump();
        keyW = new PerformKick();
        keyE = new PerformPunch();

        upArrow = new MoveFoward();

        Camera.main.GetComponent<CameraFollow360>().player = playerObject.transform;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExecuteCommand(keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ExecuteCommand(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ExecuteCommand(keyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ExecuteCommand(upArrow);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            StartUndo();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StartReverse();
        }
    }

    private void ExecuteCommand(Command command)
    {
        command.Execute(animator);
        undoStack.Push(command);
    }

    private void StartUndo()
    {
        StartCoroutine(Undo());
    }

    private IEnumerator Undo()
    {
        if (undoStack.Count > 0)
        {
            Command command = undoStack.Pop();
            command.Undo(animator);
            Debug.Log($"Undo {command.GetType().Name}");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            animator.Play("Zombie Idle", 0, 0);
        }
        yield return null;
    }

    private void StartReverse()
    {
        StartCoroutine(Reverse());
    }

    private IEnumerator Reverse()
    {
        while (undoStack.Count > 0)
        {
            yield return Undo();
        }
        yield return null;
    }
}
