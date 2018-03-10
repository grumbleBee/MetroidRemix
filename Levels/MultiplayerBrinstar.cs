using CSE3902.Cameras;
using CSE3902.Effects;
using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Physics;
using CSE3902.Players;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.Levels
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    class MultiplayerBrinstar : ILevel
    {
        private Collection<IGameObject> GameObjects { get; }
        public IPlayer[] Players { get; set; }
        public IPhysics Physics { get; set; }
        public WorldUtil.WorldState CurrentWorldState { get; set; }
        private Camera _camera;
        private SpriteFont _defaultFont;
        int _timeSinceLastFrame;
        private const int MillisecondsPerFrame = 60;
        StandardGameObject _energyMarker;
        StandardGameObject _missileMarker;
        private readonly int _numPlayers;
        private PlayerSpriteFactory.PlayerColorScheme[] playerColorSchemes;

        public MultiplayerBrinstar(int numPlayers, PlayerSpriteFactory.PlayerColorScheme[] schemes)
        {
            GameObjects = new Collection<IGameObject>();
            Physics = new StandardPhysics();
            SoundManager.Instance.PlaySong("brinstarLevel");
            CurrentWorldState = WorldUtil.WorldState.Paused;
            _numPlayers = numPlayers;
            playerColorSchemes = schemes;
        }

        public void LoadContent(LevelLoader levelLoader)
        {
            levelLoader.LoadLevel(@"Content/Brinstar.csv", GameObjects);
            _camera = new HorizontalScrollingCamera(Game1.graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            Players = new IPlayer[_numPlayers];
            for (int i = 0; i < _numPlayers; i++)
            {
                IPlayer newSamus = new Samus(new Vector2(620 + (i * 20), 159), i);
                ((Samus) newSamus).ColorScheme = playerColorSchemes[i];
                Players[i] = newSamus;
                PlayerSpriteFactory.Instance.SetPlayerToCustomTextures(i,((Samus)Players[i]).ColorScheme);
                GameObjects.Add(newSamus);
            }

            _camera.Focus = Players[0];
            _camera.CameraPosition = new Vector2(_camera.Focus.Position.X - _camera.Viewport.Width / _camera.Zoom / 2, _camera.CameraPosition.Y);
            _defaultFont = FontManager.Instance.CreateNewDefaultFont();
        }

        public void SetWorldState(WorldUtil.WorldState worldState)
        {
            CurrentWorldState = worldState;
        }

        public void Destroy(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public IGameObject Spawn(IGameObject gameObject, Vector2 pos)
        {
            gameObject.Position = pos;
            GameObjects.Add(gameObject);
            return gameObject;
        }

        public void Update(GameTime gameTime)
        {
            ICollection<IGameObject> renderedObjects = GameObjects.Where(e => _camera.IsRendered(e, 15)).ToList();
            ICollection<IPhysicsObject> toDoPhysics = InterfaceListUtil.GameObjectListToPhysicsObjectList(renderedObjects).Where(e => e.PhysicsDuringLesserState >= CurrentWorldState).ToList();
            ICollection<ICollidableObject> toDoCollisions = InterfaceListUtil.GameObjectListToCollidableObjectList(renderedObjects).Where(e => e.CollideDuringLesserState >= CurrentWorldState).ToList();
            foreach (IPlayer player in Players)
            {
                if (player.Position.X > _camera.CameraPosition.X + _camera.Viewport.Width / _camera.Zoom - 22)
                {
                    player.Position = new Vector2(_camera.CameraPosition.X + _camera.Viewport.Width / _camera.Zoom - 22, player.Position.Y);
                }
                else if (player.Position.X < _camera.CameraPosition.X + 6)
                {
                    player.Position = new Vector2(_camera.CameraPosition.X + 6, player.Position.Y);
                }

                if (player != Players[0] && player.Position.Y >
                    _camera.CameraPosition.Y + _camera.Viewport.Height / _camera.Zoom)
                {
                    player.Position = Players[0].Position;
                }

            }
            ICollection<IGameObject> toBeUpdated = GameObjects.Where(e => _camera.IsRendered(e) && e.UpdateDuringLesserState >= CurrentWorldState).ToList();
            Physics.DoPhysics(toDoPhysics, gameTime);
            CollisionHandler.Instance.HandleCollisions(toDoCollisions);
            foreach (IGameObject gameObject in toBeUpdated) gameObject.Update();
            _camera.Update();

            if (SoundManager.Instance.GetSoundEffect("obtainItem").State.ToString().Equals("Stopped") &&
                SoundManager.Instance.GetSoundEffect("brinstarLevel").State.ToString().Equals("Paused")
                )
            {
                SoundManager.Instance.ResumeSong("brinstarLevel");
                SetWorldState(WorldUtil.WorldState.Playing);
            }

            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceLastFrame > MillisecondsPerFrame)
            {
                _timeSinceLastFrame = 0;
                UpdateFrames();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            ICollection<IGameObject> renderedObjects = GameObjects.Where(e => _camera.IsRendered(e)).ToList();
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp, transformMatrix: _camera.GetViewMatrix());
            foreach (IVisibleObject gameObject in InterfaceListUtil.GameObjectListToVisibleObjectList(renderedObjects))
                gameObject.Draw(spriteBatch);
            for (int i = 0; i < Players.Length; i++)
            {
                IPlayer player = Players[i];
                if (player.Health > 0)
                {
                    _energyMarker = new EnergyMarker(new Vector2(_camera.CameraPosition.X+8+(100*i), _camera.CameraPosition.Y + 8));
                    _energyMarker.Draw(spriteBatch);
                    spriteBatch.DrawString(_defaultFont, "" + player.Health + "", new Vector2(_camera.CameraPosition.X + 58 + (100*i), _camera.CameraPosition.Y + 3), Color.White);
                    if (player.HasMissileUpgrade && player.Missiles > 0)
                    {
                        _missileMarker = new MissileMarker(new Vector2(_camera.CameraPosition.X + 8 + (100*i), _camera.CameraPosition.Y + 24));
                        _missileMarker.Draw(spriteBatch);
                        spriteBatch.DrawString(_defaultFont, "" + player.Missiles + "", new Vector2(_camera.CameraPosition.X + 58 + (100*i), _camera.CameraPosition.Y + 19), Color.White);
                    }
                }
            }
            spriteBatch.End();
        }

        public void UpdateFrames()
        {
            foreach (var gObject in GameObjects.Where(e => e is IVisibleObject))
            {
                var gameObject = (IVisibleObject)gObject;
                if (gameObject.GetSprite() != null)
                {
                    gameObject.GetSprite().NextFrame();
                }
            }
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public void SetCamera(Camera newCamera)
        {
            _camera = newCamera;
        }
    }
}
