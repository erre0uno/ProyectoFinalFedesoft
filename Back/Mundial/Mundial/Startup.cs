#region Using
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Mundial.BAL.Services.Interfaces;
using Mundial.BAL.Services.Repositories;
using Mundial.DAL.DTO;
using Mundial.DAL.Entities;
using System.Reflection;
using System.Text;
#endregion

namespace Mundial
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JWT2
            //var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));
            //services.AddAuthentication(x => {
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x => {
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            #endregion

            // Context
            services.AddDbContext<MundialContext>(
            options => options.UseSqlServer("name=ConnectionStrings:myConnection"));

            // FluentValidations
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            // Repositories
            services.AddTransient<IGeneric<UsuarioDTO>, UsuarioRepository>();
            services.AddTransient<IGeneric<AsistenciaDTO>, AsistenciaRepository>();
            services.AddTransient<IGenericShow<EquipoDTO>, EquipoRepository>();
            services.AddTransient<IGeneric<GoleadorDTO>, GoleadorRepository>();
            services.AddTransient<IGeneric<TarjetaRojaDTO>, TarjetaRojaRepository>();
            services.AddTransient<IGenericShow<JugadorDTO>, JugadorRepository>();
            services.AddTransient<IGenericShow<PosicionDTO>, PosicionRepository>();
            services.AddTransient<IGeneric<ResultadoDTO>, ResultadoRepository>();
            services.AddTransient<IGeneric<TablaPosicionesDTO>, TablaPosicionesRepository>();

            //Repositories jwt y login
            services.AddScoped<IToken, TokenRepository>();
            services.AddScoped<ILogin, LoginRepository>();


            // JWT config
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Conexion Api Cors config
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            // JWT Authorization confi > en este orden !!
            app.UseAuthentication();
            app.UseAuthorization();
            // JWT


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
