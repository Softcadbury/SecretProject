namespace Infrastructure.Configuration
{
    /// <summary>
    /// Represents limits lenght for strings
    /// </summary>
    public static class LenghtLimits
    {
        public const int UserNameMinLenght = 6;
        public const int UserNameMaxLenght = 20;

        public const int EmailMinLenght = 6;
        public const int EmailMaxLenght = 20;

        public const int PasswordMinLenght = 8;
        public const int PasswordMaxLenght = 30;

        public const int ChatRoomMinLenght = 4;
        public const int ChatRoomMaxLenght = 30;

        public const int PictureMaxLenght = 10000;
    }
}