using System;

namespace Cenix.Domain.Models
{
    /// <summary>
    /// Interface para parâmetros de filtragem, ordenação e paginação
    /// </summary>
    public interface IFilterParams
    {
        /// <summary>
        /// Filtro opcional por ID específico
        /// </summary>
        int? Id { get; }

        /// <summary>
        /// Termo de busca para filtrar colunas string usando ILIKE
        /// </summary>
        string? SearchTerm { get; }

        /// <summary>
        /// Nome da coluna para ordenação
        /// </summary>
        string? OrderBy { get; }

        /// <summary>
        /// Direção da ordenação ("asc" ou "desc")
        /// </summary>
        string? OrderDirection { get; }

        /// <summary>
        /// Número da página (0-based)
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Tamanho da página (entre 1 e 50)
        /// </summary>
        int PageSize { get; }
    }
}
