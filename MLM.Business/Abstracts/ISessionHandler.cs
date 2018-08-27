using MLM.Business.Models.ViewModels;
using MLM.Business.Utilities;

namespace MLM.Business.Abstracts
{
    public interface ISessionHandler
    {
        MembershipContext GetMembershipContext();
        void SetMembershipContext(MembershipContext userView);

        UserView GetUser();
        void SetUser(UserView userView);

        string GetUserName();
        void SetName(string name);
    }
}
