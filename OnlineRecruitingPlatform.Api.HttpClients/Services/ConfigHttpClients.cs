﻿using System;

namespace OnlineRecruitingPlatform.Api.HttpClients.Services
{
    public class ConfigHttpClients
    {
        public static string UserAgent { get; set; }

        public static string Protocol { get; set; }

        public static string Domain { get; set; }

        public static string Port { get; set; }

        public static string GetAddressServer()
        {
            return $"{Protocol}://{Domain}{(Port.Length > 0 ? $":{Port}" : "")}/api/";
        }

        public static string GetAddressServer(string controllerName)
        {
            if (controllerName != null ? controllerName.Length == 0 : true)
            {
                throw new ArgumentNullException("controllerName", "Название контроллера не может быть пустым или длиной 0 символов.");
            }

            return $"{Protocol}://{Domain}{(Port != null ? $":{Port}" : "")}/api/{controllerName}/";
        }
    }
}
