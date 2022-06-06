﻿using MainAPI.Data;
using MainAPI.DTO;
using MainAPI.HttpClientHelper;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    //connect to swagger
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class AssetController : Controller
    {

        private readonly IAssetService _assetService;
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }



        //Get Assets List
        [HttpGet]
        public async Task<IEnumerable<AssetDTO>> GetAssets() => await _assetService.GetAssets();



        //GetAsset ById
        [HttpGet("id")]
        public async Task<AssetDTO> GetAssetById(int Id) => await _assetService.GetAssetById(Id);



        //Create new asset
        [HttpPost]
        public async Task<AssetDTO> CreateAsset(int id, string name, string company, string location, DateTime creationDate, int assetTypeId, bool active )
        {
            Asset? asset = new()
            {
                Id = id,
                Name = name,
                Company = company,
                Location = location,
                CreationDate = creationDate,
                AssetTypeId = assetTypeId,
                IsActive = active,
            };

            return await _assetService.CreateAsset(asset);
        }



        //Edit asset
        [HttpPost]
        public async Task<AssetDTO> EditAsset(Asset asset)
        { 
            return await _assetService.EditAsset(asset);
        }



        //Delete Asset
        [HttpPost]
        public async Task<bool> ChangeState(int id)
        {
            return await _assetService.ChangeState(id);
        }

    }
}
