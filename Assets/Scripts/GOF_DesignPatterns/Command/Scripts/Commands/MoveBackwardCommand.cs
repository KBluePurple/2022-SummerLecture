using DesignPattern.Command;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class MoveBackwardCommand : Command
    {
        private MoveObject _moveObject;

        public MoveBackwardCommand(MoveObject moveObject)
        {
            _moveObject = moveObject;
        }

        public override void Execute()
        {
            _moveObject.MoveBack();
        }
        public override void Undo()
        {
            _moveObject.MoveFoward();
        }
    }
}