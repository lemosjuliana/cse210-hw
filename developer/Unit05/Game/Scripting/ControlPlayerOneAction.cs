using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls Player One.</para>
    /// <para>
    /// The responsibility of ControlPlayerOneAction is to get the direction and move the Player One.
    /// </para>
    /// </summary>
    public class ControlPLayerOneAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlPLayerOneAction using the given KeyboardService.
        /// </summary>
        public ControlPLayerOneAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (_keyboardService.IsKeyDown("a"))
            {
                _direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("d"))
            {
                _direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("w"))
            {
                _direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("s"))
            {
                _direction = new Point(0, Constants.CELL_SIZE);
            }

            PlayerOne playerOne = (PlayerOne)cast.GetFirstActor("playerOne");
            playerOne.TurnHead(_direction);

        }
    }
}