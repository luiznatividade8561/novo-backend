using System.ComponentModel.DataAnnotations;

namespace Cenix.Domain.ConstantsVariables;

public static class ConstantsVariables
{
    // default (PARCIALMENTE OBRIGATÓRIO)
    public static string AIACOS_API = Environment.GetEnvironmentVariable("AIACOS_API") ?? throw new ValidationException("Envioroment variable AIACOS_API not found");
    public static string MODULE_ID = Environment.GetEnvironmentVariable("MODULE_ID") ?? throw new ValidationException("Envioroment variable MODULE_ID not found");
    //public static string AIACOS_APP = Environment.GetEnvironmentVariable("AIACOS_APP") ?? throw new ValidationException("Envioroment variable AIACOS_APP not found"); // opcional
    public static string ZEUS_API = Environment.GetEnvironmentVariable("ZEUS_API") ?? throw new ValidationException("Envioroment variable ZEUS_API not found");

    // database (OBRIGATORIO)
    public static string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new ValidationException("Envioroment variable DB_HOST not found");
    public static string DB_PORT = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new ValidationException("Envioroment variable DB_PORT not found");
    public static string DB_USER = Environment.GetEnvironmentVariable("DB_USER") ?? throw new ValidationException("Envioroment variable DB_USER not found");
    public static string DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new ValidationException("Envioroment variable DB_PASSWORD not found");
    public static string DB_DATABASE = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new ValidationException("Envioroment variable DB_DATABASE not found");

    // rabbitmq (OPCIONAL)
    //public static string RABBITMQ_HOST = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? throw new ValidationException("Envioroment variable RABBITMQ_HOST not found");
    //public static string RABBITMQ_USER = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? throw new ValidationException("Envioroment variable RABBITMQ_USER not found");
    //public static string RABBITMQ_PASSWORD = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? throw new ValidationException("Envioroment variable RABBITMQ_PASSWORD not found");
    //public static string RABBITMQ_QUEUE_NAME = Environment.GetEnvironmentVariable("RABBITMQ_QUEUE_NAME") ?? throw new ValidationException("Envioroment variable RABBITMQ_QUEUE_NAME not found");

    // email (OPCIONAL)
    //public static string SMTP_HOST = Environment.GetEnvironmentVariable("SMTP_HOST") ?? throw new ValidationException("Envioroment variable SMTP_HOST not found");
    //public static string SMTP_USER = Environment.GetEnvironmentVariable("SMTP_USER") ?? throw new ValidationException("Envioroment variable SMTP_USER not found");
    //public static string SMTP_PASSWORD = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? throw new ValidationException("Envioroment variable SMTP_PASSWORD not found");
    //public static string SMTP_EMAIL = Environment.GetEnvironmentVariable("SMTP_EMAIL") ?? throw new ValidationException("Envioroment variable SMTP_EMAIL not found");

    // jwt (OBRIGATÓRIO)
    public static string JWT_KEY = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new ValidationException("Envioroment variable JWT_KEY not found");
    public static string JWT_ISSUER = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new ValidationException("Envioroment variable JWT_ISSUER not found");
    public static string JWT_AUDIENCE = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new ValidationException("Envioroment variable JWT_AUDIENCE not found");

    // redis (OPCIONAL)
    public static string REDIS_STRING_CONNECTION = Environment.GetEnvironmentVariable("REDIS_STRING_CONNECTION") ?? throw new ValidationException("Envioroment variable REDIS_STRING_CONNECTION not found");

    // azure blob
    public static string AZURE_BLOB_STRING_CONNECTION = Environment.GetEnvironmentVariable("AZURE_BLOB_STRING_CONNECTION") ?? throw new ValidationException("Envioroment variable AZURE_BLOB_STRING_CONNECTION not found");
    public static string AZURE_BLOB_CONTAINER_NAME = Environment.GetEnvironmentVariable("AZURE_BLOB_CONTAINER_NAME") ?? throw new ValidationException("Envioroment variable AZURE_BLOB_CONTAINER_NAME not found");
}
