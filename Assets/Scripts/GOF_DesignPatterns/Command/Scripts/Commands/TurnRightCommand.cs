using DesignPattern.Command;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class TurnRightCommand : Command
    {
        private MoveObject _moveObject;

        public TurnRightCommand(MoveObject moveObject)
        {
            _moveObject = moveObject;
        }

        public override void Execute()
        {
            _moveObject.TurnRight();
        }
        public override void Undo()
        {
            _moveObject.TurnLeft();
        }
    }
}