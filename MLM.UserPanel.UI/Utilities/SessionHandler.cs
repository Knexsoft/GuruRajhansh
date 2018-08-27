using Microsoft.AspNetCore.Http;
using MLM.Business.Abstracts;
using MLM.Business.Models.ViewModels;
using MLM.Business.Utilities;

namespace MLM.UserPanel.UI.Utilities
{
    public class SessionHandler : ISessionHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// get membership context from AuthUser Session 
        /// </summary>
        /// <returns>membership context</returns>
        public MembershipContext GetMembershipContext()
        {
            var _user = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<MembershipContext>("AuthUser");
            return _user == null ? default(MembershipContext) : _user;
        }

        /// <summary>
        /// Set Membership Context into AuthUser Session 
        /// </summary>
        /// <param name="MembershipContext">membership context from validated user</param>
        public void SetMembershipContext(MembershipContext membershipContext)
        {
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("AuthUser", membershipContext);
        }

        public void SetName(string Name)
        {
            _httpContextAccessor.HttpContext.Session.SetString("Name", Name);
        }

        public string GetUserName()
        {
            var _name = _httpContextAccessor.HttpContext.Session.GetString("Name");
            return _name;
        }

        public UserView GetUser()
        {
            var _user = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<UserView>("User");
            return _user == null ? default(UserView) : _user;
        }

        public void SetUser(UserView userView)
        {
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("User", userView);
        }
    }
}
