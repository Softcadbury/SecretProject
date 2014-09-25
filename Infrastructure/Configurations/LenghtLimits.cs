namespace Infrastructure.Configurations
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

        public const int ChatRoomTitleMinLenght = 4;
        public const int ChatRoomTitleMaxLenght = 30;

        public const int PictureMaxLenght = 10000;

        public const int EmailMessageMinLenght = 10;
        public const int EmailMessageMaxLenght = 200;
    }
}