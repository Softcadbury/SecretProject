﻿namespace Infrastructure.Messaging.Requests
{
    /// <summary>
    /// This class represents the request to get a list of models
    /// </summary>
    public sealed class GetAllRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAllRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
    }
}