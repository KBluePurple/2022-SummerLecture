using UnityEngine;

namespace DesignPattern.CommandPattern.RebindKeys
{
    public class DoNotingCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("Do nothing");
        }
        public override void Undo()
        {
            Debug.Log("Do nothing");
        }
    }
}