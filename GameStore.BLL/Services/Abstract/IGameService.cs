﻿using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGameService
    {
        Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO);
        
        Task<List<GameDTO>> GetListOfGamesAsync();

        Task<GameDTO> GetGameAsync(Expression<Func<Game, bool>> predicate);

        Task<bool> RemoveGameAsync(string key);

        Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO);

        Task<byte[]> DownloadGameFileAsync(string gameKey);
   
    }
}
