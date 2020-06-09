using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private IStockService _stockService;
        private IWarehouseService _warehouseService;
        private IUserService _userService;
        private IWarehouseOperationService _warehouseOperationService;
        public WarehouseController(IStockService stockService, IWarehouseService warehouseService, IUserService userService, IWarehouseOperationService warehouseOperationService)
        {
            _stockService = stockService;
            _warehouseService = warehouseService;
            _userService = userService;
            _warehouseOperationService = warehouseOperationService;
        }
        public IActionResult Index()
        {
            var model = new WarehouseOperationViewModel();

            List<SelectListItem> _selectListsWarehouse = new List<SelectListItem>();
            var warehouses = _warehouseService.GetAll();
            foreach (var item in warehouses)
            {
                _selectListsWarehouse.Add(new SelectListItem() { Text = item.WarehouseName, Value = item.WarehouseCode.ToString() });
            }
            model.selectListItemsWarehouse = _selectListsWarehouse;


            List<SelectListItem> _selectListsStock = new List<SelectListItem>();
            var stocks = _stockService.GetAllWithEagerLoading();
            foreach (var item in stocks)
            {
                _selectListsStock.Add(new SelectListItem() { Text = item.StockName, Value = item.StockCode.ToString() });
            }
            model.selectListItemsStock = _selectListsStock;


            List<SelectListItem> _selectListsOperationType = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Giriş", Value ="true" },
                new SelectListItem() { Text = "Giriş", Value ="false" }
            };
            model.selectListsOperationType = _selectListsOperationType;

            return View(model);
        }
        [HttpPost]
        public IActionResult Index(WarehouseOperation warehouseOperation)
        {
            warehouseOperation.CreateDate = DateTime.Now;

            var modelAvailableUser = _userService.GetByUserName(User.Identity.Name);
            warehouseOperation.UserId = modelAvailableUser.Id;

            _warehouseOperationService.Add(warehouseOperation);

            return RedirectToAction("Index", "WarehouseReports");
        }
    }
}