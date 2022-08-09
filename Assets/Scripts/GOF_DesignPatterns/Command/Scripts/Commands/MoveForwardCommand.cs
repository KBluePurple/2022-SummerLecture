using DesignPattern.Command;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class MoveForwardCommand : Command
    {
        private MoveObject _moveObject;

        public MoveForwardCommand(MoveObject moveObject)
        {
            _moveObject = moveObject;
        }

        public override void Execute()
        {
            _moveObject.MoveFoward();
        }
        public override void Undo()
        {
            _moveObject.MoveBack();
        }
    }
}