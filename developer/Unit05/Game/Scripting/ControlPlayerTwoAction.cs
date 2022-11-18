using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls Player Two.</para>
    /// <para>
    /// The responsibility of ControlPlayerTwoAction is to get the direction and move the Player Two.
    /// </para>
    /// </summary>
    public class ControlPLayerTwoAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlPLayerOneAction using the given KeyboardService.
        /// </summary>
        public ControlPLayerTwoAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (_keyboardService.IsKeyDown("j"))
            {
                _direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("l"))
            {
                _direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("i"))
            {
                _direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("k"))
            {
                _direction = new Point(0, Constants.CELL_SIZE);
            }

            PlayerTwo playerTwo = (PlayerTwo)cast.GetFirstActor("playerTwo");
            playerTwo.TurnHead(_direction);

        }
    }
}