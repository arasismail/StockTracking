using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcWebUI.Extensions;
using MvcWebUI.Models;
using Nancy.Json;

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private IStockService _stockService;
        private IWarehouseService _warehouseService;
        private IUserService _userService;
        private ILogService _logService;
        public StockController(IStockService stockService, IWarehouseService warehouseService,IUserService userService,ILogService logService)
        {
            _stockService = stockService;
            _warehouseService = warehouseService;
            _userService = userService;
            _logService = logService;
        }
        public IActionResult Index()
        {


            var model = new StockListViewModel()
            {
                stocks = _stockService.GetAllWithEagerLoading()

            };

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new StockViewModel();
            if (id != 0)
            {
                model.stock = _stockService.GetByStockId(id);
            }
            HttpContext.Session.SetString("stokId",id.ToString());


            List<SelectListItem> selectLists = new List<SelectListItem>();
            var warehouses = _warehouseService.GetAll();
            foreach (var temp in warehouses)
            {
                selectLists.Add(new SelectListItem() { Text = temp.WarehouseName, Value = temp.WarehouseCode.ToString() });
            }


            model.selectLists = selectLists;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StockViewModel stockViewModel)
        {
            stockViewModel.stock.StockId = Int16.Parse(HttpContext.Session.GetString("stokId"));
            
           
             
            var modelAvailableUser = _userService.GetByUserName(User.Identity.Name);
            stockViewModel.stock.UserId = modelAvailableUser.Id;

            stockViewModel.stock.CreateDate = DateTime.Now;


            if (_stockService.GetByStockId(stockViewModel.stock.StockId) == null)
            {
                _stockService.Add(stockViewModel.stock);
            }
            else
            {
                Log log = new Log();
                Stock oldModel = _stockService.GetByStockId(stockViewModel.stock.StockId);
                string modelData = new JavaScriptSerializer().Serialize(oldModel);
                log.ModelData = modelData;

                try
                {
                    _stockService.Update(stockViewModel.stock);

                    log.Detail = "Stok güncelleme işlemi başarı ile gerçekleşti.";
                }
                catch (Exception ex)
                {
                    log.Detail = "Stok güncelleme işlemi başarısız. Hata Mesajı : " + ex;
                }
                finally
                {
                    log.CreateDate = DateTime.Now; ;
                    log.UserName = User.Identity.Name;
                    _logService.Add(log);
                }
            }


            return RedirectToAction("Index","Stock");
        }
        public IActionResult Delete(int id)
        {
            Log log = new Log();

            try
            {
                var model = _stockService.GetByStockId(id);

            
                string modelData = new JavaScriptSerializer().Serialize(model);
                log.ModelData = modelData;


                if (model == null)
                {
                    return RedirectToAction("Index", "Stock");
                }

                _stockService.Delete(model);

                log.Detail = "Stok silme işlemi başarı ile gerçekleşti.";

            }
            catch (Exception ex)
            {
                log.Detail = "Stok silme işlemi başarısız. Hata Mesajı : "+ex;
            }
            finally
            {
                log.CreateDate= DateTime.Now; ;
                log.UserName = User.Identity.Name;
                _logService.Add(log);
            }


            return RedirectToAction("Index", "Stock");
        }
    }
}

