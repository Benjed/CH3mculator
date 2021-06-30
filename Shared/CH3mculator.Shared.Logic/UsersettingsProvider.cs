using CH3mculator.Shared.Model;
using Microsoft.Extensions.Options;
using System;

namespace CH3mculator.Shared.Logic
{
    public class UsersettingsProvider
    {
        public static Func<IOptions<UsersettingsOptions>> GetUsersettings { get; set; }
    }
}
