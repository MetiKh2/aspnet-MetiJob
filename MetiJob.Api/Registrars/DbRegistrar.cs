using MetiJob.DataAccess;
using MetiJob.Domain.Aggregates.IdentityAggregates;


namespace MetiJob.Api.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("MetiJobConnection");
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(cs);
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {
                op.Password.RequireUppercase = false;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireDigit = false;
                op.Password.RequiredLength = 6;

                op.User.RequireUniqueEmail = true;

                op.Lockout.MaxFailedAccessAttempts = 6;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

            }
            )
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/AccessDenied";
                options.Cookie.Name = "MetiJob";
                options.LoginPath = "/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            builder.Services.Configure<SecurityStampValidatorOptions>(option =>
            {
                option.ValidationInterval = TimeSpan.FromMinutes(5);
            });


        }
    }
}
