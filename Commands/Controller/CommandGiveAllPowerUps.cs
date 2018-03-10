using CSE3902.Interfaces;
using CSE3902.Players;

namespace CSE3902.Commands.Controller
{
    class CommandGiveAllPowerUps : Command
    {
        private ILevel _currentLevel;
        public override void BeginExecute(int controllerId)
        {
            _currentLevel = Game1.GetLevel();
            foreach (var player in _currentLevel.Players)
            {
                var samus = (Samus) player;
                samus.HasBallForm = true;
                samus.HasBombs = true;
                samus.HasMissileUpgrade = true;
                samus.Health = 5000;
            }
        }
    

    public override void EndExecute(int controllerId)
        {
           
        }

        public override void Execute(int controllerId)
        {
            
        }
    }
}