namespace Cenix.Application.DTOs
{
    /// <summary>
    /// Parâmetros para filtragem, ordenação e paginação de consultas
    /// </summary>
    public class FilterParams
    {
        /// <summary>
        /// Filtro opcional por ID específico
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Termo de busca para filtrar colunas string usando ILIKE
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Nome da coluna para ordenação
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// Direção da ordenação ("asc" ou "desc")
        /// </summary>
        public string? OrderDirection { get; set; }

        /// <summary>
        /// Número da página (0-based)
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Tamanho da página (entre 1 e 50)
        /// </summary>
        public int PageSize { get; set; }

        public FilterParams()
        {
            // Valores padrão
            Page = 0;
            PageSize = 10;

            // Validação dos limites
            ValidateAndAdjustPageSize();
        }

        /// <summary>
        /// Garante que o tamanho da página esteja dentro dos limites permitidos
        /// </summary>
        private void ValidateAndAdjustPageSize()
        {
            if (PageSize < 1)
            {
                PageSize = 1;
            }
            else if (PageSize > 50)
            {
                PageSize = 50;
            }
        }
    }
}
