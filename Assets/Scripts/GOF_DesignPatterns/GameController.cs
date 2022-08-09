using System.Collections;
using System.Collections.Generic;
using DesignPattern.Command;
using UnityEngine;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class GameController : MonoBehaviour
    {
        public MoveObject moveObject;

        private Command _buttonW;
        private Command _buttonA;
        private Command _buttonS;
        private Command _buttonD;

        private Stack<Command> _undoStack = new Stack<Command>();
        private Stack<Command> _redoStack = new Stack<Command>();

        private void Start()
        {
            _buttonW = new MoveForwardCommand(moveObject);
            _buttonA = new TurnLeftCommand(moveObject);
            _buttonS = new MoveBackwardCommand(moveObject);
            _buttonD = new TurnRightCommand(moveObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(_buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(_buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(_buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(_buttonD);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var temp = _buttonA;
                _buttonA = _buttonD;
                _buttonD = temp;
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                Undo();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Redo();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartReplay();
            }
        }

        private void ExecuteNewCommand(Command command)
        {
            command.Execute();
            _undoStack.Push(command);
        }

        private void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
        }

        private void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }

        private void StartReplay()
        {
            StartCoroutine(Replay());
        }

        private IEnumerator Replay()
        {
            moveObject.transform.position = Vector3.zero;
            moveObject.transform.rotation = Quaternion.identity;
            
            Command[] commands = _undoStack.ToArray();
            for (int i = commands.Length - 1; i >= 0; i--)
            {
                commands[i].Execute();
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
