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
            return ((UserIdentity)Identity).Roles.Contains(role);
        }

        public IList<string> CurrentRoles { get { return ((UserIdentity)Identity).Roles; } }
        public bool IsAdmin { get { return CurrentRoles.Contains(Role.Admin); } }
        public bool IsEmployee { get { return CurrentRoles.Contains(Role.Employee); } }
        public bool IsEndUser { get { return CurrentRoles.Contains(Role.EndUser); } }
        public int UserID { get { return ((UserIdentity)Identity).UserID; } }
    }

    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name, string authenticationType, bool isAuthenticated, List<string> roles)
        {
            _Name = name;
            _AuthenticationType = authenticationType;
            _IsAuthenticated = isAuthenticated;
            _Roles = roles;
        }


        #region Public Members

        public string Name { get { return _Name; } }
        public string AuthenticationType { get { return _AuthenticationType; } }
        public bool IsAuthenticated { get { return _IsAuthenticated; } }
        public IList<string> Roles { get { return _Roles; } }
        public int UserID { get { return _UserID; } }

        #endregion

        #region Private Members

        readonly string _Name;
        readonly string _AuthenticationType;
        readonly bool _IsAuthenticated;
        readonly List<string> _Roles;
        readonly int _UserID;

        #endregion
    }
}