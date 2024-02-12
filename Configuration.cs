namespace Blog
{
    public static class Configuration
    {

        // TOKEN - JWT - Json Web Token
        public static string JwtKey = "5ea2ad53-50fb-4c0f-9dc5-50fc585d54c8";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg==";
        public static SmtpConfiguration Smtp = new();
        public class SmtpConfiguration     // configuração para envio de email
                                            // esta sendo criado uma classe dentro de uma classe
        {
            public string Host { get; set; }        // precisa da porta do host
            public int Port { get; set; } = 25;     // precisa da porta do servidor
            public string UserName { get; set; }        // precisa do usuario
            public string Password { get; set; }        // precisa da senha
        }
    }
}
