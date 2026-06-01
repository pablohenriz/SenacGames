using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SenacGames.Application.DTOs;
using SenacGames.Application.Interfaces;
using SenacGames.Domain.Entities;
using SenacGames.Domain.Interfaces;

namespace SenacGames.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return games.Select(MapToDto);
        }

        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            return game == null ? null : MapToDto(game);
        }

        public async Task<IEnumerable<GameDto>> GetFeatureAsync()
        {
            var games = await _gameRepository.GetFeatureAsync();
            return games.Select(MapToDto);
        }

        public async Task<IEnumerable<GameDto>> GetByCategoryAsync(int categoryId)
        {
            var games = await _gameRepository.GetByCategoryAsync(categoryId);
            return games.Select(MapToDto);
        }

        // Corrigida a assinatura do método para implementação pública
        public async Task<GameDto> CreateAsync(GameDto dto)
        {
            // Mapeia o DTO de criação para entidade game
            var game = new Game
            {
                Title = dto.Title,
                Description = dto.Description,
                ReleaseYear = dto.ReleaseYear,
                CoverImageUrl = dto.CoverImageUrl,
                CategoryId = dto.CategoryId,
                IsFeatured = dto.IsFeatured,
                CreatedAt = DateTime.Now
            };

            await _gameRepository.AddAsync(game);
            return MapToDto(game);
        }

        public async Task<GameDto?> UpdateAsync(int id, UpdateGameDto dto)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null) return null;

            // Atualiza os campos do game existente com os dados do DTO de atualização
            game.Title = dto.Title;
            game.Description = dto.Description;
            game.ReleaseYear = dto.ReleaseYear;
            game.CoverImageUrl = dto.CoverImageUrl;
            game.CategoryId = dto.CategoryId;
            game.IsFeatured = dto.IsFeatured;

            await _gameRepository.UpdateAsync(game);
            return MapToDto(game);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return false;
            }

            await _gameRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _gameRepository.CountAsync();
        }

        private static GameDto MapToDto(Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseYear = game.ReleaseYear,
                CoverImageUrl = game.CoverImageUrl,
                CategoryId = game.CategoryId,
                CategoryName = game.Category?.Name ?? string.Empty,
                IsFeatured = game.IsFeatured,
                CreatedAt = game.CreatedAt
            };
        }
    }
}