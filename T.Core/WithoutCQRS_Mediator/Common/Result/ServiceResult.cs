﻿using System.Net;

namespace T.Core.WithoutCQRS_Mediator.Common.Result
{
    public class ServiceResult
    {
        /// <summary>
        /// api status Code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Developer message
        /// </summary>
        public string? DevMsg { get; set; }

        /// <summary>
        /// user message
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// API data 
        /// </summary>
        public object? Data { get; set; }
    }
}
