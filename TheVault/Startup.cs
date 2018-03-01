using Microsoft.Owin;
using Owin;
using TheVault.Configuration;

[assembly: OwinStartupAttribute(typeof(TheVault.Startup))]
namespace TheVault
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            //Stripe.StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);

        }

        //public void ConfigureServices(IServiceCollection Services)
        //{
        //    services.Configure<PaymentSettings>(Configuration.GetSection("PaymentSettings"));
        //}
    }
}
