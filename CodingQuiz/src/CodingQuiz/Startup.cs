using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using CodingQuiz.Repo;

namespace CodingQuiz
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); //Adds MVC services via Dependency Injection
            services.AddSingleton<ICodingQuizRepository, CodingQuizRepository>(); //Adds CodingQuizRepo via Dependency Injection
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc(); //Add route middleware and sets MVC as default handler
            app.UseWelcomePage();
        }
    }
}
