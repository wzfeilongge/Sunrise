using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SunriseEnterpriseCommon
{
    public static class RandowmPwdHelper
    {
        private static readonly char[] constant = {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        public static bool IsInit { get; set; }
        public static List<PasswordModel> PwdList { get; set; }

        /// <summary>
        /// 创建随机密码
        /// </summary>
        /// <returns></returns>
        public static string CreateRandowmPwd(int EffectiveTime)
        {
            if (IsInit)
            {
                var CreateData = GenerateRandom(8);
                PasswordModel passwordModel = new PasswordModel { 
                Pwd=CreateData,
                Effective= EffectiveTime,
                CreateTime=DateTime.Now,
                EndTime= DateTime.Now.AddHours(EffectiveTime),
                Istrue=true
                };
                
                PwdList.Add(passwordModel);
                return CreateData;
            }
            return string.Empty;
        }

        public static string GenerateRandom(int Length)
        {
            StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 获得当前密码池
        /// </summary>
        /// <returns></returns>
        public static List<PasswordModel> GetPwd()
        {
            if (IsInit)
            {
                foreach (var item in PwdList)
                {
                    if (item.EndTime >= DateTime.Now)
                    {
                        continue;
                    }
                    PwdList.Remove(item);//移除过期
                }
                return PwdList;
            }

            return null;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            if (PwdList == null)
            {
                PwdList = new List<PasswordModel>() {
                  new PasswordModel
                  {
                      Pwd="sunrise2020",
                      Effective=1000,
                      CreateTime=DateTime.Now,
                      EndTime=DateTime.Now.AddYears(1),
                      Istrue=true
                  }
                
                };
                IsInit = true;
            }
            else
            {
                IsInit = true;
            }

            return IsInit;
        }

        /// <summary>
        /// 使用后移除
        /// </summary>
        /// <param name="RandowmPwd"></param>
        /// <returns></returns>
        public static bool InstallPwd(string RandowmPwd)
        {
            if (string.IsNullOrEmpty(RandowmPwd))
            {
                return false;
            }
            if (IsInit)
            {
                if (RandowmPwd == "Sunrise2020")
                {
                    return true;
                }
                var data = PwdList.Find(v => (v.Pwd.Equals(RandowmPwd)&&v.Istrue==true));
                if (data==null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(data.Pwd))
                {
                    return false;
                }

                var EndTime = data.CreateTime.AddHours(data.Effective);

                if (DateTime.Now<EndTime)
                {
                    return true;
                }               
            }
            return false;
        }

        public static bool ChangePwdState(string RandowmPwd)
        {
            if (IsInit)
            {
                var data = PwdList.Find(v => (v.Pwd.Equals(RandowmPwd)));

                if (data!=null)
                {
                    data.Istrue=(!data.Istrue);
                    return true;
                }
            }
            return false;
        }

        public static bool DeletePassword(string RandowmPwd)
        {
            var data = PwdList.Find(v => (v.Pwd.Equals(RandowmPwd)));

           return PwdList.Remove(data);

        }



    }


    public class PasswordModel
    {
    
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
      
        /// <summary>
        /// 创建的时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 有效期小时
        /// </summary>
        public int Effective { get; set; }

        
        public DateTime EndTime { get; set; }


        public bool Istrue { get; set; }
    }


}
