using AttaxxPlus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttaxxPlus.Boosters
{
    class CleanupBooster : BoosterBase
    {
        public override string Title => "Cleanup row and column";
        private bool[] canUse;
        public CleanupBooster() : base()
        {
        }
        public override void InitializeGame()
        {
            canUse = new bool[3] { false, true, true };
        }
        public override bool TryExecute(Field selectedField, Field currentField)
        {
            int who_asked = GameViewModel.CurrentPlayer;
            // check if the user can use it, field is selected, and the selected field is actually owned by him/her
            if (canUse[who_asked]
                && selectedField != null
                && selectedField.Owner == who_asked)
            {
                for (int row = 0; row < GameViewModel.Model.Fields.GetLength(0); row++)
                    for (int col = 0; col < GameViewModel.Model.Fields.GetLength(1); col++)
                        // change if row xor col matches
                        if ((selectedField.Column == col) ^ (selectedField.Row == row))
                        {
                            GameViewModel.Model.Fields[row, col].Owner = 0;
                        }
                // no more usage
                canUse[who_asked] = false;
                return true;
            }

            return false;
        }
    }
}
