namespace Service.Services
{
    using System;
    using System.Collections.Generic;

    using Infrastructure.BaseClasses;
    using Infrastructure.Services.Requests;
    using Infrastructure.Services.Responses;

    using Repository.Models;
    using Repository.Repositories;

    /// <summary>
    /// ChatRoom service
    /// </summary>
    public class ChatRoomService : BaseService<ChatRoom, ChatRoomRepository>
    {
        private static readonly ChatRoomRepository ChatRoomRepository = new ChatRoomRepository();

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatRoomService()
            : base(ChatRoomRepository)
        {
        }

        /// <summary>
        /// Get a model
        /// </summary>
        public new Response<ChatRoom> Get(GetRequest request)
        {
            return base.Get(request);
        }

        /// <summary>
        /// Get a list of models
        /// </summary>
        public new Response<List<ChatRoom>> GetPage(GetPageRequest request)
        {
            return base.GetPage(request);
        }
    }
}