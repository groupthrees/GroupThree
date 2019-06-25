using Brewmaster.Alcohol.Catch;
using Brewmaster.Alcohol.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Brewmaster.Alcohol.Client.Controllers
{
    public class UserController : BaseController
    {
        private string THE_UID = "laishaoqian";
        private string THE_KEY = "123456789qwe";//这里是通过网站发送的用户名和秘钥


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="messageContent"></param>
        public ActionResult SendText(string phoneNumber, string messageContent)
        {
            string postUrl = GetPostUrl(phoneNumber, messageContent);
            string result = PostSmsInfo(postUrl);
            string t = GetResult(result);
            return Json(t);
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <param name="smsMob"></param>y
        /// <param name="smsText"></param>
        /// <returns></returns>
        private string GetPostUrl(string smsMob, string smsText)
        {
            string postUrl = "http://utf8.api.smschinese.cn/?Uid=" + THE_UID + "&key=" + THE_KEY + "&smsMob=" + smsMob + "&smsText=" + smsText;
            return postUrl;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string PostSmsInfo(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }

            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;

            }

            return strRet;
        }

        /// <summary>
        /// 得到返回的请求结果
        /// </summary>
        /// <param name="strRet"></param>
        /// <returns></returns>
        public string GetResult(string strRet)
        {
            int result = 0;
            try
            {
                result = int.Parse(strRet);
                switch (result)
                {
                    case -1:
                        strRet = "没有该用户账户";
                        break;
                    case -2:
                        strRet = "接口密钥不正确,不是账户登陆密码";
                        break;
                    case -21:
                        strRet = "MD5接口密钥加密不正确";
                        break;
                    case -3:
                        strRet = "短信数量不足";
                        break;
                    case -11:
                        strRet = "该用户被禁用";
                        break;
                    case -14:
                        strRet = "短信内容出现非法字符";
                        break;
                    case -4:
                        strRet = "手机号格式不正确";
                        break;
                    case -41:
                        strRet = "手机号码为空";
                        break;
                    case -42:
                        strRet = "短信内容为空";
                        break;
                    case -51:
                        strRet = "短信签名格式不正确,接口签名格式为：【签名内容】";
                        break;
                    case -6:
                        strRet = "IP限制";
                        break;
                    default:
                        strRet = "发送短信数量：" + result;
                        break;
                }
            }
            catch (Exception ex)
            {
                strRet = ex.Message;
            }
            return strRet;
        }


        #region 登录
        public IActionResult Login()
        {
            
            return View();
        }
        public int LoginDo(string UsersName,string UsersPwd)
        {
            ApiHelper apiHelper = new ApiHelper();
            var str= apiHelper.GetApiResult("get",$"User/Login?UsersName={UsersName}&UsersPwd={UsersPwd}");
            var user = JsonConvert.DeserializeObject<List<Users>>(str);
            if (user!=null)
            {
                WriteCookie(user.First());
                return 1;
            }
            return 0;
        }


        #endregion

        #region 注册
        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Regist()
        {
            return View();
        }
        [HttpPost]
        public int Regist(Users user)
        {
            int result = int.Parse(new ApiHelper().GetApiResult("post", "User/Resigt", user));
            return result;
        }

        #endregion

        #region 忘记密码
        public IActionResult Password()
        {
            return View();
        }
        /// <summary>
        /// 修改密码界面
        /// </summary>
        /// <returns></returns>
        public IActionResult UptPassword(string userName)
        {
            ViewBag.list = userName;
            return View();
        }
    }
    #endregion

}

