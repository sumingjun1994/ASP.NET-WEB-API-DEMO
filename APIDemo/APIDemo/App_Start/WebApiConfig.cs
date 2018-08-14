using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace APIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //去掉XML数据格式
            /* config.Formatters.Remove(config.Formatters.XmlFormatter);*/

            //去掉JSON数据格式
            /*config.Formatters.Remove(config.Formatters.JsonFormatter);*/

            /*config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            --config.Formatters.JsonFormatter.SerializerSettings.ContractResolver= new CamelCasePropertyNamesContractResolver();
            */


            /*
             * 功能：Jsonp跨域访问
             * instanll->package WebApiContrib.Formatting.Jsonp
             */
            //var jsonpFormatters = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0,jsonpFormatters);

            /*
             * 功能：Cross跨域请求
             * instanll-package Microsoft.AspNet.WebApi.Cors
             */
            //EnableCorsAttribute enableCorsAttribute=new EnableCorsAttribute("*","*","*");
            //config.EnableCors(enableCorsAttribute);
        }
    }
}
