using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class WarehouseReportsController : Controller
    {
        private IStockService _stockService;
        private IWarehouseService _warehouseService;
        private IWarehouseOperationService _warehouseOperationService;
        public WarehouseReportsController(IStockService stockService, IWarehouseService warehouseService, IWarehouseOperationService warehouseOperationService)
        {
            _stockService = stockService;
            _warehouseService = warehouseService;
            _warehouseOperationService = warehouseOperationService;
        }
        public IActionResult Index()
        {
            var model = new WarehouseReportsListViewModel()
            {
                WarehouseOperations = _warehouseOperationService.GetAll()
                
            };
            return View(model);
        }

    }
}