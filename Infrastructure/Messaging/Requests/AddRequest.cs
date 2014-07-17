﻿namespace Infrastructure.Messaging.Requests
{
    using Infrastructure.BaseClasses;

    /// <summary>
    /// This class represents the request to add a model
    /// </summary>
    public sealed class AddRequest<TModel>
        where TModel : BaseModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddRequest(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; private set; }
    }
}