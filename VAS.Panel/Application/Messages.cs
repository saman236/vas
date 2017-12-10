using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAS.Panel.Application
{
    public struct Messages
    {
        public const string UN_AUTHENTICATED = "هویت کاربر شما احراز نگردید.";

        public const string INVALID_AUTHENTICATION = "هویت کاربر شما مخدوش است.";

        public const string ACCESS_DENIED = "کاربر شما مجاز به انجام عملیات نیست.";
    }
}