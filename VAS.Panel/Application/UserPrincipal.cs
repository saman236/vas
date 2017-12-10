using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace VAS.Panel.Application
{
    public class UserManagment
    {
        public static UserPrincipal CurrentUser
        {
            get
            {
                return (UserPrincipal)HttpContext.Current.User;
            }
        }
    }

    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(UserIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            return ((UserIdentity)Identity).Role == role;
        }

        public string CurrentRole { get { return ((UserIdentity)Identity).Role; } }
        public bool IsAdmin { get { return CurrentRole == Role.Admin; } }
        public bool IsEmployee { get { return CurrentRole == Role.Employee; } }
        public bool IsEndUser { get { return CurrentRole == Role.EndUser; } }
        public int UserID { get { return ((UserIdentity)Identity).UserID; } }
    }

    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name, string authenticationType, bool isAuthenticated, string role)
        {
            _Name = name;
            _AuthenticationType = authenticationType;
            _IsAuthenticated = isAuthenticated;
            _Role = role;
        }


        #region Public Members

        public string Name { get { return _Name; } }
        public string AuthenticationType { get { return _AuthenticationType; } }
        public bool IsAuthenticated { get { return _IsAuthenticated; } }
        public string Role { get { return _Role; } }
        public int UserID { get { return _UserID; } }

        #endregion

        #region Private Members

        readonly string _Name;
        readonly string _AuthenticationType;
        readonly bool _IsAuthenticated;
        readonly string _Role;
        readonly int _UserID;

        #endregion
    }
}