using System.Threading.Tasks;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    // GET
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [NonAction]
    private Task<IActionResult> ReturnResult(IResult result)
    {
        return result.Success ? Task.FromResult<IActionResult>(Ok(result)) : Task.FromResult<IActionResult>(BadRequest(result));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetList()
    {
        var result = await _categoryService.GetListAsync();
        return await ReturnResult(result);
    }

   
    [HttpGet("getById")]
    public async Task<IActionResult> GetList(int productId)
    {
        var result = await _categoryService.GetByIdAsync(productId);
        return await ReturnResult(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(Category category)
    {
        var result = await _categoryService.AddAsync(category);
        return await ReturnResult(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(Category category)
    {
        var result = await _categoryService.UpdateAsync(category);
        return await ReturnResult(result);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(Category category)
    {
        var result = await _categoryService.DeleteAsync(category);
        return await ReturnResult(result);
    }
}