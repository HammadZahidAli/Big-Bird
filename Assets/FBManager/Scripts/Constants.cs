using System;
namespace Gs
{
    public class Constants
    {
        //This is a dummy Score
        public static int userScore = 100;
        public const string shareDialogTitle = "Big Bird Journey",
            shareDialogMsg = "This is a Superb Owesome Game! Check this Out.",
            inviteDialogTitle = "Lets Play Play and Win",
            inviteDialogMsg = "Let's Play this Great Fun Game!";
        public static Uri fbShareURI = new Uri("https://play.google.com/store/apps/details?id=com.gamesfort.bigbird"),
                fbSharePicURI = new Uri("http://i.imgur.com/ZaWulSh.png");


        public static int highScore;

    }
}
namespace Trans
{

    public class Transfer
    {
        public int  HighScore()
        {
           Gs.Constants.highScore =Constants.highScore;
            return Constants.highScore;
        }
    }
}