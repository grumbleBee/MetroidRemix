using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface IRidleyState : IState {
       void TurnRed();
        void TurnRedUpdate();
    }
}
