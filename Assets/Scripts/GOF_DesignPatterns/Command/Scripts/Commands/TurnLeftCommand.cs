using DesignPattern.Command;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class TurnLeftCommand : Command
    {
        private MoveObject _moveObject;

        public TurnLeftCommand(MoveObject moveObject)
        {
            _moveObject = moveObject;
        }

        public override void Execute()
        {
            _moveObject.TurnLeft();
        }
        public override void Undo()
        {
            _moveObject.TurnRight();
        }
    }
}