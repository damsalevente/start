using System;
using AttaxxPlus.Model;

namespace AttaxxPlus.Boosters
{
    /// <summary>
    /// Booster filling all empty fields with the opponents' color (assuming 2 players).
    /// </summary>
    public class SurrenderBooster : BoosterBase
    {
        // EVIP: compact override of getter for Title returning constant.
        public override string Title => "Surrender";

        public SurrenderBooster() : base()
        {
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            // figure out who surrendered, the other one will win
            int who_won = (this.GameViewModel.CurrentPlayer == 1) ? 2 : 1;         
            
            // make every tile the enemy player's color
            for (int row = 0; row < this.GameViewModel.Model.Fields.GetLength(0); row++)
                for (int col = 0; col < this.GameViewModel.Model.Fields.GetLength(1); col++)
                    this.GameViewModel.Model.Fields[row, col].Owner = who_won;
            return true; // return always true
        }
    }
}
