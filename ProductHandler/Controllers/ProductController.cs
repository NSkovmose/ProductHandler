using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductHandler.Data;
using ProductHandler.Models;
using ProductHandler.Services;
using X.PagedList;

namespace ProductHandler.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchTerm, string currentFilter, int? page)
        {
            var products = await _productService.GetAllProducts();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter;
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Description.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(x => x.Name).ToList();
                    break;
                case "name_desc":
                    products = products.OrderByDescending(x => x.Name).ToList();
                    break;
                case "date_asc":
                    products = products.OrderBy(x => x.CreatedDate).ToList();
                    break;
                case "date_desc":
                    products = products.OrderByDescending(x => x.CreatedDate).ToList();
                    break;
                case "id_asc":
                    products = products.OrderBy(x => x.Id).ToList();
                    break;
                default:
                    products = products.OrderByDescending(x => x.Id).ToList();
                    break;
            }

            ViewBag.Products = products.ToPagedList(pageNumber, pageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSort = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
            ViewBag.NameSort = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            return View();
        }

        public async Task<IActionResult> DataTableIndex(string searchTerm)
        {
            var products = await _productService.GetAllProducts();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(x => x.Name.Contains(searchTerm) || x.Description.Contains(searchTerm)).ToList();
            }

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _productService.GetProduct(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.SaveProduct(productModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _productService.GetProduct(id);

            if (productModel == null)
            {
                return NotFound();
            }
            return View(productModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.EditProduct(productModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //TODO Log exception to db

                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _productService.GetProduct(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
