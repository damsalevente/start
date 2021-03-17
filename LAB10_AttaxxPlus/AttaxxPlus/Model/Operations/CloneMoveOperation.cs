using System;

namespace AttaxxPlus.Model.Operations
{
    public class CloneMoveOperation : OperationBase
    {
        public CloneMoveOperation(GameBase game) : base(game)
        {
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (selectedField == null)
                return false;
            double rowdiff = Math.Abs(selectedField.Row - currentField.Row);
            double coldiff = Math.Abs(selectedField.Column - currentField.Column);
            bool nochange = (rowdiff == 0 && coldiff == 0);
            // Note: selectedField is always the players own field...
            // EVIP: IsEmpty() is more descriptive than "Owner == 0"
            if (!nochange 
                && rowdiff <= 1 
                && coldiff <= 1
                && !selectedField.IsEmpty()
                && currentField.IsEmpty())
            {
                currentField.Owner = selectedField.Owner;
                // EVIP: using more general helper method implemented by base class
                ChangeOwnerOfOccupiedFieldsAroundField(currentField);
                return true;
            }
            return false;
        }
    }
}
