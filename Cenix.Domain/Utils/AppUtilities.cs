namespace Cenix.Domain.Utils;

public static class AppUtilities
{

    public static DateTime GetDateTimeBrasilia()
    {
        // Obtém a data e hora atual no formato UTC
        DateTime dateTimeUtc = DateTime.UtcNow;

        // Define o fuso horário de Brasília
        TimeZoneInfo brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");

        // Converte a data e hora UTC para o fuso horário de Brasília
        DateTime brasiliaDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, brasiliaTimeZone);

        // Retorna o DateTime de Brasília com DateTimeKind.Unspecified
        DateTime resultDateTime = DateTime.SpecifyKind(brasiliaDateTime, DateTimeKind.Unspecified);

        return resultDateTime;
    }

}
