﻿using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class AssetTypeController : Controller
    {
        private readonly IAssetTypeService _assetTypeService;
        public AssetTypeController(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        //Get AssetTypes List
        [HttpGet]
        public async Task<IEnumerable<AssetTypeDTO>> GetAssetTypes() => await _assetTypeService.GetAssetTypes();



        //GetAssetType ById
        [HttpGet("id")]
        public async Task<AssetTypeDTO> GetAssetTypeById(int Id) => await _assetTypeService.GetAssetTypeById(Id);



        //Create new assetType
        [HttpPost]
        public async Task<AssetTypeDTO> CreateAssetType(int id, string name, string description, bool isactive)
        {
            AssetType? assetType = new()
            {
                Id = id,
                Name = name,
                Description = description,
                IsActive = isactive,
            };

            return await _assetTypeService.CreateAssetType(assetType);
        }



        //Edit assetType
        [HttpPut]
        public async Task<AssetTypeDTO> EditAssetType(int id, string name, string description, bool isactive)
        {
            return await _assetTypeService.EditAssetType(id, name, description, isactive);
        }



        //Delete Asset
        [HttpPut]
        public async Task<bool> ChangeStateAssetType(int id)
        {
            return await _assetTypeService.ChangeStateAssetType(id);
        }

    }
}
