namespace Service.Configurations
{
    using AutoMapper;
    using Repository.Models;

    using Service.ViewModels.ChatRoom;
    using Service.ViewModels.User;

    /// <summary>
    /// Class use to configure AutoMapper
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Initializes the configuration of AutoMapper
        /// </summary>
        public static void Initialize()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();

            Mapper.CreateMap<ChatRoom, ChatRoomViewModel>();
            Mapper.CreateMap<ChatRoomViewModel, ChatRoom>();
        }
    }
}