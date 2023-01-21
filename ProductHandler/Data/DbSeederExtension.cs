namespace ProductHandler.Data
{
    internal static class DbSeederExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ProductHandlerContext>();
                DbSeeder.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
