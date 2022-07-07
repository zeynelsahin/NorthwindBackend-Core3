using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPIasdad.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    // GET
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [NonAction]
    private Task<IActionResult> ReturnResult(IResult result)
    {
        return result.Success ? Task.FromResult<IActionResult>(Ok(result)) : Task.FromResult<IActionResult>(BadRequest(result));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetList()
    {
        var result = await _productService.GetListAsync();
        return await ReturnResult(result);
    }

    [HttpGet("getListByCategory")]
    public async Task<IActionResult> GetListByCategory(int categoryId)
    {
        var result = await _productService.GetListByCategoryAsync(categoryId);
        return await ReturnResult(result);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetList(int productId)
    {
        var result = await _productService.GetByIdAsync(productId);
        return await ReturnResult(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Product product)
    {
        var result = await _productService.AddAsync(product);
        return await ReturnResult(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(Product product)
    {
        var result = await _productService.UpdateAsync(product);
        return await ReturnResult(result);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(Product product)
    {
        var result = await _productService.DeleteAsync(product);
        return await ReturnResult(result);
    }
}