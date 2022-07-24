﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace MetiJob.Api.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.ApiVersion.ToString());
                }
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("MetiJob");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
