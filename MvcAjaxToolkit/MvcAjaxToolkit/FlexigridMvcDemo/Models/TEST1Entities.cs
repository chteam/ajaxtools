/*
created by zou jian
*/
using System;
using System.Collections.Generic;

namespace FlexigridMvcDemo.Models
{
    public class TEST1Entities : IDisposable
    {
        private static List<UserInfo> _userInfo;

        static TEST1Entities()
        {
            _userInfo = new List<UserInfo>();
            for (int i = 0; i < 1000; i++)
            {
               _userInfo.Add(new UserInfo
                                 {
                                     Id = i,
                                     Age = i%80,
                                     Email = Guid.NewGuid().ToString(),
                                     Name = Guid.NewGuid().ToString()
                                 });
            }
        }
        public List<UserInfo> UserInfo
        {
            get { return _userInfo; }
        }
        public void Add(UserInfo u)
        {
            _userInfo.Add(u);
        }

        public void Dispose()
        {
           
        }
    }
}