using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SenacGames.Application.DTOs
{
    internal class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///  Quantidade de agmes nesta categoria 
        ///  Útil para mostrar os dasboard e na listagem. 
        /// </summary>
        public int GameCount { get; set; }

    }

    /// <summary>
    /// DTO Para criação de uma nova categoria
    /// </summary>
    public class CreateCategoricDto 
    {
        public string Name { get; set; } = string.Empty;
    }


    /// <summary>
    /// DTO para atualização de uma categoria existente.
    /// </summary>
    public class UpdateCategoryDto 
    {
        public string Name { get; set; } = string.Empty;
    }
}
