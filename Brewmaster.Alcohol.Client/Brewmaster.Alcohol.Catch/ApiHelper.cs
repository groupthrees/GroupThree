using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
namespace Brewmaster.Alcohol.Catch
{
    public class ApiHelper
    {
 
        /// <summary>
        /// webApi封装方法
        /// </summary>
        /// <param name="verbs"></param>
        /// <param name="actionName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetApiResult(string verbs, string actionName, object obj = null)
        {
            //定义字符串，用于接收json结果
            string json = "";
            //创建一个任务对象
            Task<HttpResponseMessage> task = null;
            //创建一个客户端呢对象
            HttpClient client = new HttpClient();
            //指定访问WebApi的uri地址
            client.BaseAddress = new Uri("http://localhost:50169/api/");
            /*根据不同的动作执行不同的方法*/
            switch (verbs)
            {
                case "get":
                    task = client.GetAsync(actionName);
                    break;
                case "post":
                    task = client.PostAsJsonAsync(actionName, obj);
                    break;
                case "put":
                    task = client.PutAsJsonAsync(actionName, obj);
                    break;
                case "delete":
                    task = client.DeleteAsync(actionName);
                    break;
                default:
                    break;
            }
            //等待执行
            task.Wait();
            //接收任务结果
            var response = task.Result;
            //如果返回的是成功的状态
            if (response.IsSuccessStatusCode)
            {
                //从响应的内容中读取字符串结果
                var read = response.Content.ReadAsStringAsync();
                //等待读取
                read.Wait();
                //接收最终的字符串
                json = read.Result;
            }
            return json;
        }
  
    }
}
