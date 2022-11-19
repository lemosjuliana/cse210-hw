using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            PlayerOne playerOne = (PlayerOne)cast.GetFirstActor("playerOne");
            List<Actor> segmentsOne = playerOne.GetSegments();

            PlayerTwo playerTwo = (PlayerTwo)cast.GetFirstActor("playerTwo");
            List<Actor> segmentsTwo = playerTwo.GetSegments();

            Actor playerOneScore = cast.GetFirstActor("playerOneScore");
            Actor playerTwoScore = cast.GetFirstActor("playerTwoScore");

            //Actor food = cast.GetFirstActor("food");
            playerTwoScore.SetPosition(new Point(Constants.MAX_X -100,0));
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segmentsOne);
            _videoService.DrawActors(segmentsTwo);
            _videoService.DrawActor(playerOneScore);
            _videoService.DrawActor(playerTwoScore);
            //_videoService.DrawActor(playerTwoScore);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}